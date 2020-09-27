using CoffeShop.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Models.Request.Order
{
    public class UpdateOrderRequest
    {
        public Guid Id { get; set; }
        public string OrderName { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderEntry> OrderEntries { get; set; }
    }
}
