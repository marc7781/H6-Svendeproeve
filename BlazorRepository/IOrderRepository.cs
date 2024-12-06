using BlazorDBAccess;
using FrontendModels;

namespace BlazorRepository
{
    public interface IOrderRepository
    {
        Task<bool> CreateOrderAsync(Order createdOrder);
        Task<List<Order>> GetOrdersFromOwnerIdAsync(int ownerId);
        Task<Order> GetOrderFromIdAsync(int orderId);
        Task<bool> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int orderId);
    }
}