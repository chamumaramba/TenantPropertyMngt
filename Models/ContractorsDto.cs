using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TenantPropertyMngt.Models
{
    public class ContractorsDto
    {
        [Display(Name = "Contact Person")]
        public string? FullName { get; set; }

        public string? Company { get; set; }

        public string? Specialization { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Address { get; set; }
        public string? Telephone { get; set; }
    }
}
