using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.Properties
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;
        

        [BindProperty]
        public PropertyDto propertyDto { get; set; } = new PropertyDto();

        public string errorMessage = "";
        public string successMessage = "";

        public PropertyModel propertyModel { get; set; } = new PropertyModel();
        public EditModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                Response.Redirect("/Agent/Properties/Index");
                return;
            }

            var Property = context.Properties.Find(id);

            if (Property == null)
            {
                Response.Redirect("/Agent/Properties/Index");
                return;
            }

            propertyDto.PropertyName = Property.PropertyName;
            propertyDto.PropertyType = Property.PropertyType;
            propertyDto.PropertyDescription = Property.PropertyDescription;
            propertyDto.Rent = Property.Rent;

            propertyModel = Property;
        }

        public void OnPost(int? id)
        {
            if (context.Properties.Any(po => po.PropertyName == propertyDto.PropertyName))
            {
                errorMessage = "A property  with the same address already exists.";
                return;
            }
            if (id == null || id == 0)
            {
                Response.Redirect("/Agent/Product/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            var Property = context.Properties.Find(id);
            if (Property == null)
            {
                Response.Redirect("/Agent/Product/Index");
                return;
            }

            // Update image file
            string newFileName = propertyModel.ImageFileName;
            if (propertyDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(propertyDto.ImageFile.FileName);

                string imageFullPath = environment.WebRootPath + "/Images/" + newFileName;        

                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    propertyDto.ImageFile.CopyTo(stream);
                }

                // Delete old image
                string oldImageFullPath = environment.WebRootPath + "/Images/" + Property.ImageFileName;

              

                System.IO.File.Delete(oldImageFullPath);
            }

            // Update property in the database
            Property.PropertyName = propertyDto.PropertyName;
            Property.PropertyType = propertyDto.PropertyType;
            Property.PropertyDescription = propertyDto.PropertyDescription;
            Property.Rent = propertyDto.Rent;
            Property.ImageFileName = newFileName;

            context.SaveChanges();

            propertyModel = Property;
           
            successMessage = "Property update successful.";
            Response.Redirect("/Agent/Properties/Index");
        }

    }
}
