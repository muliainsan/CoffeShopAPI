using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using CoffeShop.Models.Request.Menu;
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
            var menus = _filterQuery(request);

            var displayData = menus.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();
            return new ListResponse<Menu>()
            {
                TotalItems = displayData.Count,
                Data = displayData
            };
        }

        private IQueryable<Menu> _filterQuery(GetMenuRequest request)
        {
            var query = _context.Menu.Where(w => w._DeletedFlag != true);

            if (!string.IsNullOrEmpty(request.MenuName))
            {
                query = _context.Menu.Where(p => p.MenuName != null &&
                                         p.MenuName.ToLower().Contains(request.MenuName.ToLower()));
            }
            query = query.OrderBy(o => o.MenuName);

            return query;
        }

        public Response<Menu> GetDetailMenu(IdOnlyRequest request)
        {
            var Id = Guid.Parse(request.Id);

            var menuDetail = _context.Menu.Where(w => w.Id == Id);

            if (menuDetail.FirstOrDefault() == null)
            {
                return new Response<Menu>()
                {
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "Id Not found"
                };
            }
            return new Response<Menu>()
            {
                Data = menuDetail.FirstOrDefault()
            };
        }

        public Response<Menu> UpdateMenu(UpdateMenuRequest request)
        {
            var menuQuery = _context.Menu.Where(w =>w.Id == request.Id);

            if (menuQuery.FirstOrDefault() == null)
            {
                return new Response<Menu>()
                {
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "Id Not found"
                };
            };

            var menu = menuQuery.FirstOrDefault();

            menu.MenuName = request.MenuName;
            menu.Price = request.Price;
            menu.CategoryId = request.CategoryId;

            _context.Entry(menu).State = EntityState.Modified;
            _context.SaveChanges();
            return new Response<Menu>();
        }

        public Response<Menu> DeleteMenu(IdOnlyRequest request)
        {
            var Id = Guid.Parse(request.Id);

            var menuQuery = _context.Menu.Where(w => w.Id == Id);

            if (menuQuery.FirstOrDefault() == null)
            {
                return new Response<Menu>()
                {
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "Id Not found"
                };
            };

            var menu = menuQuery.FirstOrDefault();

            menu._DeletedFlag = true;
            menu._DeletedDate = DateUtils.GetDateNow();
            menu.DeletedBy = Constant.Data.SYSTEM;

            _context.Entry(menu).State = EntityState.Modified;
            _context.SaveChanges();
            return new Response<Menu>();
        }
    }
}
