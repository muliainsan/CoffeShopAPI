using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Models.Request.Menu
{
    public class GetMenuRequest
    {
        public string MenuName { get; set; }
        public double Price { get; set; }
        public string QuickSearch { get; set; }
        public string SortBy { get; set; } = "MenuName";
        public bool SortAsc { get; set; }
        [Required]
        public int Page { get; set; }
        [Required]
        public int PageSize { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
