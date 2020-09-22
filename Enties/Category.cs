using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Enties
{
    public class Category
    {
        public Guid Id { get; set; }
        public DateTime _CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime _DeletedDate { get; set; }
        public bool _DeletedFlag { get; set; }
        public string DeletedBy { get; set; }
        public bool _LastModifier { get; set; }
        public string LastModifierBy { get; set; }


        public string CategoryName { get; set; }
    }
}
