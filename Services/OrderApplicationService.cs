﻿using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using CoffeShop.Models;
using CoffeShop.Models.Request;
using CoffeShop.Services.Interface;
using Microsoft.AspNetCore.Mvc;
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


        public async Task<Response<Order>> PlaceOrder(OrderRequest request)
        {
            var order = new Order();
            order.Id = new Guid();
            order.OrderName = "SYSTEM";

            double total = 0;
            List<OrderEntry> orderEntries = new List<OrderEntry>();
            foreach (var temp in request.Orders)
            {
                var orderEntry = new OrderEntry();
                orderEntry.MenuId = temp.MenuId;
                orderEntry.Price = temp.Price;
                orderEntry.Quantity = temp.Quantity;
                orderEntry.OrderId = order.Id;

                orderEntry._CreatedDate = new DateTime();
                orderEntry.CreatedBy = "SYSTEM";
                orderEntry.Id = new Guid();

                total += orderEntry.Price;

                orderEntries.Add(orderEntry);
            }

            order.Total = total;

            _context.Order.Add(order);
            _context.OrderEntry.AddRange(orderEntries);

            await _context.SaveChangesAsync();

            return new Response<Order>();
        }

        private void _SystemAdjustmentList(List<OrderEntry> orderEntry)
        {
            

            throw new NotImplementedException();
        }

        private void _SystemAdjustment(object orderEntries)
        {
            throw new NotImplementedException();
        }

        
    }
}
