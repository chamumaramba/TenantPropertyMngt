using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.PropertyOwners
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

        public int SelectedPropertyOwnerID { get; set; } // New property to store the selected property owner ID

        public SelectList PropertyOwnersList { get; set; } 

        [BindProperty]
        public PropertyOwnerDto propertyOwnerDto { get; set; } = new PropertyOwnerDto();


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
            if (context.PropertiesOwners.Any(po => po.OwnerIdCard == propertyOwnerDto.OwnerIdCard))
            {
                errorMessage = "A property owner with the same ID Card/Passport already exists.";
                return;
            }

            PropertyOwnerModel propertyOwner = new PropertyOwnerModel()
            {
                PropertyOwnerName = propertyOwnerDto.PropertyOwnerName,
                Telephone = propertyOwnerDto.Telephone,
                OwnerIdCard= propertyOwnerDto.OwnerIdCard,
                Email = propertyOwnerDto.Email,
                Address = propertyOwnerDto.Address,
                PaymentDetails = propertyOwnerDto.PaymentDetails
            };
            context.PropertiesOwners.Add(propertyOwner);
            context.SaveChanges();

            //clear form
            propertyOwnerDto.PropertyOwnerName = "";
            propertyOwnerDto.Telephone = "";
            propertyOwnerDto.Email = "";
            propertyOwnerDto.Address = "";
            propertyOwnerDto.PaymentDetails = "";

            ModelState.Clear();

            successMessage = "Record created succesfully";

            Response.Redirect("/Agent/PropertyOwners/Index");
        }
    }
    
}

