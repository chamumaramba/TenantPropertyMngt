using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;
using Microsoft.EntityFrameworkCore;
namespace TenantPropertyMngt.Pages.Agent.Tenants
{
    public class DetailsModel : PageModel
    {
        
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

        [BindProperty]
        public TenantDto tenantDto { get; set; } = new TenantDto();

        [BindProperty]
        public TenantModel tenantModel { get; set; } = new TenantModel();


        public DetailsModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Tenants == null)
            {
                return NotFound();
            }

            var tenant = await context.Tenants.FirstOrDefaultAsync(m => m.TenantID == id);
            if (tenant == null)
            {
                return NotFound();
            }
            else
            {
                tenantDto.TenantID = tenant.TenantID;
                tenantDto.TenantName = tenant.TenantName;
                tenantDto.IdCard= tenant.IdCard;
                tenantDto.DateOfBirth = tenant.DateOfBirth;
                tenantDto.Gender = tenant.Gender;
                tenantDto.MaritalStatus = tenant.MaritalStatus;
                tenantDto.Telephone = tenant.Telephone;
                tenantDto.Occupation = tenant.Occupation;
                tenantDto.Email = tenant.Email;
                tenantDto.PropertyID = tenant.PropertyID;
               
            }
            return Page();
        }
    }
}

