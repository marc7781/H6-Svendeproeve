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
                    //TruckType = new TruckType
                    //{
                    //    Trucktype = dtoOrder.TruckType.Trucktype,
                    //}
                }; 
                orders.Add(order);
            }
            return orders;
        }
    }
}
