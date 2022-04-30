using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebStore.Data;
using WebStore.Entities;

namespace WebStore.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebStore.Data.ApplicationDbContext _context;

        public CreateModel(WebStore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProductBrandId"] = new SelectList(_context.ProductBrand, "Id", "Id");
        ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
