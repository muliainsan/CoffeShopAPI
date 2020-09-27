using CoffeShop.Utilities;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Enties
{
    public class Order
    {
        public Guid Id { get; set; } = new Guid();
        public DateTime _CreatedDate { get; set; } = DateUtils.GetDateNow();
        public string CreatedBy { get; set; } = Constant.Data.SYSTEM;
        public DateTime _DeletedDate { get; set; }
        public bool _DeletedFlag { get; set; }
        public string DeletedBy { get; set; }
        public bool _LastModifier { get; set; }
        public string LastModifierBy { get; set; }


        public string OrderName { get; set; } = Constant.Data.SYSTEM;
        public double Total { get; set; }
        public DateTime OrderDate { get; set; } = DateUtils.GetDateNow();
        public List<OrderEntry> OrderEntries { get; set; }

    }
}
