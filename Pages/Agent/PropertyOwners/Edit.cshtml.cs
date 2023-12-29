using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.PropertyOwners
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;


        [BindProperty]
        public PropertyOwnerDto propertyOwnerDto { get; set; } = new PropertyOwnerDto();

        public string errorMessage = "";
        public string successMessage = "";

        public PropertyOwnerModel propertyOwnerModel { get; set; } = new PropertyOwnerModel();
        public EditModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                Response.Redirect("/Agent/PropertOwners/Index");
                return;
            }

            var Owner = context.PropertiesOwners.Find(id);

            if (Owner == null)
            {
                Response.Redirect("/Agent/PropertyOwners/Index");
                return;
            }

            propertyOwnerDto.PropertyOwnerName = Owner.PropertyOwnerName;
            propertyOwnerDto.OwnerIdCard = Owner.OwnerIdCard;
            propertyOwnerDto.Telephone = Owner.Telephone;
            propertyOwnerDto.Email = Owner.Email;
            propertyOwnerDto.Address = Owner.Address;
            propertyOwnerDto.PaymentDetails = Owner.PaymentDetails;

            propertyOwnerModel = Owner;
        }


        public void OnPost(int? id)
        {
            if (context.PropertiesOwners.Any(po => po.OwnerIdCard == propertyOwnerDto.OwnerIdCard))
            {
                errorMessage = "A property owner with the same ID Card/Passport already exists.";
                return;
            }

            if (id == null || id == 0)
            {
                Response.Redirect("/Agent/PropertyOwners/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            var propertyOwner = context.PropertiesOwners.Find(id);
            if (propertyOwner == null)
            {
                Response.Redirect("/Agent/PropertyOwners/Index");
                return;
            }

            // Update propertyOwner in the database
            propertyOwner.PropertyOwnerName = propertyOwnerDto.PropertyOwnerName;
            propertyOwner.OwnerIdCard = propertyOwnerDto.OwnerIdCard;
            propertyOwner.Telephone = propertyOwnerDto.Telephone;
            propertyOwner.Email = propertyOwnerDto.Email;
            propertyOwner.Address = propertyOwnerDto.Address;
            propertyOwner.PaymentDetails = propertyOwnerDto.PaymentDetails;

            context.SaveChanges();

            propertyOwnerModel = propertyOwner;

            successMessage = "Property Owner update successful.";
            Response.Redirect("/Agent/PropertyOwners/Index");
        }
    }
}
