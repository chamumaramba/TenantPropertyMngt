using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;

namespace TenantPropertyMngt.Pages.Agent.PropertyOwners
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

        public DeleteModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Agent/PropertyOwners/Index");
                return;
            }
            var property = context.PropertiesOwners.Find(id);
            if (property == null)
            {
                Response.Redirect("/Agent/PropertyOwners/Index");
                return;
            }
            
            context.PropertiesOwners.Remove(property);
            context.SaveChanges();

            Response.Redirect("/Agent/PropertyOwners/Index");

        }
    }
}

