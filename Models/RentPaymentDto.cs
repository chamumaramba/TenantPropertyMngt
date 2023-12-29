using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TenantPropertyMngt.Models
{
    public class RentPaymentDto
    {

        [Display(Name = "Address")]
        public string? PropertyName { get; set; }

        [Display(Name = "Lease ID")]
        public int LeaseID { get; set; }

        [ForeignKey("LeaseID")]
        public virtual LeaseModel? Lease { get; set; }

        [Display(Name = "Name")]
        public string? TenantName { get; set; }

        public string? Telephone { get; set; }

        [Display(Name = "Payment Amount")]
        [DataType(DataType.Currency)]
        public decimal Rent { get; set; }

        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; } = DateTime.MinValue;

        [Display(Name = "Due Date")]
       
        public string StartDate { get; set; }

        [Display(Name = "Lease Start Date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }= DateTime.Now;

        [Display(Name = "Status")]
        public RentStatus Status { get; set; } = RentStatus.Pending;

        
        


    }
}

