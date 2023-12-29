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

        public void OnPost(int? id)
        {
            if (id == null || id == 0)
            {
                Response.Redirect("/Agent/Accounts/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            var Invoice = context.RentPayments.Find(id);
            if (Invoice == null)
            {
                Response.Redirect("/Agent/Accounts/Index");
                return;
            }
            
            Invoice.TenantName=rentPaymentDto.TenantName;
            Invoice.Telephone=rentPaymentDto.Telephone;
            Invoice.PropertyName=rentPaymentDto.PropertyName;
            Invoice.StartDate=rentPaymentDto.StartDate;
            Invoice.Rent=rentPaymentDto.Rent;
            Invoice.DueDate=rentPaymentDto.DueDate;
            //Invoice.PaymentDate=rentPaymentDto.PaymentDate;
            if (rentPaymentDto.PaymentDate != null)
            {
                Invoice.Status = DateTime.Now.Date > rentPaymentDto.DueDate ? RentStatus.Paid : RentStatus.Pending;
            }
            else
            {
                Invoice.Status = DateTime.Now.Date > rentPaymentDto.DueDate ? RentStatus.Overdue : RentStatus.Pending;
            }

            context.SaveChanges();

            rentPaymentModel = Invoice;

            successMessage="Invoice update successful.";
            
            Response.Redirect("/Agent/Accounts/Index");
        }

    }
}
