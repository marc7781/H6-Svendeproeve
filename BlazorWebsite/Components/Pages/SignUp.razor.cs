using FrontendModels;

namespace BlazorWebsite.Components.Pages
{
    partial class SignUp
    {
        private User user { get; set; }
        private string password { get; set; }
        private string repeatedPassword { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                user = new User();
                user.UserInfo = new UserInfo();
                user.UserCredentials = new UserCredentials();
                StateHasChanged();
            }
        }
    }
}