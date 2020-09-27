using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using CoffeShop.Models.Request.Order;
using CoffeShop.Services.Interface;
using CoffeShop.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Services
{
    public class OrderApplicationService : IOrderApplicationService
    {
        private readonly CoffeShopDbContext _context;

        public OrderApplicationService(CoffeShopDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Order>> PlaceOrder(AddOrderRequest request)
        {
            var order = new Order();
            

            double total = 0;
            List<OrderEntry> orderEntries = new List<OrderEntry>();
            
            foreach (var temp in request.Orders)
            {
                var orderEntry = new OrderEntry();
                orderEntry.MenuId = temp.MenuId;
                orderEntry.Price = _context.Menu.Where(w => w.Id == temp.MenuId).FirstOrDefault().Price;
                orderEntry.Quantity = temp.Quantity;
                orderEntry.OrderId = order.Id;

                orderEntry._CreatedDate = DateUtils.GetDateNow();
                orderEntry.CreatedBy = "SYSTEM";
                orderEntry.Id = new Guid();

                total += orderEntry.Price*temp.Quantity;

                orderEntries.Add(orderEntry);
            }

            order.Total = total;

            _context.Order.Add(order);
            _context.OrderEntry.AddRange(orderEntries);

            await _context.SaveChangesAsync();

            return new Response<Order>();
        }

        public ListResponse<Order> GetOrder(GetOrderRequest request)
        {
            var menus = _filterQuery(request);

            var displayData = menus.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();
            return new ListResponse<Order>()
            {
                TotalItems = displayData.Count,
                Data = displayData
            };
        }

        private IQueryable<Order> _filterQuery(GetOrderRequest request)
        {
            var query = _context.Order.Where(w => w._DeletedFlag != true);

            if (!string.IsNullOrEmpty(request.EndDate))
            {

                var startDate = Convert.ToDateTime(request.StartDate);
                var endDate = Convert.ToDateTime(request.EndDate);
                
                query = _context.Order.Where(p => p.OrderDate >= startDate && p.OrderDate <= endDate );
            }
            else if (!string.IsNullOrEmpty(request.StartDate))
            {
                var startDate = Convert.ToDateTime(request.StartDate);
                query = _context.Order.Where(p => p.OrderDate == startDate);
            }


            query = query.OrderByDescending(o => o.OrderDate);

            return query;
        }

        public Response<Order> GetDetailOrder(IdOnlyRequest request)
        {
            var Id = Guid.Parse(request.Id);

            var OrderDetail = _context.Order.Where(w => w.Id == Id).FirstOrDefault();

            if (OrderDetail == null)
            {
                return new Response<Order>()
                {
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "Id Not found"
                };
            }

            OrderDetail.OrderEntries = _context.OrderEntry.Where(p => p.OrderId == OrderDetail.Id).ToList();
            return new Response<Order>()
            {
                Data = OrderDetail
            };
        }

        
        public Response<Order> UpdateOrder(UpdateOrderRequest request)
        {
            var orderQuery = _context.Order.Where(w => w.Id == request.Id);

            if (orderQuery.FirstOrDefault() == null)
            {
                return new Response<Order>()
                {
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "Id Not found"
                };
            };

            var order = orderQuery.FirstOrDefault();

            order.OrderName = request.OrderName;
            order.Total = _getTotal(request);
            order.OrderDate = request.OrderDate;

            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
            return new Response<Order>();
        }

        private double _getTotal(UpdateOrderRequest request)
        {
            var menuQuery = _context.OrderEntry.Where(p => p.OrderId == request.Id);
            
            return menuQuery.Sum(p => p.Price);
        }

        public Response<Order> DeleteOrder(IdOnlyRequest request)
        {
            var Id = Guid.Parse(request.Id);

            var orderQuery = _context.Order.Where(w => w.Id == Id);

            if (orderQuery.FirstOrDefault() == null)
            {
                return new Response<Order>()
                {
                    Status = System.Net.HttpStatusCode.NoContent,
                    Message = "Id Not found"
                };
            };

            var order = orderQuery.FirstOrDefault();
            _deleteOrderEntry(order);


            order._DeletedFlag = true;
            order._DeletedDate = DateUtils.GetDateNow();
            order.DeletedBy = Constant.Data.SYSTEM;



            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
            return new Response<Order>();
        }

        private void _deleteOrderEntry(Order request)
        {
            var orderEntries = _context.OrderEntry.Where(p => p.OrderId == request.Id);
            foreach(var order in orderEntries)
            {
                order._DeletedFlag = true;
                order._DeletedDate = DateUtils.GetDateNow();
                order.DeletedBy = Constant.Data.SYSTEM;
                _context.Entry(order).State = EntityState.Modified;
            }

            _context.SaveChanges();
        }
    }
}
