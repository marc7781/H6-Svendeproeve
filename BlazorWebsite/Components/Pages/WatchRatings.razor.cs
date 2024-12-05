using BlazorRepository;
using BlazorWebsite.Utils;
using FrontendModels;
using Microsoft.AspNetCore.Components;

namespace BlazorWebsite.Components.Pages
{
    partial class WatchRatings
    {
        [Inject]
        protected IRatingRepository ratingRepo { get; set; }
        private LocalStorageHelper localStorageHelper;
        private int userId { get; set; }
        private List<Rating> usersRatings { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                localStorageHelper = new LocalStorageHelper(JS);
                try
                {
                    userId = Convert.ToInt32(await localStorageHelper.GetAsync("userId"));
                }
                catch
                {
                    navigationManager.NavigateTo("/Login");
                }
                if (userId == 0)
                {
                    navigationManager.NavigateTo("/Login");
                }
                try
                {
                    usersRatings = await ratingRepo.GetUsersRatingFromIdAsync(userId);
                }
                catch
                {

                }
                StateHasChanged();
            }
        }
        private void GoToMainPage()
        {
            navigationManager.NavigateTo("/");
        }
    }
}
