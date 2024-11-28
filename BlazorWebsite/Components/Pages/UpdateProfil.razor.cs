using BlazorRepository;
using BlazorWebsite.Utils;
using FrontendModels;
using Microsoft.AspNetCore.Components;

namespace BlazorWebsite.Components.Pages
{
    partial class UpdateProfil
    {
        private User user {  get; set; }
        private string currentPassword { get; set; }
        private string newPassword { get; set; }
        private string repeatedPassword { get; set; }
        [Inject]
        protected IUserRepository userRepo {  get; set; }
        private LocalStorageHelper localStorageHelper;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                localStorageHelper = new LocalStorageHelper(JS);
                userRepo = new UserRepository();
                try
                {
                    int userId = Convert.ToInt32(await localStorageHelper.GetAsync("userId"));
                    user = await userRepo.GetUserFromIdAsync(userId);
                }
                catch
                {
                    //error happend from getting user from localStorage
                    navigationManager.NavigateTo("/Login");
                    return;
                }
                if (user == null)
                {
                    navigationManager.NavigateTo("/Login");
                    return;
                }
                StateHasChanged();
            }
        }
        private void SubmitUpdate()
        {

        }
    }
}