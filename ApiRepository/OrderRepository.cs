﻿using System.ComponentModel.DataAnnotations.Schema;
using ApiDBlayer;
using DbModels;
using FrontendModels;
using Microsoft.EntityFrameworkCore;

namespace ApiRepository
{
    public class OrderRepository
    {
        Database db;
        public OrderRepository()
        {
            db = new Database();
        }
        public async Task<Order> GetOneOrderAsync(int orderId)
        {
            DtoOrder dtoOrder = new DtoOrder();
            dtoOrder = await db.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
            Order order = new Order
            {
                Id = dtoOrder.Id,
                Destination = dtoOrder.Destination,
                Address = dtoOrder.Address,
                Size = dtoOrder.Size,
                Price = dtoOrder.Price,
                ExpirationDate = dtoOrder.ExpirationDate,
                ImageUrl = dtoOrder.ImageUrl,
                OwnerId = dtoOrder.OwnerId,
                DriverId = dtoOrder.DriverId,
                TruckTypeId = dtoOrder.TruckTypeId,
            };
            return order;
        }
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            List<DtoOrder> dtoOrders = new List<DtoOrder>();
            dtoOrders = await db.Orders.ToListAsync();
            List<Order> orders = new List<Order>();
            foreach (DtoOrder dtoOrder in dtoOrders)
            {
                Order order = new Order
                {
                    Id = dtoOrder.Id,
                    Destination = dtoOrder.Destination,
                    Address = dtoOrder.Address,
                    Size = dtoOrder.Size,
                    Price = dtoOrder.Price,
                    ExpirationDate = dtoOrder.ExpirationDate,
                    ImageUrl = dtoOrder.ImageUrl,
                    OwnerId = dtoOrder.OwnerId,
                    DriverId = dtoOrder.DriverId,
                    TruckTypeId = dtoOrder.TruckTypeId,
                };
                orders.Add(order);
            }
            return orders;
        }
        public async Task<bool> UpdateOrderAsync(Order order)
        {
            DtoOrder dtoOrder = new DtoOrder
            {
                Id= order.Id,
                Destination = order.Destination,
                Address = order.Address,
                Size = order.Size,
                Price = order.Price,
                ExpirationDate = order.ExpirationDate,
                ImageUrl = order.ImageUrl,
                OwnerId = order.OwnerId,
                DriverId = order.DriverId,
                TruckTypeId = order.TruckTypeId,
            };
            db.Orders.Update(dtoOrder);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            DtoOrder dtoOrder = new DtoOrder();
            dtoOrder = await db.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
            db.Orders.Remove(dtoOrder);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> CreateOrderAsync(Order order)
        {
            DtoOrder dtoOrder = new DtoOrder
            {
                Id = order.Id,
                Description = order.Description,
                Destination = order.Destination,
                Address = order.Address,
                Size = order.Size,
                Price = order.Price,
                ExpirationDate = order.ExpirationDate,
                ImageUrl = order.ImageUrl,
                OwnerId = order.OwnerId,
                DriverId = order.DriverId,
                TruckTypeId = order.TruckTypeId
            };
            await db.Orders.AddAsync(dtoOrder);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
