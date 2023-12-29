using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Maintenance
{
    public class DetailsModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;


        [BindProperty]
        public MaintenanceDto maintenanceDto { get; set; } = new MaintenanceDto();

        [BindProperty]
        public MaintenanceModel maintenanceModel { get; set; } = new MaintenanceModel();


        public DetailsModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Properties == null)
            {
                return NotFound();
            }

            var issue = await context.Maintenances.FirstOrDefaultAsync(m => m.MaintenanceIssueID == id);
            if (issue == null)
            {
                return NotFound();
            }

            else
            {
                maintenanceModel.MaintenanceIssueID = issue.MaintenanceIssueID;
                maintenanceDto.IssueTitle=issue.IssueTitle;
                maintenanceDto.IssueDescription=issue.IssueDescription;
                maintenanceDto.PropertyName=issue.PropertyName;
                maintenanceDto.DateReported=issue.DateReported;
                maintenanceDto.Status=issue.Status;
               
            }
            return Page();
        }

    }
}
