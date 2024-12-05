using BlazorRepository;
using BlazorWebsite.Utils;
using FrontendModels;
using Microsoft.AspNetCore.Components;

namespace BlazorWebsite.Components.Pages
{
    partial class CreateRating
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        protected IUserRepository userRepo { get; set; }
        [Inject]
        protected IRatingRepository ratingRepo { get; set; }
        private LocalStorageHelper localStorageHelper;
        private User driver { get; set; }
        private Rating rating { get; set; }
        private int senderId;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                rating = new Rating();
                rating.Ratings = 1;
                localStorageHelper = new LocalStorageHelper(JS);
                try
                {
                    senderId = Convert.ToInt32(await localStorageHelper.GetAsync("userId"));
                }
                catch
                {
                    navigationManager.NavigateTo("/Login");
                }
                if (senderId == 0)
                {
                    navigationManager.NavigateTo("/Login");
                }
                driver = await userRepo.GetUserFromIdAsync(Id);
                StateHasChanged();
            }
        }
        private void ChangeRatingValue(int newValue)
        {
            rating.Ratings = (newValue + 1);
            StateHasChanged(); 
        }
        private async Task CreateRatingAsync()
        {
            rating.SenderId = senderId;
            rating.ReceiverId = Id;
            bool checkIfSucces = false;
            try
            {
                checkIfSucces = await ratingRepo.CreateRatingAsync(rating);
            }
            catch
            {
                checkIfSucces = false;
            }
            if(checkIfSucces)
            {
                navigationManager.NavigateTo("/");
            }
        }
        private void CancelRating()
        {
            navigationManager.NavigateTo("/");
        }
    }
}
