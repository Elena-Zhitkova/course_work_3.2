using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int OrderPrice { get; set; }
        public string ProductsID { get; set; }
    }
}
