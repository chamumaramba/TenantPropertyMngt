using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace TenantPropertyMngt.Models
{
    public enum RentStatus
    {
        Paid,
        Pending,
        DueToday,
        Overdue
    }
    public class RentPaymentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentPaymentID { get; set; }

        [Display(Name = "Lease ID")]
        public int LeaseID { get; set; }

        [ForeignKey("LeaseID")]
        public virtual LeaseModel? Lease { get; set; }

        [Display(Name = "Address")]
        public string? PropertyName { get; set; }

        [Display(Name ="Name")]
        public string? TenantName { get; set; }
        public string? Telephone {  get; set; }

        [Display(Name = "Payment Amount")]
        [DataType(DataType.Currency)]
        public decimal Rent { get; set; }

        [Display(Name ="Lease Start Date")]
    
        public string StartDate { get; set; }

        [Display(Name = "Lease Start Date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }= DateTime.MinValue;
        [Display(Name = "Status")]
        public RentStatus Status { get; set; } = RentStatus.Pending;

        
        

    }
}
