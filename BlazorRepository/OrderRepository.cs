using System;
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
                return await db.CreateOrderAsync(ConvertOrderToDto(createdOrder));
            }
            return false;
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

        #endregion
    }
}