using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;
using Microsoft.EntityFrameworkCore;

namespace TenantPropertyMngt.Pages.Agent.Contractors
{
    public class DetailsModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

        public string errorMessage = "";
        public string successMessage = "";
        [BindProperty]
        public ContractorsDto contractorDto { get; set; } = new ContractorsDto();

        [BindProperty]
        public ContractorsModel contractorsModel { get; set; } = new ContractorsModel();


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

            var contractor = await context.Contractors.FirstOrDefaultAsync(m => m.ContractorID == id);
            if (contractor == null)
            {
                errorMessage = "Contractor matching the ID not Found";
                return Page();
            }

            else
            {
                contractorsModel.ContractorID = contractor.ContractorID;
                contractorDto.Company = contractor.Company;
                contractorDto.Specialization = contractor.Specialization;
                contractorDto.FullName = contractor.FullName;
                contractorDto.Address = contractor.Address;
                contractorDto.Email = contractor.Email;
                contractorDto.Telephone = contractor.Telephone;

            }
            return Page();
        }

    }
}
