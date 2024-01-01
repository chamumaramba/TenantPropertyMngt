using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace TenantPropertyMngt.Pages.Agent.Lease
{
    public class DetailsModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

        [BindProperty]
        public LeaseDto leaseDto { get; set; } = new LeaseDto();

        [BindProperty]
        public LeaseModel leaseModel { get; set; } = new LeaseModel();


        public DetailsModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Leases == null)
            {
                return NotFound();
            }

            var lease = await context.Leases.FirstOrDefaultAsync(m => m.LeaseID == id);
            if (lease == null)
            {
                return NotFound();
            }
            else
            {
                leaseModel.LeaseID = lease.LeaseID;
                leaseDto.LeaseType = lease.LeaseType;
                leaseDto.TenantName = lease.TenantName;
                leaseDto.IdCard = lease.IdCard;
                leaseDto.Email = lease.Email;
                leaseDto.Telephone = lease.Telephone;
                leaseModel.PropertyID = lease.PropertyID;
                leaseDto.Rent= lease.Rent;
                leaseDto.StartDate = lease.StartDate;
                leaseDto.EndDate = lease.EndDate;
                leaseDto.Status = lease.Status ?? LeaseStatus.Active;

            }
            return Page();
        }
    }
}
