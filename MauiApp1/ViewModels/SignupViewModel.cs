using MauiRepository;
using FrontendModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class SignupViewModel : BaseViewModels
    {
        public string name {  get; set; }
        public string mail { get; set; }
        public int phonenumber { get; set; }
        public string password { get; set; }
        public string repeatedpassword { get; set; }
        public Command login { get; set; }
        public Command signUp { get; set; }
        public UserRepository UserRepository { get; set; }
        public SignupViewModel() 
        {
            login = new Command(Login);
            signUp = new Command(SignUp);
            UserRepository = new UserRepository();
        }
        private async void Login()
        {
            await Shell.Current.GoToAsync("//Login");
        }
        private async void SignUp()
        {
            if (string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(repeatedpassword) || string.IsNullOrWhiteSpace(name))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please fill in all fields", "ok");
                return;
            }
            else if (password != repeatedpassword)
            {
                await App.Current.MainPage.DisplayAlert("Error", "make sure the password are the same", "ok");
                return;
            }
            else if (!(password.Length >= 8 && ContainsUppercaseLetter(password) && ContainsNumber(password)))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Password must be 8 characters long and contain at least one uppercase letter and one number.", "ok");
                return;
            }
            User user = new User
            {
                Driver = true,
                UserCredentials = new UserCredentials
                {
                    Password = BCrypt.Net.BCrypt.HashPassword(password),
                },
                UserInfo = new UserInfo
                {
                    Name = name,
                    Email = mail,
                    Phone_number = phonenumber,
                },
                TruckTypeId = 0,
            };
            bool created = await UserRepository.CreateUserAsync(user);
            if (created)
            {
                User createdUser = await UserRepository.GetUserAsync(mail);
                await SecureStorage.Default.SetAsync("userId", createdUser.Id.ToString());
                await Shell.Current.GoToAsync("//Ordre");
            }
        }
        private bool ContainsUppercaseLetter(string password)
        {
            return password.Any(char.IsUpper);
        }
        private bool ContainsNumber(string password)
        {
            return password.Any(char.IsDigit);
        }
    }
}
