using BlazorRepository;
using BlazorWebsite.Utils;
using FrontendModels;
using Microsoft.AspNetCore.Components;
using System.Data;

namespace BlazorWebsite.Components.Pages
{
    partial class Home
    {
        private User user { get; set; }
        private User clickedDriver { get; set; }
        private int averageRating { get; set; }
        private List<Order> activeOrders { get; set; }
        [Inject]
        protected IOrderRepository orderRepo { get; set; }
        [Inject]
        protected IUserRepository userRepo { get; set; }
        [Inject]
        protected IRatingRepository RatingRepo { get; set; }
        private LocalStorageHelper localStorageHelper { get; set; }
        private bool activateInspector = false; 
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
        private async Task InspectDriverAsync(int? driverId)
        {
            if(driverId != null)
            {
                clickedDriver = await userRepo.GetUserFromIdAsync((int)driverId);
                List<Rating> driversRatings;
                driversRatings = await RatingRepo.GetUsersRatingFromIdAsync((int)driverId);
                if(driversRatings != null)
                {
                    int allStars = 0;
                    foreach (Rating rating in driversRatings) 
                    {
                        allStars += rating.Ratings;
                    }
                    averageRating = allStars / driversRatings.Count;

                }
                activateInspector = true;
                StateHasChanged();
            }
        }
        private void CloseInspector()
        {
            activateInspector = false;
            StateHasChanged();
        }
        private void GoToWriteRating(int userId)
        {
            navigationManager.NavigateTo($"/createrating/{userId}");
        }
        private void GoToCreate()
        {
            navigationManager.NavigateTo("/CreateOrder");
        }
        private void GoToUpdate(int orderId)
        {
            navigationManager.NavigateTo($"/UpdateOrder/{orderId}");
        }
        private void GoToWatchRatings()
        {
            navigationManager.NavigateTo("/watchratings");
        }
    }
}
