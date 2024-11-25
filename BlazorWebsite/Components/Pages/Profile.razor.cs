using BlazorRepository;
using FrontendModels;

namespace BlazorWebsite.Components.Pages
{
    partial class Profile
    {
        private User user {  get; set; }
        private List<Order> activeOrders { get; set; }
        private OrderRepository orderRepo { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                orderRepo = new OrderRepository();
                activeOrders = await orderRepo.GetOrdersFromOwnerIdAsync(user.Id);
                StateHasChanged();
            }
        }
    }
}
