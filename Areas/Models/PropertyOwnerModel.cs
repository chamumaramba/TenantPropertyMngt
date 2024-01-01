using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TenantPropertyMngt.Models
{
    public class PropertyOwnerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Property Owner ID")]
        public int PropertyOwnerID { get; set; }

        [Display(Name = "Property Owner Name")]
        [Required]
        public string PropertyOwnerName { get; set; }= string.Empty;
        [Display(Name = "ID Card/Passport")]
        [Required]
        public string OwnerIdCard { get; set; } = string.Empty;

        [Required]
        public string? Telephone { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } 
        [Display(Name = "Payment Details")]
        [Required]
        public string PaymentDetails { get; set; } = string.Empty;
        public virtual ICollection<PropertyModel>? properties { get; set; } = new List<PropertyModel>();
    }
}
