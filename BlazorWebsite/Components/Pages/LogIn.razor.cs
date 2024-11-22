using BlazorRepository;
using FrontendModels;

namespace BlazorWebsite.Components.Pages
{
    partial class LogIn
    {
        private User user { get; set; }
        private string mail { get; set; }
        private string password { get; set; }
        private UserRepository userRepo { get; set; }
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
                //log user in
            }

        }
        private async Task RunErrorMsgAsync(string msg)
        {

        } 
    }
}