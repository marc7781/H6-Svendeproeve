using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class SignupViewModel : BaseViewModels
    {
        public Command login { get; set; }
        public SignupViewModel() 
        {
            login = new Command(Login);
        }
        private async void Login()
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}
