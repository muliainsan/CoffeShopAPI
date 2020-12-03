using CoffeShop.Enties;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using CoffeShop.Models.Request.OrderEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Services.Interface
{
    public interface IOrderEntryApplicationService
    {
        //Task<Response<OrderEntry>> AddOrderEntry(AddOrderEntryRequest request);
        ListResponse<OrderEntry> GetOrderEntry(GetOrderEntryRequest request);
        Response<OrderEntry> GetDetailOrderEntry(IdOnlyRequest request);
        Response<OrderEntry> UpdateOrderEntry(UpdateOrderEntryRequest request);
        Response<OrderEntry> DeleteOrderEntry(IdOnlyRequest request);
    }
}
