using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Models
{
    public class ListResponse<T> : Response<List<T>>
    {
        public int TotalItems { get; set; }
    }
}
