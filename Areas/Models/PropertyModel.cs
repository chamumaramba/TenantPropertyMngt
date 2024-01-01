using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TenantPropertyMngt.Models
{
    public enum OccupationStatus
    {
        Vacant,
        Occupied
    }
    public class PropertyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyID { get; set; }

        [Display(Name = "Property Name")]
        public string? PropertyName { get; set; } = string.Empty;

        [Display(Name = "Type")]
        public string? PropertyType { get; set; } = string.Empty;

        [Display(Name ="Description")]
        public string? PropertyDescription { get; set; } = string.Empty;

        [DisplayName("Rent")]
        [DataType(DataType.Currency)]
        public decimal? Rent {  get; set; }
        [Display(Name ="Image")]
        public string? ImageFileName { get; set; }

        public string Status { get; set; } = OccupationStatus.Vacant.ToString();

        public int? TenantID { get; set; }

        [ForeignKey("TenantID")]
        [Display(Name = "Tenant ID")]
        public virtual ICollection<TenantModel>? Tenants { get; set; } = new List<TenantModel>();

        
        public string? Owner { get; set; } = string.Empty;

        [Display(Name = "Property Owner ID")]
        public int? PropertyOwnerID { get; set; }

        
        [ForeignKey("PropertyOwnerID")]
        [Display(Name = "Owner ID")]
        public virtual PropertyOwnerModel? propertyOwner { get; set; }

        public virtual ICollection<LeaseModel> Leases { get; set; } = new List<LeaseModel>();
    }
}
