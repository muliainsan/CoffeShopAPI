using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Models;
using CoffeShop.Services.Interface;
using CoffeShop.Models.Request;
using CoffeShop.Models.Request.Menu;

namespace CoffeShop.Controllers
{
    [Route("api/menu")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly CoffeShopDbContext _context;
        private readonly IMenuApplicationService _menuApplicationService;

        public MenusController(CoffeShopDbContext context, IMenuApplicationService menuApplicationService)
        {
            _context = context;
            _menuApplicationService = menuApplicationService;
        }

        [HttpPost]
        [Route("add")]
        public Task<Response<Menu>> AddMenu([FromBody]AddMenuRequest request)
        {
            return _menuApplicationService.AddMenu(request);
        }


        // GET: api/Menus
        [HttpGet]
        [Route("get")]
        public ListResponse<Menu> GetMenu([FromBody]GetMenuRequest request)
        {
            return _menuApplicationService.GetMenu(request);
        }

        // GET: api/Menus/5
        [HttpGet]
        [Route("get/detail")]
        public Response<Menu> GetDetailMenu([FromBody] IdOnlyRequest request)
        {
            return _menuApplicationService.GetDetailMenu(request); ;
        }

        [HttpPost]
        [Route("update")]
        public Response<Menu> UpdateMenu([FromBody]UpdateMenuRequest request)
        {
            return _menuApplicationService.UpdateMenu(request);
        }

        [HttpPost]
        [Route("delete")]
        public Response<Menu> DeleteMenu(IdOnlyRequest request)
        {
            return _menuApplicationService.DeleteMenu(request);
        }

    }
}
