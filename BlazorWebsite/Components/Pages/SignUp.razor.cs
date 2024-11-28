using BlazorRepository;
using FrontendModels;
using Microsoft.AspNetCore.Components;

namespace BlazorWebsite.Components.Pages
{
    partial class SignUp
    {
        private User user { get; set; }
        private string password { get; set; }
        private string repeatedPassword { get; set; }
        [Inject]
        protected IUserRepository userRepo {  get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                user = new User();
                user.UserInfo = new UserInfo();
                user.UserCredentials = new UserCredentials();
                userRepo = new UserRepository();
                StateHasChanged();
            }
        }
        private async void SignUserUp()
        {
            if(password == repeatedPassword)
            {
                user.UserCredentials.Password = password;
            }
            if(await userRepo.SignUserUpAsync(user))
            {
                //it worked
            }
            else
            {
                //it didn't work
            }
        }
    }
}