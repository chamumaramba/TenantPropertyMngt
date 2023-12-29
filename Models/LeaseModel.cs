using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.ComponentModel;

namespace TenantPropertyMngt.Models
{
    public enum LeaseStatus
    {
        Active,
        Terminated,
        // Add other status values as needed
    }
    public class LeaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Lease ID")]
        public int LeaseID { get; set; }

        [Display(Name = "Lease Type")]
        public string? LeaseType { get; set; }

        [Display(Name = "Property ID")]
        public int PropertyID { get; set; }

        [Display(Name = "Rent")]
        [DataType(DataType.Currency)]
        public decimal? Rent { get; set; }

        [ForeignKey("PropertyID")]
        [Display(Name = "property Name")]
        public virtual PropertyModel? Properties { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Telephone { get; set; }

        [Required(ErrorMessage = "Please select a tenant.")]
        [Display(Name = "Tenant ID")]
        public int TenantID { get; set; }

        [ForeignKey("TenantID")]
        [Display(Name = "Tenant Name")]
        public virtual TenantModel? Tenant { get; set; }

        public string? TenantName { get; set; } = string.Empty;

        [DisplayName("ID Card/Passport")]
        public string? IdCard { get; set; } = string.Empty;

        public string? PropertyName {  get; set; } = string.Empty;

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now;

        public LeaseStatus? Status { get; set; } = LeaseStatus.Active;

        public virtual ICollection<TenantModel>? Tenants { get; set; } = new List<TenantModel>();

        public virtual ICollection<RentPaymentModel>? RentPayments { get; set; } = new List<RentPaymentModel>();



    }
}
