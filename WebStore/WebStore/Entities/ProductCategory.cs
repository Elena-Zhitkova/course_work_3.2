using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; } 
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }

        /// Навигационное свойство 1-ко-многим
        public List<Product> Categories { get; set; }
    }
}
