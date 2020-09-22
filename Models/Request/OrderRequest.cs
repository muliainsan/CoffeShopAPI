using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Models.Request
{
    public class OrderRequest
    {
        public List<MenuOrder> Orders{ get; set; }

    }

    public class MenuOrder{
        public Guid MenuId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
