using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Entities;
using WebStore.Extentions;
using WebStore.Models;
using WebStore.Data;

namespace WebStore.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        int _pageSize;

        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var productsFiltered = _context.Product
                .Where(d => !group.HasValue || d.ProductCategoryId == group.Value);
            ViewData["Groups"] = _context.ProductCategory;
            ViewData["CurrentGroup"] = group ?? 0;
            var model = ListViewModel<Product>.GetModel(productsFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }


       
    }
}
