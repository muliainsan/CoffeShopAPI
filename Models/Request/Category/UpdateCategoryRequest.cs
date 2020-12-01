using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Models.Request.Category
{
    public class UpdateCategoryRequest
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
    }
}
