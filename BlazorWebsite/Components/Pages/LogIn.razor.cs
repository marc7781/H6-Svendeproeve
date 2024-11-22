using FrontendModels;

namespace BlazorWebsite.Components.Pages
{
    partial class LogIn
    {
        private User user { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                user = new User();
                user.UserInfo = new UserInfo();
                user.UserCredentials = new UserCredentials();
                StateHasChanged();
            }
        }
    }
}