using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;
using Microsoft.EntityFrameworkCore;

namespace TenantPropertyMngt.Pages.Agent.PropertyOwners
{
    public class DetailsModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

        public string errorMessage = "";
        public string successMessage = "";
        [BindProperty]
        public PropertyOwnerDto propertyOwnerDto { get; set; } = new PropertyOwnerDto();

        [BindProperty]
        public PropertyOwnerModel propertyOwnerModel { get; set; } = new PropertyOwnerModel();


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

            var owner = await context.PropertiesOwners.FirstOrDefaultAsync(m => m.PropertyOwnerID == id);
            if (owner == null)
            {
                errorMessage = "Property Owner matching the ID not Found";
                return Page();
            }

            else
            {
                propertyOwnerModel.PropertyOwnerID = owner.PropertyOwnerID;
                propertyOwnerDto.PropertyOwnerName = owner.PropertyOwnerName;
                propertyOwnerDto.OwnerIdCard= owner.OwnerIdCard;
                propertyOwnerDto.Address= owner.Address;
                propertyOwnerDto.Telephone= owner.Telephone;
                propertyOwnerDto.Email= owner.Email;
                propertyOwnerDto.PaymentDetails= owner.PaymentDetails;
           

            }
            return Page();
        }
    }
}
