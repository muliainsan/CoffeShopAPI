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

        public async Task<Response<Menu>> AddMenu(AddMenuRequest request)
        {

            var menu = new Menu()
            {
                Id = new Guid(),
                MenuName = request.MenuName,
                Price = request.Price,
                CategoryId = request.CategoryId,
                

                _CreatedDate = new DateTime(),
                CreatedBy = "SYSTEM",

            };


            _context.Menu.Add(menu);
            await _context.SaveChangesAsync();
            return new Response<Menu>();
        }
    }
}
