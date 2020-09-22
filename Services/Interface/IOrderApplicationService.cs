using CoffeShop.Enties;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Services.Interface
{
    public interface IOrderApplicationService
    {
        Task<Response<Order>> PlaceOrder(OrderRequest request);
    }
}
