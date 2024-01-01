using Humanizer.Localisation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.Lease
{
    public class TerminateModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly TenantPropertyMngtDbContext _context;

        public TerminateModel(TenantPropertyMngtDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public LeaseModel LeaseModel { get; set; } = default!;

        private bool LeaseGenerationExists(int id)
        {
            return (_context.Leases?.Any(e => e.LeaseID == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> OnPostTerminateLease(int? id)
        {
            if (id == null || _context.Leases == null)
            {
                return NotFound();
            }

            var lease = await _context.Leases.FirstOrDefaultAsync(m => m.LeaseID == id);

            if (lease == null)
            {
                return NotFound();
            }

            try
            {
                // Retrieve associated PropertyID
                var propertyId = lease.PropertyID;

                // Update the Tenants table to remove the associated PropertyID
                var tenant = await _context.Tenants.FirstOrDefaultAsync(t => t.TenantID == lease.TenantID);

                if (tenant != null)
                {
                    tenant.PropertyID = 0;
                }

                // Update the Properties table to set Status to "Vacant"
                var property = await _context.Properties.FirstOrDefaultAsync(p => p.PropertyID == propertyId);

                if (property != null)
                {
                    property.Status = OccupationStatus.Vacant.ToString();
                }

                // Mark the Lease as terminated
                lease.Status = LeaseStatus.Terminated;

                // Save changes to the database
                await _context.SaveChangesAsync();

                return RedirectToPage("/Index"); // Redirect to a success page
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

                // Redirect to an error page
                return RedirectToPage("/Error");
            }

        }
    }

}



