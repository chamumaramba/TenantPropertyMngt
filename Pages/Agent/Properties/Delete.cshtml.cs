using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TenantPropertyMngt.Data;

namespace TenantPropertyMngt.Pages.Agent.Properties
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
                Response.Redirect("/Agent/Properties/Index");
                return;
            }
            var product = context.Properties.Find(id);
            if (product == null)
            {
                Response.Redirect("/Agent/Properties/Index");
                return;
            }
            string imageFullPath = environment.WebRootPath + "/Images" + product.ImageFileName;
            System.IO.File.Delete(imageFullPath);

            context.Properties.Remove(product);
            context.SaveChanges();

            Response.Redirect("/Agent/properties/Index");

        }
    }
}
