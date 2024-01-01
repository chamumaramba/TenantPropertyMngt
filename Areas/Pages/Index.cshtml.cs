using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TenantPropertyMngt.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
       
        public IActionResult OnGet()
        {
            
            var isAdmin = User.IsInRole("admin");
            var isAgent = User.IsInRole("agent");
            var isTenant = User.IsInRole("tenant");

            if (isAdmin)
            {
                // Redirect to the admin dashboard
                return LocalRedirect("/Dashboard");
            }
            else if (isAgent)
            {
                return LocalRedirect("/Dashboard");
            }
            else if (isTenant)
            {
                return LocalRedirect("/TenantView");
            }

            // Add logic for other roles or return the default page
            return Page();
        }
    }

}
