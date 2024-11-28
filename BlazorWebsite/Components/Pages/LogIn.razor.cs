﻿using BlazorRepository;
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
                navigationManager.NavigateTo("/Profile");
                //log user in
            }

        }
        private async Task RunErrorMsgAsync(string msg)
        {

        } 
    }
}