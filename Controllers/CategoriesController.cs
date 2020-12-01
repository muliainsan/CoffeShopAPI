using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Services.Interface;
using CoffeShop.Models;
using CoffeShop.Models.Request.Category;
using CoffeShop.Models.Request;

namespace CoffeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CoffeShopDbContext _context;
        private readonly ICategoryApplicationService _categoryApplicationService;

        public CategoriesController(CoffeShopDbContext context, ICategoryApplicationService categoryApplicationService)
        {
            _context = context;
            _categoryApplicationService = categoryApplicationService;
        }

        [HttpPost]
        [Route("add")]
        public Task<Response<Category>> AddCategory([FromBody] AddCategoryRequest request)
        {
            return _categoryApplicationService.AddCategory(request);
        }

        [HttpGet]
        [Route("get")]
        public ListResponse<Category> GetCategory([FromBody] GetCategoryRequest request)
        {
            return _categoryApplicationService.GetCategory(request);
        }

        [HttpGet]
        [Route("get/detail")]
        public Response<Category> GetDetailCategory([FromBody] IdOnlyRequest request)
        {
            return _categoryApplicationService.GetDetailCategory(request); ;
        }

        [HttpPost]
        [Route("update")]
        public Response<Category> UpdateCategory([FromBody] UpdateCategoryRequest request)
        {
            return _categoryApplicationService.UpdateCategory(request);
        }

        [HttpPost]
        [Route("delete")]
        public Response<Category> DeleteCategory(IdOnlyRequest request)
        {
            return _categoryApplicationService.DeleteCategory(request);
        }
    }
}
