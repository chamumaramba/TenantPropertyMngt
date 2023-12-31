using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages
{
    
        [Authorize]
        public class DashboardModel : PageModel
        {
            private readonly ILogger<IndexModel> _logger;
            private readonly TenantPropertyMngtDbContext _context;

            public DashboardModel(ILogger<IndexModel> logger, TenantPropertyMngtDbContext context)
            {
                _logger = logger;
                _context = context;
            }
            public List<MaintenanceModel> MaintenanceIssues { get; set; }
            public List<RentPaymentModel> OverduePayments { get; set; }
            public List<LeaseModel> NearExpiringLeases { get; set; }    

            public int NumberOfProperties { get; set; }
            public decimal OccupationRate { get; set; }
            public int NearExpiringLeaseCount { get; set; }
            public int MaintenanceIssuesCount { get; set; }
            public int ActiveTenantsCount { get; set; }
            public int OverduePaymentsCount { get; set; }

            public async Task OnGetAsync()
{
                // Retrieve data from the database
                NumberOfProperties = await _context.Properties.CountAsync();
                OccupationRate = await CalculateOccupationRateAsync();

                // Retrieve near-expiring leases
                var nearExpiringLeases = await _context.Leases
                    .Where(l => EF.Functions.DateDiffDay(DateTime.Now, l.EndDate) <= 60)
                    .ToListAsync();

                NearExpiringLeaseCount = nearExpiringLeases.Count;

                ActiveTenantsCount = await _context.Tenants
                    .Where(t => t.lease.Any(l => l.Status == LeaseStatus.Active))
                    .CountAsync();

                // Retrieve maintenance issues with statuses "In Progress" and "Reported"
                var maintenanceIssues = await _context.Maintenances
                    .Where(m => m.Status == MaintenanceIssueStatus.InProgress || m.Status == MaintenanceIssueStatus.Reported)
                    .ToListAsync();

                MaintenanceIssuesCount = maintenanceIssues.Count;

                // Pass the near-expiring leases and maintenance issues to the view
                NearExpiringLeases = nearExpiringLeases;
                MaintenanceIssues = maintenanceIssues;

                var overduePayments = await _context.RentPayments
                    .Where(payment => payment.Status == RentStatus.Overdue && payment.DueDate < DateTime.Now)
                    .ToListAsync();

                OverduePaymentsCount = overduePayments.Count;
                OverduePayments = overduePayments;
}

            private async Task<decimal> CalculateOccupationRateAsync()
            {
               
                var totalProperties = await _context.Properties.CountAsync();
                var occupiedProperties = await _context.Properties
                    .Where(p => p.Status == OccupationStatus.Occupied)
                    .CountAsync();

                return totalProperties > 0
                    ? Math.Round((decimal)occupiedProperties / totalProperties * 100, 2)
                    : 0;

            }
        }
}
