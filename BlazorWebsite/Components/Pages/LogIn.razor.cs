using BlazorRepository;
using BlazorWebsite.Utils;
using FrontendModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWebsite.Components.Pages
{
    partial class LogIn
    {
        private User user { get; set; }
        private string mail { get; set; }
        private string password { get; set; }
        private bool logInFailed { get; set; }
        private string errorMsg { get; set; }
        [Inject]
        protected IUserRepository userRepo { get; set; }
        private LocalStorageHelper localStorageHelper;
        
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                userRepo = new UserRepository();
                StateHasChanged();
            }
        }
        private async void LogUserInAsync()
        {
            localStorageHelper = new LocalStorageHelper(JS);
            try
            {
                user = await userRepo.LogInUserAsync(mail, password);
            }
            catch (Exception e)
            {
                await RunErrorMsgAsync(e.Message);
            }
            if (user != null)
            {
                await localStorageHelper.SaveAsync("userId", user.Id.ToString());
                navigationManager.NavigateTo("/");
                //log user in
            }

        }
        private async Task RunErrorMsgAsync(string message)
        {
            errorMsg = message;
            logInFailed = true;
            StateHasChanged();
            ErrorTimeMessageAsync();
        }
        private async void ErrorTimeMessageAsync()
        {
            await Task.Delay(5000);
            logInFailed = false;
            StateHasChanged();
        }
        private void GoToSignUp()
        {
            navigationManager.NavigateTo("/signup");
        }
    }
}