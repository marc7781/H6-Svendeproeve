using BlazorDBAccess;
using FrontendModels;

namespace BlazorRepository
{
    public interface IOrderRepository
    {
        Task<bool> CreateOrderAsync(Order createdOrder);
        Task<List<Order>> GetOrdersFromOwnerIdAsync(int ownerId);
    }
}