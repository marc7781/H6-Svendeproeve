using BlazorRepository;
using FrontendModels;

namespace BlazorWebsite.Components.Pages
{
    partial class SignUp
    {
        private User user { get; set; }
        private string password { get; set; }
        private string repeatedPassword { get; set; }
        private UserRepository userRepo {  get; set; }
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
            await userRepo.SignUserUpAsync(user);
        }
    }
}