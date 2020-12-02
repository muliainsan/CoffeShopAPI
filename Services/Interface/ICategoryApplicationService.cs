using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using CoffeShop.Models.Request.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Services.Interface
{
    public interface ICategoryApplicationService
    {

        Task<Response<Category>> AddCategory(AddCategoryRequest request);
        ListResponse<Category> GetCategory(GetCategoryRequest request);
        Response<Category> GetDetailCategory(IdOnlyRequest request);
        Response<Category> UpdateCategory(UpdateCategoryRequest request);
        Response<Category> DeleteCategory(IdOnlyRequest request);
    }
}
