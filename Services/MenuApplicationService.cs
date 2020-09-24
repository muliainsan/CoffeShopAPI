using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using CoffeShop.Services.Interface;
using CoffeShop.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            };


            _context.Menu.Add(menu);
            await _context.SaveChangesAsync();
            return new Response<Menu>();
        }

        public ListResponse<Menu> GetMenu(GetMenuRequest request)
        {
            var menus = _filter(request);

            var displayData = menus.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();
            return new ListResponse<Menu>()
            {
                TotalItems = displayData.Count,
                Data = displayData
            };
        }

        public Response<Menu> GetDetailMenu(IdOnlyRequest request)
        {
            var menuDetail = _context.Menu.Where(w => w._DeletedFlag != true && w.Id == request.Id);

            if (menuDetail.FirstOrDefault() == null)
            {
                return new Response<Menu>()
                {
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "The Id Not found"
                };
            }
            return new Response<Menu>()
            {
                Data = menuDetail.FirstOrDefault()
            };
        }

        private IQueryable<Menu> _filter(GetMenuRequest request)
        {
            var query = _context.Menu.Where(w => w._DeletedFlag != true);

            if (!string.IsNullOrEmpty(request.MenuName))
            {
                query = query.Where(p => p.MenuName != null &&
                                         p.MenuName.ToLower().Contains(request.MenuName.ToLower()));
            }
            query = query.OrderBy(o => o.MenuName);

            return query;
        }
    }
}
