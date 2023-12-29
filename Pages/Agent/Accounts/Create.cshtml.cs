using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;
using Microsoft.EntityFrameworkCore;

namespace TenantPropertyMngt.Pages.Agent.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

        [BindProperty]
        public int SelectedLeaseID { get; set; }
        public SelectList LeaseList { get; set; }

        [BindProperty]
        public RentPaymentDto rentPaymentDto { get; set; } = new RentPaymentDto();
        public RentPaymentModel rentPaymentModel { get; set; } = new RentPaymentModel();

        public string errorMessage = "";
        public string successMessage = "";

        public CreateModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public IActionResult OnGet()
        {
            try
            {
                // Get leases without a payment for the current month
                var leasesWithoutPayment = context.Leases
                    .Where(lease => !context.RentPayments
                        .Any(payment => payment.LeaseID == lease.LeaseID
                            && payment.PaymentDate.Month == DateTime.Now.Month
                            && payment.PaymentDate.Year == DateTime.Now.Year))
                    .Select(t => new SelectListItem
                    {
                        Value = $"{t.LeaseID}, {t.TenantName}, {t.Telephone},{t.PropertyName}, {t.Rent}, {t.StartDate}",
                        Text = $"{t.LeaseID}, {t.TenantName}, {t.Telephone}, {t.PropertyName}, {t.Rent}, {t.StartDate} "
                    })
                    .ToList();

                ViewData["Leases"] = leasesWithoutPayment;
             
            }
            catch (Exception ex)
            {
                ViewData["Leases"] = new List<SelectListItem>();
               
            }

            return Page();
        }

        public string ErrorMessage { get; set; } = "";
        public string SuccessMessage { get; set; } = "";

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ErrorMessage = "Please provide all the required fields";
                    return Page();
                }

                var selectedLease = await context.Leases
                        .FirstOrDefaultAsync(t => t.LeaseID == rentPaymentDto.LeaseID);

                if (selectedLease == null)
                {
                    ModelState.AddModelError(string.Empty, "Please select a valid Lease");
                    return Page();
                }

                // Create a new Rent Payment
                RentPaymentModel rentPayment = new RentPaymentModel()
                {
                    LeaseID = selectedLease.LeaseID,
                    TenantName = rentPaymentDto.TenantName,
                    Telephone = rentPaymentDto.Telephone,
                    PropertyName = rentPaymentDto.PropertyName,
                    StartDate = rentPaymentDto.StartDate,
                    Rent = rentPaymentDto.Rent,
                    DueDate = rentPaymentDto.DueDate,
                    PaymentDate = rentPaymentDto.PaymentDate,
                    Status = (rentPaymentDto.PaymentDate != DateTime.MinValue)
                        ? (DateTime.Now.Date > rentPaymentDto.DueDate) ? RentStatus.Overdue : RentStatus.Paid
                        : (DateTime.Now.Date > rentPaymentDto.DueDate) ? RentStatus.Overdue : RentStatus.Pending,

                };

                // Add rent payment to context and save changes
                context.RentPayments.Add(rentPayment);
                await context.SaveChangesAsync();

                SuccessMessage = "Invoice created successfully";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ErrorMessage = "An error occurred while processing your request.";
                return Page();
            }
        }

    }
}

