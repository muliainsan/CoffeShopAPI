using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using CoffeShop.Models.Request.Menu;
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
        Response<Menu> UpdateMenu(UpdateMenuRequest request);
        Response<Menu> DeleteMenu(IdOnlyRequest request);
    }
}
