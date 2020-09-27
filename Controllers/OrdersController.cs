using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Models.Request;
using CoffeShop.Models;
using CoffeShop.Services.Interface;
using CoffeShop.Models.Request.Order;

namespace CoffeShop.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly CoffeShopDbContext _context;
        private readonly IOrderApplicationService _orderApplicationService;
        public OrdersController(CoffeShopDbContext context, IOrderApplicationService orderApplicationService)
        {
            _context = context;
            _orderApplicationService = orderApplicationService;
        }

        [HttpPost]
        [Route("add")]
        public Task<Response<Order>> PostOrder(AddOrderRequest order)
        {
            return _orderApplicationService.PlaceOrder(order);
        }


        [HttpGet]
        [Route("get")]
        public ListResponse<Order> GetOrder([FromBody] GetOrderRequest request)
        {
            return _orderApplicationService.GetOrder(request);
        }

        [HttpGet]
        [Route("get/detail")]
        public Response<Order> GetDetailOrder([FromBody] IdOnlyRequest request)
        {
            return _orderApplicationService.GetDetailOrder(request); ;
        }

        [HttpPost]
        [Route("update")]
        public Response<Order> UpdateOrder([FromBody] UpdateOrderRequest request)
        {
            return _orderApplicationService.UpdateOrder(request);
        }

        [HttpPost]
        [Route("delete")]
        public Response<Order> DeleteOrder(IdOnlyRequest request)
        {
            return _orderApplicationService.DeleteOrder(request);
        }





    }
}
