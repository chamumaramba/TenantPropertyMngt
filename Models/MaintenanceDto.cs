using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TenantPropertyMngt.Models
{
    public class MaintenanceDto
    {
        [Required(ErrorMessage = "Please provide a title for the maintenance issue.")]
        [Display(Name = "Issue Title")]
  
        public string? IssueTitle { get; set; }

        [Required(ErrorMessage = "Please provide a description for the maintenance issue.")]
        [Display(Name = "Issue Description")]
        public string? IssueDescription { get; set; }

        [Display(Name = "Date Reported")]
        [DataType(DataType.Date)]
        public DateTime DateReported { get; set; } = DateTime.Now;

        [Display(Name = "Property Name")]
        public string? PropertyName { get; set; }

        [Display(Name = "Status")]
        public MaintenanceIssueStatus Status { get; set; } = MaintenanceIssueStatus.Reported;
    }
}
