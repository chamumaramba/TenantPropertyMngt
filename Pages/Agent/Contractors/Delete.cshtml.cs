using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;

namespace TenantPropertyMngt.Pages.Agent.Contractors
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
                Response.Redirect("/Agent/Contractors/Index");
                return;
            }
            var contractor = context.Contractors.Find(id);
            if (contractor == null)
            {
                Response.Redirect("/Agent/Contractors/Index");
                return;
            }

            context.Contractors.Remove(contractor);
            context.SaveChanges();

            Response.Redirect("/Agent/Contractors/Index");

        }
    }
}
