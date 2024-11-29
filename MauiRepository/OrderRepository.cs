using FrontendModels;
using BackendModels;
using MauiDBlayer;
namespace MauiRepository
{
    public class OrderRepository
    {
        DBAccess db;
        public OrderRepository()
        {
            db = new DBAccess();
        }
        public async Task<List<Order>> GetOrdersAsync()
        {
            List<DtoOrder> dtoOrders = await db.GetOrderAsync();
            List<Order> orders = new List<Order>();
            foreach (DtoOrder dtoOrder in dtoOrders) 
            { 
                Order order = new Order
                {
                    Id = dtoOrder.Id,
                    Description = dtoOrder.Description,
                    Destination = dtoOrder.Destination,
                    Address = dtoOrder.Address,
                    Weight = dtoOrder.Weight,
                    Size = dtoOrder.Size,
                    Price = dtoOrder.Price,
                    ExpirationDate = dtoOrder.ExpirationDate,
                    ImageUrl = dtoOrder.ImageUrl,
                    OwnerId = dtoOrder.OwnerId,
                    TruckTypeId = dtoOrder.TruckTypeId,
                    //TruckType = new TruckType
                    //{
                    //    Trucktype = dtoOrder.TruckType.Trucktype,
                    //}
                }; 
                orders.Add(order);
            }
            return orders;
        }
        public async Task<List<Order>> GetOrdersForDriverAsync(int driverId)
        {
            List<DtoOrder> dtoOrders = await db.GetOrdersForDriverAsync(driverId);
            List<Order> orders = new List<Order>();
            foreach (DtoOrder dtoOrder in dtoOrders)
            {
                Order order = new Order
                {
                    Id = dtoOrder.Id,
                    Description = dtoOrder.Description,
                    Destination = dtoOrder.Destination,
                    Address = dtoOrder.Address,
                    Weight = dtoOrder.Weight,
                    Size = dtoOrder.Size,
                    Price = dtoOrder.Price,
                    ExpirationDate = dtoOrder.ExpirationDate,
                    ImageUrl = dtoOrder.ImageUrl,
                    OwnerId = dtoOrder.OwnerId,
                    DriverId = driverId,
                    TruckTypeId = dtoOrder.TruckTypeId,
                    //TruckType = new TruckType
                    //{
                    //    Trucktype = dtoOrder.TruckType.Trucktype,
                    //}
                };
                orders.Add(order);
            }
            return orders;
        }
        public async Task<bool> UpdateOrderAsync(Order order)
        {
            DtoOrder dtoOrder = new DtoOrder
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
                DriverId = (int)order.DriverId,
                TruckTypeId = order.TruckTypeId,
            };
            return await db.UpdateOrderAsync(dtoOrder);
        }
        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            return await db.DeleteOrderAsync(orderId);
        }
    }
}
