using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Maintenance
{
    [Authorize(Roles ="agent")]
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;


        [BindProperty]
        public MaintenanceDto maintenanceDto { get; set; } = new MaintenanceDto();

        public string errorMessage = "";
        public string successMessage = "";

        public MaintenanceModel maintenanceModel { get; set; } = new MaintenanceModel();
        public EditModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                Response.Redirect("/Agent/PropertOwners/Index");
                return;
            }

            var issue = context.Maintenances.Find(id);

            if (issue == null)
            {
                Response.Redirect("/Maintenance/Index");
                return;
            }

           
            maintenanceDto.IssueTitle = issue.IssueTitle;
            maintenanceDto.IssueDescription = issue.IssueDescription;
            maintenanceDto.DateReported=issue.DateReported;
            maintenanceDto.PropertyName = issue.PropertyName;
            maintenanceDto.Status = issue.Status;

            maintenanceModel = issue;
        }

        public void OnPost(int? id)
        {
            if (id == null || id == 0)
            {
                Response.Redirect("/Maintenance/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            var issue = context.Maintenances.Find(id);
            if (issue == null)
            {
                Response.Redirect("/Maintenance/Index");
                return;
            }

            // Retain the existing property name
            var existingPropertyName = issue.PropertyName;

            // Update only specific fields
            issue.IssueTitle = maintenanceDto.IssueTitle;
            issue.IssueDescription = maintenanceDto.IssueDescription;
            issue.DateReported = maintenanceDto.DateReported;
            issue.PropertyName = existingPropertyName; 
            issue.Status = maintenanceDto.Status;

            context.SaveChanges();

            maintenanceModel = issue;

            Response.Redirect("/Maintenance/Index");
        }

    }
}
