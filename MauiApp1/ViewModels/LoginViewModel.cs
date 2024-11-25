using FrontendModels;
using MauiRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class LoginViewModel : BaseViewModels
    {
        public string username { get; set; }
        public string password { get; set; }
        public UserRepository UserRepository { get; set; }
        public Command signup {  get; set; }
        public Command login { get; set; }
        public LoginViewModel() 
        {
            UserRepository = new UserRepository();
            login = new Command(Login);
            signup = new Command(Signup);
        }
        private async void Login()
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please fill in all fields", "ok");
                return;
            }
            try
            {
                User user = await UserRepository.GetUserAsync(username);
                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.UserCredentials.Password))
                {
                    await SecureStorage.Default.SetAsync("userId", user.Id.ToString());

                    await Shell.Current.GoToAsync("//Ordre");
                }
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Username or password is incorrect", "ok");
                return;
            }
        }
        private async void Signup()
        {
            await Shell.Current.GoToAsync("//Signup");
        }
    }
}
