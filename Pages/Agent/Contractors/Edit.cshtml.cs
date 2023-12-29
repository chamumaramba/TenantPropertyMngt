using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.Contractors
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;


        [BindProperty]
        public ContractorsDto contractorDto { get; set; } = new ContractorsDto();

        public string errorMessage = "";
        public string successMessage = "";

        public ContractorsModel contractorModel { get; set; } = new ContractorsModel();
        public EditModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                Response.Redirect("/Agent/Contractors/Index");
                return;
            }

            var contractor = context.Contractors.Find(id);

            if (contractor == null)
            {
                Response.Redirect("/Agent/Contractors/Index");
                return;
            }
            contractorDto.Company = contractor.Company;
            contractorDto.Specialization = contractor.Specialization;
            contractorDto.FullName = contractor.FullName;
            contractorDto.Email = contractor.Email;
            contractorDto.Address = contractor.Address;
            contractorDto.Telephone = contractor.Telephone;
            
            contractorModel = contractor;
        }


        public void OnPost(int? id)
        {
            if (context.Contractors.Any(po => po.Company == contractorDto.Company))
            {
                errorMessage = "A company with the same name already exists.";
                return;
            }

            if (id == null || id == 0)
            {
                Response.Redirect("/Agent/Contractors/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            var contractor = context.Contractors.Find(id);
            if (contractor == null)
            {
                Response.Redirect("/Agent/Contractors/Index");
                return;
            }

            // Update propertyOwner in the database
            contractor.Company = contractorDto.Company;
            contractor.Specialization = contractorDto.Specialization;   
            contractor.FullName = contractorDto.FullName;
            contractor.Email = contractorDto.Email;
            contractor.Address = contractorDto.Address;
            contractor.Telephone = contractorDto.Telephone;

            context.SaveChanges();

            contractorModel = contractor;

            successMessage = "Record update successful.";
            Response.Redirect("/Agent/Contarctor/Index");
        }
    }
}
