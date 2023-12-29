using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TenantPropertyMngt.Models
{
    public class ContractorsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractorID { get; set; }

        [Display(Name ="Contact Person")]
        public string? FullName { get; set; }

        public string? Company { get; set; }

        public string? Specialization { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Address { get; set; }
        public string? Telephone { get; set; }
    }
}
