using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }

        // навигационные свойства
        public int ProductBrandId { get; set; }
        public ProductBrand Brand { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory Category { get; set; }

    }
}
