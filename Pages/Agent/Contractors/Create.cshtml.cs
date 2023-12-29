using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.Contractors
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

        [BindProperty]
        public ContractorsDto contractorDto { get; set; } = new ContractorsDto();

        public ContractorsModel contractorModel { get; set; }= new ContractorsModel();
        public CreateModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet()
        {

        }

        public string errorMessage = "";
        public string successMessage = "";

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (context.Contractors.Any(po => po.Company == contractorDto.Company))
                {
                    errorMessage = "A vendor with the same name already exists.";
                    return Page();
                }

                ContractorsModel contractor = new ContractorsModel()
                {
                    Company = contractorDto.Company,
                    Specialization = contractorDto.Specialization,
                    FullName = contractorDto.FullName,
                    Telephone = contractorDto.Telephone,
                    Email = contractorDto.Email,
                    Address = contractorDto.Address,
                };
                context.Contractors.Add(contractor);
                await context.SaveChangesAsync();

                ModelState.Clear();

                successMessage = "Record created successfully";

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                errorMessage = "An error occurred while saving the record. Please try again.";
                return Page();
            }
        }

    }
}
