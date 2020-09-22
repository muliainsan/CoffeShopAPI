using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Enties
{
    public class DbTemplate 
    {
        public Guid Id { get; set; }
        public DateTime _CreatedDate { get; set; }
        public DateTime _DeletedDate { get; set; }
        public bool _DeletedFlag { get; set; }
        public string CreatedBy { get; set; }
    }
}
