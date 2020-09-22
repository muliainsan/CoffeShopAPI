using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Models.Request
{
    public class AddMenuRequest
    {
        public string MenuName { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
