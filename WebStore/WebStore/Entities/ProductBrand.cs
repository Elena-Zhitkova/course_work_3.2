using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Entities
{
    public class ProductBrand
    {
      
        public int Id { get; set; }
        public int ProductBrandId { get; set; }
        public string BrandName { get; set; }

        /// Навигационное свойство 1-ко-многим
        public List<Product> Brands { get; set; }
    }
}
