using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.Properties
{
    public class DetailsModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

       
        [BindProperty]
        public PropertyDto propertyDto { get; set; } = new PropertyDto();

        [BindProperty]
        public PropertyModel propertyModel { get; set; } = new PropertyModel();
        

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

            var property = await context.Properties
                .Include(p => p.propertyOwner) 
                .FirstOrDefaultAsync(m => m.PropertyID == id);

            if (property == null)
            {
                return NotFound();
            }
            else
            {
                propertyModel.PropertyID = property.PropertyID;
                propertyDto.PropertyName = property.PropertyName;
                propertyDto.PropertyDescription = property.PropertyDescription;
                propertyDto.PropertyType = property.PropertyType;
                propertyDto.Rent = property.Rent;
                propertyDto.Status = property.Status;
                propertyDto.PropertyOwnerID = property.PropertyOwnerID;

                // Access the owner name through the navigation property
                propertyDto.Owner = property.propertyOwner?.PropertyOwnerName;
                propertyDto.Telephone=property.propertyOwner?.Telephone;

                propertyDto.ImageFileName = property.ImageFileName;
            }
            return Page();
        }

    }
}

