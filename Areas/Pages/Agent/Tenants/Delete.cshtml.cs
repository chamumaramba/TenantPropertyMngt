using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;

namespace TenantPropertyMngt.Pages.Agent.Tenants
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
                Response.Redirect("/Agent/Tenants/Index");
                return;
            }
            var tenant = context.Tenants.Find(id);
            if (tenant == null)
            {
                Response.Redirect("/Agent/Tenants/Index");
                return;
            }

            context.Tenants.Remove(tenant);
            context.SaveChanges();

            Response.Redirect("/Agent/Tenants/Index");

        }
    }
}
