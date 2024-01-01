using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.Tenants
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

        [BindProperty]
        public TenantDto tenantDto { get; set; } = new TenantDto();


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

        public void OnPost()
        {
            if (context.Tenants.Any(po => po.IdCard == tenantDto.IdCard))
            {
                errorMessage = "A property owner with the same ID Card/Passport already exists.";
                return;
            }
            if (context.Tenants.Any(po => po.Email == tenantDto.Email))
            {
                errorMessage = "A property owner with the same Email already exists.";
                return;
            }

            //Save new property to database
            TenantModel tenant = new TenantModel()
            {
                TenantName = tenantDto.TenantName,
                DateOfBirth = tenantDto.DateOfBirth,
                Gender = tenantDto.Gender,
                MaritalStatus = tenantDto.MaritalStatus,
                Telephone = tenantDto.Telephone,
                IdCard = tenantDto.IdCard,
                Occupation = tenantDto.Occupation,
                Email = tenantDto.Email,
                PropertyID = tenantDto.PropertyID,
            };
            context.Tenants.Add(tenant);
            context.SaveChanges();

            ModelState.Clear();

            successMessage = "Tenant created succesfully";

            Response.Redirect("/Agent/Tenants/Index");
        }
    }
}
