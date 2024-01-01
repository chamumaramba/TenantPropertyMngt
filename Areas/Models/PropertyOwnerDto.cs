using System.ComponentModel.DataAnnotations;

namespace TenantPropertyMngt.Models
{
    public class PropertyOwnerDto
    {
        [Display(Name = "Property Owner Name")]
        public string? PropertyOwnerName { get; set; } = "";

        [Display(Name = "ID Card/Passport")]
        [Required]
        public string OwnerIdCard { get; set; } = string.Empty;

        public string? Telephone { get; set; } = "";

        [EmailAddress]
        public string? Email { get; set; } = "";

        public string? Address { get; set; } 
        [Display(Name = "Payment Details")]
        public string? PaymentDetails { get; set; } = "";
    }
}
