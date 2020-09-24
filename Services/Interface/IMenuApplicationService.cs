using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Services.Interface
{
    public interface IMenuApplicationService
    {

        Task<Response<Menu>> AddMenu(AddMenuRequest request);
        ListResponse<Menu> GetMenu(GetMenuRequest request);
        Response<Menu> GetDetailMenu(IdOnlyRequest request);
    }
}
