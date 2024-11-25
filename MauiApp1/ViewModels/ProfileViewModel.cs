using FrontendModels;
using MauiRepository;
using System.Collections.ObjectModel;
using MauiApp1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class ProfileViewModel : BaseViewModels
    {
        OrderRepository orderRepository { get; set; }
        public ObservableCollection<Order> orders { get; set; }
        public List<Order> allOrders { get; set; }
        public Command profile { get; set; }
        public Command ratings { get; set; }
        public Command home { get; set; }
        public Command logout { get; set; }
        public ProfileViewModel() 
        {
            orderRepository = new OrderRepository();
            GetOrder();
            profile = new Command(Profile);
            home = new Command(Home);
            ratings = new Command(Ratings);
            logout = new Command(Logout);
        }
        private async void GetOrder()
        {
            orders = new ObservableCollection<Order>();

        }
        private async void Profile()
        {
            await Shell.Current.GoToAsync("//Profile", false);
        }
        private async void Home()
        {
            await Shell.Current.GoToAsync("//Order");
        }
        private async void Ratings()
        {
            await Shell.Current.GoToAsync("//Ratings");
        }
        private async void Logout()
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}
