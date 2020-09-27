using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Models.Request.Order
{
    public class AddOrderRequest
    {
        public List<MenuOrder> Orders{ get; set; }

    }

    public class MenuOrder{
        public Guid MenuId { get; set; }
        public int Quantity { get; set; }
    }
}
