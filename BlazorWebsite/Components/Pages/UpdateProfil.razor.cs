﻿using BlazorRepository;
using BlazorWebsite.Utils;
using FrontendModels;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace BlazorWebsite.Components.Pages
{
    partial class UpdateProfil
    {
        private User user { get; set; }
        private int phoneNumber { get; set; }
        private string address { get; set; }
        private string currentMail { get; set; }
        private string currentPassword { get; set; }
        private string newPassword { get; set; }
        private string repeatedPassword { get; set; }
        [Inject]
        protected IUserRepository userRepo { get; set; }
        private LocalStorageHelper localStorageHelper;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
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
                currentMail = user.UserInfo.Email;
                phoneNumber = user.UserInfo.Phone_number;
                address = user.UserInfo.Address;
                StateHasChanged();
            }
        }
        private bool ValidateInfo()
        {
            if (string.IsNullOrEmpty(currentMail) || currentMail.Length < 4)
            {
                return false;
            }
            if (phoneNumber < 9999999 && phoneNumber > 100000000)
            {
                return false;
            }
            if (string.IsNullOrEmpty(address) || address.Length < 4)
            {
                return false;
            }
            return true;
        }
        private bool ValidateNewPasswords()
        {
            if(!string.IsNullOrEmpty(newPassword))
            {
                if(newPassword.Length > 7 && newPassword == repeatedPassword)
                {
                    return true;
                }
            }
            return false;
        }
        private async void SubmitUpdate()
        {
            if (ValidateInfo())
            {
                if (await userRepo.LogInUserAsync(user.UserInfo.Email, currentPassword) != null)
                {
                    user.UserInfo.Email = currentMail;
                    user.UserInfo.Address = address;
                    user.UserInfo.Phone_number = phoneNumber;
                    bool checkIfSucces = false;
                    if(ValidateNewPasswords())
                    {
                        user.UserCredentials.Password = newPassword;
                        checkIfSucces = await userRepo.UpdateUserAndPasswordAsync(user);
                    }
                    else
                    {
                        checkIfSucces = await userRepo.UpdateUserAsync(user);
                    }
                    if(checkIfSucces)
                    {
                        //it worked
                    }
                }
            }
        }
    }
}