using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using CoffeShop.Models.Request.OrderEntry;
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
    public class OrderEntryApplicationService : IOrderEntryApplicationService
    {
        private readonly CoffeShopDbContext _context;

        public OrderEntryApplicationService(CoffeShopDbContext context)
        {
            _context = context;
        }

        public ListResponse<OrderEntry> GetOrderEntry(GetOrderEntryRequest request)
        {
            var orderEntries = _filterQuery(request);

            var displayData = orderEntries.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();
            return new ListResponse<OrderEntry>()
            {
                TotalItems = displayData.Count,
                Data = displayData
            };
        }

        private IQueryable<OrderEntry> _filterQuery(GetOrderEntryRequest request)
        {
            var orderQuery = _context.Order.Where(w => w._DeletedFlag != true);
            var orderEntriesQuery = _context.OrderEntry.Where(w => w._DeletedFlag != true);
            

            if (!string.IsNullOrEmpty(request.OrderName))
            {
                var orderId = orderQuery.Where(p => p.OrderName.ToLower() == request.OrderName.ToLower()).SingleOrDefault().Id;

                orderEntriesQuery = _context.OrderEntry.Where(p => p.OrderId != null &&
                                         p.OrderId == orderId);
            }

            if (!string.IsNullOrEmpty(request.Total))
            {
                orderEntriesQuery = _context.OrderEntry.Where(p => p.Price == Double.Parse(request.Total));
            }

            if (!string.IsNullOrEmpty(request.StartDate))
            {
                orderEntriesQuery = _context.OrderEntry.Where(p => p._CreatedDate >= Convert.ToDateTime(request.StartDate) &&
                                         p._CreatedDate <= Convert.ToDateTime(request.EndDate));
            }

            orderEntriesQuery = orderEntriesQuery.OrderByDescending(o => o.CreatedBy);

            return orderEntriesQuery;
        }

        public Response<OrderEntry> GetDetailOrderEntry(IdOnlyRequest request)
        {
            var Id = Guid.Parse(request.Id);

            var OrderEntryDetail = _context.OrderEntry.Where(w => w.Id == Id);

            if (OrderEntryDetail.FirstOrDefault() == null)
            {
                return new Response<OrderEntry>()
                {
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "Id Not found"
                };
            }
            return new Response<OrderEntry>()
            {
                Data = OrderEntryDetail.FirstOrDefault()
            };
        }

        public Response<OrderEntry> UpdateOrderEntry(UpdateOrderEntryRequest request)
        {
            var OrderEntryQuery = _context.OrderEntry.Where(w =>w.Id == request.Id);

            if (OrderEntryQuery.FirstOrDefault() == null)
            {
                return new Response<OrderEntry>()
                {  
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "Id Not found"
                };
            };

            var OrderEntry = OrderEntryQuery.FirstOrDefault();

            

            _context.Entry(OrderEntry).State = EntityState.Modified;
            _context.SaveChanges();
            return new Response<OrderEntry>();
        }

        public Response<OrderEntry> DeleteOrderEntry(IdOnlyRequest request)
        {
            var Id = Guid.Parse(request.Id);

            var OrderEntryQuery = _context.OrderEntry.Where(w => w.Id == Id);

            if (OrderEntryQuery.FirstOrDefault() == null)
            {
                return new Response<OrderEntry>()
                {
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "Id Not found"
                };
            };

            var OrderEntry = OrderEntryQuery.FirstOrDefault();

            OrderEntry._DeletedFlag = true;
            OrderEntry._DeletedDate = DateUtils.GetDateNow();
            OrderEntry.DeletedBy = Constant.Data.SYSTEM;

            _context.Entry(OrderEntry).State = EntityState.Modified;
            _context.SaveChanges();
            return new Response<OrderEntry>();
        }
    }
}
