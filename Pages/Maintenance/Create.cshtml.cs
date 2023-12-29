using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;
using Microsoft.AspNetCore.Authorization;

namespace TenantPropertyMngt.Pages.Maintenance
{
    [Authorize(Roles ="tenant")]
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;


        private readonly UserManager<ApplicationUser> _userManager;


        [BindProperty]
        public MaintenanceDto maintenanceDto { get; set; } = new MaintenanceDto();
        public MaintenanceModel maintenanceModel { get; set; } = new MaintenanceModel();

        public CreateModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.environment = environment;
            this.context = context;
            _userManager = userManager;
        }
        public void OnGet()
        {

        }

        public string errorMessage = "";
        public string successMessage = "";

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return Page();
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                errorMessage = "User not found.";
                return Page();
            }

            try
            {
                // Fetch the lease associated with the current user
                var userLease = context.Leases
                    .FirstOrDefault(l => l.Tenant.Email == currentUser.Email);

                if (userLease == null)
                {
                    errorMessage = "Lease not found for the current user.";
                    return Page();
                }

                // Create a new maintenance issue
                MaintenanceModel issue = new MaintenanceModel()
                {
                    IssueTitle = maintenanceDto.IssueTitle,
                    IssueDescription = maintenanceDto.IssueDescription,
                    DateReported = maintenanceDto.DateReported,
                    PropertyName = userLease.PropertyName, 
                    Status = maintenanceDto.Status
                };

                // Add the maintenance issue to the context and save changes
                context.Maintenances.Add(issue);
                await context.SaveChangesAsync();

                successMessage = "Record created successfully.";
                return RedirectToPage("/TenantView");
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred while processing your request.";
                return Page();
            }
        }

    }
}

