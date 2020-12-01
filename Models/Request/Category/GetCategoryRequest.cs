using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Models.Request.Category
{
    public class GetCategoryRequest
    {
        public string CategoryName { get; set; }
        public string QuickSearch { get; set; }
        public string SortBy { get; set; } = "CategoryName";
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
