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
using CoffeShop.Models.Request.OrderEntry;
using CoffeShop.Models.Request;

namespace CoffeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderEntriesController : ControllerBase
    {
        private readonly CoffeShopDbContext _context;
        public readonly IOrderEntryApplicationService _OrderEntryApplicationService;

        public OrderEntriesController(CoffeShopDbContext context, IOrderEntryApplicationService OrderEntryApplicationService)
        {
            _context = context;
            _OrderEntryApplicationService = OrderEntryApplicationService;
        }

        /*[HttpPost]
        [Route("add")]
        public Task<Response<OrderEntry>> AddOrderEntry([FromBody] AddOrderEntryRequest request)
        {
            return _OrderEntryApplicationService.AddOrderEntry(request);
        }*/

        [HttpGet]
        [Route("get")]
        public ListResponse<OrderEntry> GetOrderEntry([FromBody] GetOrderEntryRequest request)
        {
            return _OrderEntryApplicationService.GetOrderEntry(request);
        }

        [HttpGet]
        [Route("get/detail")]
        public Response<OrderEntry> GetDetailOrderEntry([FromBody] IdOnlyRequest request)
        {
            return _OrderEntryApplicationService.GetDetailOrderEntry(request); ;
        }

        [HttpPost]
        [Route("update")]
        public Response<OrderEntry> UpdateOrderEntry([FromBody] UpdateOrderEntryRequest request)
        {
            return _OrderEntryApplicationService.UpdateOrderEntry(request);
        }

        [HttpPost]
        [Route("delete")]
        public Response<OrderEntry> DeleteOrderEntry(IdOnlyRequest request)
        {
            return _OrderEntryApplicationService.DeleteOrderEntry(request);
        }
    }



}

