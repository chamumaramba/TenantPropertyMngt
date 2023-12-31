using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.Tenants
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;


        [BindProperty]
        public TenantDto tenantDto { get; set; } = new TenantDto();

        public string errorMessage = "";
        public string successMessage = "";

        public TenantModel tenantModel { get; set; } = new TenantModel();
        public EditModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                Response.Redirect("/Agent/Tenants/Index");
                return;
            }

            var tenant = context.Tenants.Find(id);

            if (tenant == null)
            {
                Response.Redirect("/Agent/Tenants/Index");
                return;
            }

            tenantDto.TenantName = tenant.TenantName;
            tenantDto.IdCard = tenant.IdCard;
            tenantDto.DateOfBirth = tenant.DateOfBirth;
            tenantDto.Gender = tenant.Gender;
            tenantDto.MaritalStatus = tenant.MaritalStatus;
            tenantDto.Telephone = tenant.Telephone;
            tenantDto.Occupation = tenant.Occupation;
            tenantDto.Email = tenant.Email;
            tenantDto.PropertyID = tenant.PropertyID;
            

            tenantModel = tenant;
        }

        public void OnPost(int? id)
        {
            if (id == null || id == 0)
            {
                Response.Redirect("/Agent/Tenants/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            var tenant = context.Tenants.Find(id);
            if (tenant == null)
            {
                Response.Redirect("/Agent/Tenants/Index");
                return;
            }

            // Update tenant in the database
            tenant.TenantName= tenantDto.TenantName;
            tenant.DateOfBirth = tenantDto.DateOfBirth;
            tenant.Gender = tenantDto.Gender;
            tenant.IdCard = tenantDto.IdCard;
            tenant.MaritalStatus = tenantDto.MaritalStatus;
            tenant.Telephone = tenantDto.Telephone;
            tenant.Occupation = tenantDto.Occupation;
            tenant.Email = tenantDto.Email;
            tenant.PropertyID = tenantDto.PropertyID;
            

            context.SaveChanges();

            tenantModel = tenant;
           
            successMessage = "Tenant update successful.";
            Response.Redirect("/Agent/Tenants/Index");
        }
    }
}
