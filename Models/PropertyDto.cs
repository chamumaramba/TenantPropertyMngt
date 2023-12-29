using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TenantPropertyMngt.Models
{
    public class PropertyDto
    {
        [Display(Name = "Property Name")]
        public string? PropertyName { get; set; } = string.Empty;

        [Display(Name = "Type")]
        public string? PropertyType { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string? PropertyDescription { get; set; } = string.Empty;
        public string? ImageFileName { get; set; }

        public decimal? Rent { get; set; }

        [Display(Name ="Image")]
        public IFormFile? ImageFile { get; set; }

        public string Status { get; set; } = OccupationStatus.Vacant.ToString();

        public string? Telephone { get; set; }
        public string? Owner { get; set; } = string.Empty;

        [Display(Name = "Property Owner ID")]
        public int? PropertyOwnerID { get; set; }

        
        [ForeignKey("PropertyOwnerID")]
        [Display(Name = "Owner ID")]
        public virtual PropertyOwnerModel? propertyOwner { get; set; }
    }
}
