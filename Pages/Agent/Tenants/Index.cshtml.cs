using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TenantPropertyMngt.Data;
using TenantPropertyMngt.Models;

namespace TenantPropertyMngt.Pages.Agent.Tenants
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

        public List<TenantModel> tenants { get; set; } = new List<TenantModel>();
        public IndexModel(TenantPropertyMngtDbContext context)
        {
            this._context = context;
        }


        public void OnGet(int? pageIndex, string? search, TenantModel p)
        {
            IQueryable<TenantModel> query = _context.Tenants;

            // serach function
            if (search != null)
            {
                this.search = search;
                query = query.Where(p =>
                        (p.TenantName != null && p.TenantName.Contains(search ?? "")) ||
                        (p.IdCard != null && p.IdCard.Contains(search ?? "")) ||
                        (p.Email != null && p.Email.Contains(search ?? "")));

            }
            query = query.OrderByDescending(p => p.TenantID);
            if (pageIndex == null || pageIndex < 1)
            {
                pageIndex = 1;
            }
            this.pageIndex = (int)pageIndex;
            decimal count = query.Count();
            totalPages = (int)Math.Ceiling(count / pageSize);
            query = query.Skip((this.pageIndex - 1) * pageSize)
                .Take(pageSize);
            tenants = query.ToList();
        }


    }
}