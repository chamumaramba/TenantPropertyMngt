using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.Accounts
{
    public class UpdateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;


        [BindProperty]
        public RentPaymentDto rentPaymentDto { get; set; } = new RentPaymentDto();

        public string errorMessage = "";
        public string successMessage = "";

        public RentPaymentModel rentPaymentModel { get; set; } = new RentPaymentModel();
        public UpdateModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null || id == 0)
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
            rentPaymentModel.RentPaymentID = invoice.RentPaymentID;
            rentPaymentDto.TenantName = invoice.TenantName;
            rentPaymentDto.Telephone=invoice.Telephone;
            rentPaymentDto.PropertyName = invoice.PropertyName;
            rentPaymentDto.StartDate = invoice.StartDate;
            rentPaymentDto.Rent=invoice.Rent;
            rentPaymentDto.DueDate = invoice.DueDate;
            rentPaymentDto.PaymentDate = invoice.PaymentDate;
            rentPaymentDto.Status = invoice.Status;
           
            rentPaymentModel = invoice;
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (id == null || id == 0)
            {
                Response.Redirect("/Agent/Accounts/Index");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return Page();
            }

            var invoice = context.RentPayments.Find(id);
            if (invoice == null)
            {
                return RedirectToPage("/Agent/Accounts/Index");
            }

            invoice.TenantName = rentPaymentDto.TenantName;
            invoice.Telephone = rentPaymentDto.Telephone;
            invoice.PropertyName = rentPaymentDto.PropertyName;
            invoice.StartDate = rentPaymentDto.StartDate;
            invoice.Rent = rentPaymentDto.Rent;
            invoice.DueDate = rentPaymentDto.DueDate;
            invoice.PaymentDate = rentPaymentDto.PaymentDate;

            if (rentPaymentDto.PaymentDate != null)
            {
                if (DateTime.Now.Date <= rentPaymentDto.DueDate)
                {
                    invoice.Status = RentStatus.Paid;
                }
                else
                {
                    invoice.Status = RentStatus.Pending;
                }
            }
            else
            {
                if (DateTime.Now.Date > rentPaymentDto.DueDate)
                {
                    invoice.Status = RentStatus.Overdue;
                }
                else
                {
                    invoice.Status = RentStatus.Pending;
                }
            }

            await context.SaveChangesAsync();

            Console.WriteLine($"PaymentDate: {rentPaymentDto.PaymentDate}");
            Console.WriteLine($"DueDate: {rentPaymentDto.DueDate}");
            ModelState.Clear();
            rentPaymentModel = invoice;

            successMessage = "Invoice update successful.";

            return RedirectToPage("/Agent/Accounts/Index");
        }


    }
}
