using BlazorRepository;
using BlazorWebsite.Utils;
using FrontendModels;
using Microsoft.AspNetCore.Components;

namespace BlazorWebsite.Components.Pages
{
    partial class Home
    {
        private User user { get; set; }
        private List<Order> activeOrders { get; set; }
        [Inject]
        protected IOrderRepository orderRepo { get; set; }
        [Inject]
        protected IUserRepository userRepo { get; set; }
        private LocalStorageHelper localStorageHelper { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                localStorageHelper = new LocalStorageHelper(JS);
                orderRepo = new OrderRepository();
                userRepo = new UserRepository();
                try
                {
                    int userId = Convert.ToInt32(await localStorageHelper.GetAsync("userId"));
                    user = await userRepo.GetUserFromIdAsync(userId);
                }
                catch
                {
                    //error happend from getting user from localStorage
                    navigationManager.NavigateTo("/Login");
                }
                if (user == null)
                {
                    navigationManager.NavigateTo("/Login");
                    return;
                }
                activeOrders = await orderRepo.GetOrdersFromOwnerIdAsync(user.Id);
                StateHasChanged();
            }
        }
        private void GoToCreate()
        {
            navigationManager.NavigateTo("/CreateOrder");
        }
        private void GoToUpdate(int orderId)
        {
            navigationManager.NavigateTo($"/UpdateOrder/{orderId}");
        }
    }
}
