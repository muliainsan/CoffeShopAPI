using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using CoffeShop.Models.Request.Category;
using CoffeShop.Services.Interface;
using CoffeShop.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoffeShop.Services
{
    public class CategoryApplicationService : ICategoryApplicationService
    {
        private readonly CoffeShopDbContext _context;

        public CategoryApplicationService(CoffeShopDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Category>> AddCategory(AddCategoryRequest request)
        {

            var Category = new Category()
            {
                CategoryName = request.CategoryName
            };


            _context.Category.Add(Category);
            await _context.SaveChangesAsync();
            return new Response<Category>();
        }

        public ListResponse<Category> GetCategory(GetCategoryRequest request)
        {
            var Categorys = _filterQuery(request);

            var displayData = Categorys.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();
            return new ListResponse<Category>()
            {
                TotalItems = displayData.Count,
                Data = displayData
            };
        }

        private IQueryable<Category> _filterQuery(GetCategoryRequest request)
        {
            var query = _context.Category.Where(w => w._DeletedFlag != true);

            if (!string.IsNullOrEmpty(request.CategoryName))
            {
                query = _context.Category.Where(p => p.CategoryName != null &&
                                         p.CategoryName.ToLower().Contains(request.CategoryName.ToLower()));
            }
            query = query.OrderBy(o => o.CategoryName);

            return query;
        }

        public Response<Category> GetDetailCategory(IdOnlyRequest request)
        {
            var Id = Guid.Parse(request.Id);

            var CategoryDetail = _context.Category.Where(w => w.Id == Id);

            if (CategoryDetail.FirstOrDefault() == null)
            {
                return new Response<Category>()
                {
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "Id Not found"
                };
            }
            return new Response<Category>()
            {
                Data = CategoryDetail.FirstOrDefault()
            };
        }

        public Response<Category> UpdateCategory(UpdateCategoryRequest request)
        {
            var CategoryQuery = _context.Category.Where(w =>w.Id == request.Id);

            if (CategoryQuery.FirstOrDefault() == null)
            {
                return new Response<Category>()
                {
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "Id Not found"
                };
            };

            var Category = CategoryQuery.FirstOrDefault();

            Category.CategoryName = request.CategoryName;

            _context.Entry(Category).State = EntityState.Modified;
            _context.SaveChanges();
            return new Response<Category>();
        }

        public Response<Category> DeleteCategory(IdOnlyRequest request)
        {
            var Id = Guid.Parse(request.Id);

            var CategoryQuery = _context.Category.Where(w => w.Id == Id);

            if (CategoryQuery.FirstOrDefault() == null)
            {
                return new Response<Category>()
                {
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "Id Not found"
                };
            };

            var Category = CategoryQuery.FirstOrDefault();

            Category._DeletedFlag = true;
            Category._DeletedDate = DateUtils.GetDateNow();
            Category.DeletedBy = Constant.Data.SYSTEM;

            _context.Entry(Category).State = EntityState.Modified;
            _context.SaveChanges();
            return new Response<Category>();
        }
    }
}
