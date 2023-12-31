// TerminateModel.cs
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.Lease
{
    public class TerminateModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly TenantPropertyMngtDbContext _context;
        private readonly ILogger<TerminateModel> _logger;

        public TerminateModel(TenantPropertyMngtDbContext context, IWebHostEnvironment environment, ILogger<TerminateModel> logger)
        {
            _context = context;
            _environment = environment;
            _logger = logger;
        }

        [BindProperty]
        public LeaseModel LeaseModel { get; set; } = default!;

        public async Task<IActionResult> OnPostTerminateLease(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null || _context.Leases == null)
            {
                return NotFound();
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var lease = await _context.Leases.FirstOrDefaultAsync(m => m.LeaseID == id);

                    if (lease == null)
                    {
                        return NotFound();
                    }

                    // Retrieve associated PropertyID
                    var propertyId = lease.PropertyID;

                    // Update the Tenants table to remove the associated PropertyID
                    var tenant = await _context.Tenants.FirstOrDefaultAsync(t => t.TenantID == lease.TenantID);

                    if (tenant != null)
                    {
                        tenant.PropertyID = null; // Remove the association with the property
                    }

                    // Update the Properties table to set Status to "Vacant"
                    var property = await _context.Properties.FirstOrDefaultAsync(p => p.PropertyID == propertyId);

                    if (property != null)
                    {
                        property.Status = OccupationStatus.Vacant;
                    }

                    // Mark the Lease as terminated
                    lease.Status = LeaseStatus.Terminated;

                    // Save changes to the database
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    _logger.LogInformation("Lease terminated successfully.");

                    return RedirectToPage("/Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while terminating the lease.");

                    await transaction.RollbackAsync();

                    return RedirectToPage("/Error");
                }
            }
        }
    }
}
