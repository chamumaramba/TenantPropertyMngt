using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Maintenance
{
    public class IndexModel : PageModel
    {
        private readonly TenantPropertyMngtDbContext _context;

        //page numbering
        public int pageIndex = 1;
        public int totalPages = 0;
        private readonly int pageSize = 5;

        //Search functionality
        public string search = "";

        public List<MaintenanceModel> maintenanceModel { get; set; } = new List<MaintenanceModel>();
        public IndexModel(TenantPropertyMngtDbContext context)
        {
            this._context = context;
        }
        public void OnGet(int? pageIndex, string? search)
        {
            IQueryable<MaintenanceModel> query = _context.Maintenances;

            // serach function
            if (search != null)
            {
                this.search = search;
                query = query.Where(p => p.PropertyName.Contains(search)||p.IssueTitle.Contains(search));
            }
            query = query.OrderByDescending(p => p.MaintenanceIssueID);
            if (pageIndex == null || pageIndex < 1)
            {
                pageIndex = 1;
            }
            this.pageIndex = (int)pageIndex;
            decimal count = query.Count();
            totalPages = (int)Math.Ceiling(count / pageSize);
            query = query.Skip((this.pageIndex - 1) * pageSize)
                .Take(pageSize);
            maintenanceModel = query.ToList();
        }
    }
}
