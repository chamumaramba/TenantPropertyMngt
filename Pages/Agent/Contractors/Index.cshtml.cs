using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.Contractors
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

        public List<ContractorsModel> Contractors { get; set; } = new List<ContractorsModel>();
        public IndexModel(TenantPropertyMngtDbContext context)
        {
            this._context = context;
        }
        public void OnGet(int? pageIndex, string? search)
        {
            IQueryable<ContractorsModel> query = _context.Contractors;

            // serach function
            if (search != null)
            {
                this.search = search;
                query = query.Where(p => p.Company.Contains(search) || p.Specialization.Contains(search));

            }
            query = query.OrderByDescending(p => p.ContractorID);
            if (pageIndex == null || pageIndex < 1)
            {
                pageIndex = 1;
            }
            this.pageIndex = (int)pageIndex;
            decimal count = query.Count();
            totalPages = (int)Math.Ceiling(count / pageSize);
            query = query.Skip((this.pageIndex - 1) * pageSize)
                .Take(pageSize);
             Contractors = query.ToList();
        }
    }
}
