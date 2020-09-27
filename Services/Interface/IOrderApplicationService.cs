using CoffeShop.Enties;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using CoffeShop.Models.Request.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Services.Interface
{
    public interface IOrderApplicationService
    {
        Task<Response<Order>> PlaceOrder(AddOrderRequest request);
        ListResponse<Order> GetOrder(GetOrderRequest request);
        Response<Order> GetDetailOrder(IdOnlyRequest request);
        Response<Order> UpdateOrder(UpdateOrderRequest request);
        Response<Order> DeleteOrder(IdOnlyRequest request);
    }
}
