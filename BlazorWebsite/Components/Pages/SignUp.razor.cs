using BlazorRepository;
using BlazorWebsite.Utils;
using FrontendModels;
using Microsoft.AspNetCore.Components;

namespace BlazorWebsite.Components.Pages
{
    partial class SignUp
    {
        private User user { get; set; }
        private string password { get; set; }
        private string repeatedPassword { get; set; }
        private bool signUpFailed { get; set; }
        private string errorMsg { get; set; }
        [Inject]
        protected IUserRepository userRepo {  get; set; }
        private LocalStorageHelper localStorageHelper;
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
                    localStorageHelper = new LocalStorageHelper(JS);
                    try
                    {
                        user = await userRepo.LogInUserAsync(user.UserInfo.Email, password);
                    }
                    catch (Exception e)
                    {
                        await RunErrorMsgAsync(e.Message);
                    }
                    if (user != null)
                    {
                        await localStorageHelper.SaveAsync("userId", user.Id.ToString());
                        navigationManager.NavigateTo("/");
                    }
                }
                else
                {
                    await RunErrorMsgAsync("Kunne ikke oprette bruger, prøv igen");
                }
            }
            else
            {
                await RunErrorMsgAsync("Oplysningerne er ikke godkendt");
            }
        }
        private async Task RunErrorMsgAsync(string message)
        {
            errorMsg = message;
            signUpFailed = true;
            StateHasChanged();
            ErrorTimeMessageAsync();
        }
        private async void ErrorTimeMessageAsync()
        {
            await Task.Delay(5000);
            signUpFailed = false;
            StateHasChanged();
        }
        private void GoToLogIn()
        {
            navigationManager.NavigateTo("/Login");
        }
    }
}