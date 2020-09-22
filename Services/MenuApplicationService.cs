using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using CoffeShop.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Services
{
    public class MenuApplicationService : IMenuApplicationService
    {
        private readonly CoffeShopDbContext _context;

        public MenuApplicationService(CoffeShopDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Menu>> AddMenu(MenuRequest request)
        {
            var menu = new Menu()
            {

            };


            _context.Menu.Add(menu);
            await _context.SaveChangesAsync();
            return new Response<Menu>();
        }
    }
}
