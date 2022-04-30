using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebStore.Data;
using WebStore.Entities;

namespace WebStore.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebStore.Data.ApplicationDbContext _context;

        public IndexModel(WebStore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category).ToListAsync();
        }
    }
}
