﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorDBAccess;
using FrontendModels;
using BackendModels;

namespace BlazorRepository
{
    public class OrderRepository
    {
        public DBAccess db { get; set; }
        public OrderRepository()
        {
            db = new DBAccess();
        }
        public async Task<bool> CreateOrderAsync(Order createdOrder)
        {
            if(createdOrder != null)
            {
                createdOrder.TruckTypeId = 1;
                return await db.CreateOrderAsync(ConvertOrderToDto(createdOrder));
            }
            return false;
        }
        public async Task<List<Order>> GetOrdersFromOwnerIdAsync(int ownerId)
        {
            List<DtoOrder> dtoOrders = await db.GetOrdersFromOwnerIdAsync(ownerId);
            if(dtoOrders != null)
            {
                List<Order> orders = new List<Order>();
                foreach (DtoOrder dtoOrder in dtoOrders)
                {
                    orders.Add(ConvertDtoToOrder(dtoOrder));
                }
                return orders;
            }
            return null;
        }




        #region ConvertModels

        private DtoOrder ConvertOrderToDto(Order order)
        {
            DtoOrder dto = new DtoOrder
            {
                Id = order.Id,
                Description = order.Description,
                Destination = order.Destination,
                Address = order.Address,
                Weight = order.Weight,
                Size = order.Size,
                Price = order.Price,
                ExpirationDate = order.ExpirationDate,
                ImageUrl = order.ImageUrl,
                OwnerId = order.OwnerId,
                TruckTypeId = order.TruckTypeId
            };
            return dto;
        }
        private Order ConvertDtoToOrder(DtoOrder dto)
        {
            Order order = new Order
            {
                Id = dto.Id,
                Description = dto.Description,
                Destination = dto.Destination,
                Address = dto.Address,
                Weight = dto.Weight,
                Size = dto.Size,
                Price = dto.Price,
                ExpirationDate = dto.ExpirationDate,
                ImageUrl = dto.ImageUrl,
                OwnerId = dto.OwnerId,
                TruckTypeId = dto.TruckTypeId
            };
            return order;
        }

        #endregion
    }
}