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
        private bool ValidateInfo()
        {
            if(string.IsNullOrEmpty(user.UserInfo.Name) && user.UserInfo.Name.Length < 4)
            {
                return false;
            }
            if (string.IsNullOrEmpty(user.UserInfo.Email) && user.UserInfo.Email.Length < 5 && user.UserInfo.Email.Contains('@'))
            {
                return false;
            }
            if (user.UserInfo.Phone_number < 9999999 && user.UserInfo.Phone_number > 100000000)
            {
                return false;
            }
            if (string.IsNullOrEmpty(user.UserInfo.Address) && user.UserInfo.Address.Length < 4)
            {
                return false;
            }
            return true;
        }
        private async void SignUserUp()
        {
            if(ValidateInfo())
            {
                if (password == repeatedPassword)
                {
                    user.UserCredentials.Password = password;
                }
                if (await userRepo.SignUserUpAsync(user))
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
}