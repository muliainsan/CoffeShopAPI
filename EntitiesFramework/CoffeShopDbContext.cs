using CoffeShop.Enties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.EntitiesFramework
{
    public class CoffeShopDbContext : DbContext
    {
        public CoffeShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderEntry> OrderEntry { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
