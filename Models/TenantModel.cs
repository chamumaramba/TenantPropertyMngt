using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.ComponentModel;

namespace TenantPropertyMngt.Models
{
   
    public class TenantModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Tenant ID")]
        public int TenantID { get; set; }

        [Required]
        [Display(Name = "Tenant Name")]
        public string? TenantName { get; set; } = string.Empty;

        [Required]
        [DisplayName("ID Card/Passport")]
        public string? IdCard { get; set;} = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public string? DateOfBirth { get; set; } = string.Empty;

        public string? Gender { get; set; } = string.Empty;

        [Required]
        public string? MaritalStatus { get; set; }

        [Required]
        public string? Telephone { get; set; } = string.Empty;

        public string? Occupation{ get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; } = string.Empty;

        [Display(Name = "Property ID")]
        public int? PropertyID { get; set; }= 0;

        public virtual ICollection<LeaseModel> lease { get; set; } = new List<LeaseModel>();

        public virtual ICollection<PropertyModel>? AssociatedProperty { get; set; } = new List<PropertyModel>();

        public virtual ICollection<MaintenanceModel>? Maintenances { get; set; } = new List<MaintenanceModel>();


    }
}
