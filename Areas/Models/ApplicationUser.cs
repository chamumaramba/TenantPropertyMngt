using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace TenantPropertyMngt.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}
