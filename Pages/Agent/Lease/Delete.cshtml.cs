using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;

namespace TenantPropertyMngt.Pages.Agent.Lease
{
    [Authorize(Roles ="admin")]
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
                Response.Redirect("/Agent/Lease/Index");
                return;
            }
            var lease = context.Leases.Find(id);
            if (lease == null)
            {
                Response.Redirect("/Agent/Lease/Index");
                return;
            }
            
            context.Leases.Remove(lease);
            context.SaveChanges();

            Response.Redirect("/Agent/Lease/Index");

        }
    }
}
