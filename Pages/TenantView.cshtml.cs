using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages
{
    [Authorize(Roles = "tenant")]

    public class TenantViewModel : PageModel
    {
        private readonly TenantPropertyMngtDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public string errorMessage = "";
        public string successMessage = "";
        public TenantViewModel(UserManager<ApplicationUser> userManager, TenantPropertyMngtDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public TenantModel Tenant { get; set; }
        public ICollection<LeaseModel> Leases { get; set; } = new List<LeaseModel>();
        public ICollection<RentPaymentModel> RentPayments { get; set; } = new List<RentPaymentModel>();
        public ICollection<MaintenanceModel> MaintenanceIssues { get; set; } = new List<MaintenanceModel>();

        public async Task<IActionResult> OnGet()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToPage("/Error");
            }

            Tenant = _context.Tenants.SingleOrDefault(t => t.Email == currentUser.Email);

            if (Tenant == null)
            {
                return RedirectToPage("/Error");
            }

            // Retrieve leases for the current tenant
            Leases = _context.Leases.Where(l => l.TenantID == Tenant.TenantID).ToList();

            // Retrieve rent payments associated with the leases
            foreach (var lease in Leases)
            {
                var rentPaymentsForLease = _context.RentPayments
                    .Where(rp => rp.LeaseID == lease.LeaseID)
                    .OrderByDescending(rp => rp.PaymentDate)
                    .Take(3)
                    .ToList();

                // Update RentPayments to include PropertyName from the LeaseModel
                RentPayments.AddRange(rentPaymentsForLease.Select(rp =>
                {
                    rp.PropertyName = lease.PropertyName;
                    return rp;
                }));
            }

            // Retrieve maintenance issues associated with the tenant
            MaintenanceIssues = Leases
                .SelectMany(lease => _context.Maintenances
                    .Where(m => m.PropertyName == lease.PropertyName)
                )
                .ToList();

            return Page();
        }


    }
}
