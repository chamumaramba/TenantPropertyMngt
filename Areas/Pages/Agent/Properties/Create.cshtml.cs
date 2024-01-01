using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Models;
using TenantPropertyMngt.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TenantPropertyMngt.Pages.Agent.Properties
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

        [BindProperty]
        public int SelectedPropertyOwnerID { get; set; } // New property to store the selected property owner ID

        public SelectList PropertyOwnersList { get; set; } // New property to store the list of property owners



        [BindProperty]
        public PropertyDto propertyDto { get; set; } = new PropertyDto();

        
        public CreateModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet()
        {
            PropertyOwnersList = new SelectList(context.PropertiesOwners, "PropertyOwnerID", "PropertyOwnerName");
        }

        public string errorMessage = "";
        public string successMessage = "";

        public void OnPost()
        {
            if (context.Properties.Any(po => po.PropertyName == propertyDto.PropertyName))
            {
                errorMessage = "A property  with the same address already exists.";
                return;
            }
            if (propertyDto.ImageFile == null)
            {
                ModelState.AddModelError("propertyDto.ImageFile", "The image file is required");
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            //Save image file
            string newFilename = DateTime.Now.ToString("yyyMMddHHssfff");
            newFilename += Path.GetExtension(propertyDto.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/Images/" + newFilename;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                propertyDto.ImageFile.CopyTo(stream);
            }
            //Save new property to database
            PropertyModel property = new PropertyModel()
            {
                PropertyName = propertyDto.PropertyName,
                PropertyType = propertyDto.PropertyType,
                PropertyDescription = propertyDto.PropertyDescription,
                Rent = propertyDto.Rent,
                ImageFileName = newFilename,
                PropertyOwnerID = SelectedPropertyOwnerID
            };
            context.Properties.Add(property);
            context.SaveChanges();

            //clear form
            propertyDto.PropertyName = "";
            propertyDto.PropertyType = "";
            propertyDto.PropertyDescription = "";
            propertyDto.Rent = 0;
            propertyDto.ImageFile = null;

            ModelState.Clear();

            successMessage = "Property created succesfully";

            Response.Redirect("/Agent/Properties/Index");
        }
    }
}

