using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;

namespace TenantPropertyMngt.Pages.Maintenance
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
                Response.Redirect("/Maintenance/Index");
                return;
            }
            var issue = context.Maintenances.Find(id);
            if (issue == null)
            {
                Response.Redirect("/Maintenance/Index");
                return;
            }

            context.Maintenances.Remove(issue);
            context.SaveChanges();

            Response.Redirect("/Maintenance/Index");

        }
    }
}
