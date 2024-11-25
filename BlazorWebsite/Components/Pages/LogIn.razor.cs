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
        private UserRepository userRepo { get; set; }
        private DotNetObjectReference<LocalStorageHelper> localStorageHelper;
        
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                localStorageHelper = DotNetObjectReference.Create(new LocalStorageHelper(JS));
                userRepo = new UserRepository();
                StateHasChanged();
            }
        }
        private async void LogUserInAsync()
        {
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
                await localStorageHelper.Value.SaveAsync("id", user.Id.ToString());
                navigationManager.NavigateTo("/Profile");
                //log user in
            }

        }
        private async Task RunErrorMsgAsync(string msg)
        {

        } 
    }
}