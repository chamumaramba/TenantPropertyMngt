using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;

namespace TenantPropertyMngt.Pages.Agent.Accounts
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
                Response.Redirect("/Agent/Accounts/Index");
                return;
            }
            var invoice = context.RentPayments.Find(id);
            if (invoice == null)
            {
                Response.Redirect("/Agent/Accounts/Index");
                return;
            }

            context.RentPayments.Remove(invoice);
            context.SaveChanges();

            Response.Redirect("/Agent/Accounts/Index");

        }
    }
}
