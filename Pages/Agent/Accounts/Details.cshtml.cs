using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;
using Microsoft.EntityFrameworkCore;
namespace TenantPropertyMngt.Pages.Agent.Accounts
{
    public class DetailsModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

        [BindProperty]
        public RentPaymentDto rentPaymentDto { get; set; } = new RentPaymentDto();

        [BindProperty]
        public RentPaymentModel rentPaymentModel { get; set; } = new RentPaymentModel();


        public DetailsModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.RentPayments == null)
            {
                return NotFound();
            }

            var invoice = await context.RentPayments.FirstOrDefaultAsync(m => m.RentPaymentID == id);
            if (invoice == null)
            {
                return NotFound();
            }
            else
            {
                rentPaymentModel.RentPaymentID = invoice.RentPaymentID;
                rentPaymentDto.TenantName = invoice.TenantName;
                rentPaymentDto.Telephone = invoice.Telephone;
                rentPaymentDto.PropertyName = invoice.PropertyName;
                rentPaymentDto.StartDate = invoice.StartDate;
                rentPaymentDto.Rent = invoice.Rent;
                rentPaymentDto.DueDate = invoice.DueDate;
                rentPaymentDto.PaymentDate = invoice.PaymentDate;
                rentPaymentDto.Status = invoice.Status;

            }
            return Page();
        }
    }
}
