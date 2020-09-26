using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Models.Request.Menu
{
    public class UpdateMenuRequest
    {
        public Guid Id { get; set; }
        public string MenuName { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
