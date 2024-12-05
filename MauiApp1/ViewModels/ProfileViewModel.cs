using FrontendModels;
using MauiRepository;
using System.Collections.ObjectModel;
using MauiApp1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiApp1.ViewModels
{
    public class ProfileViewModel : BaseViewModels
    {
        OrderRepository orderRepository { get; set; }
        UserRepository userRepository { get; set; }
        public User user { get; set; }
        public ObservableCollection<Order> orders { get; set; }
        public List<Order> allOrders { get; set; }
        Order selectedOrder;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                if (selectedOrder != value)
                {
                    selectedOrder = value;
                }
            }
        }
        public Command profile { get; set; }
        public Command ratings { get; set; }
        public Command home { get; set; }
        public Command settings { get; set; }
        public ProfileViewModel() 
        {
            orderRepository = new OrderRepository();
            userRepository = new UserRepository();
            GetOrder();
            profile = new Command(Profile);
            home = new Command(Home);
            ratings = new Command(Ratings);
            settings = new Command(Settings);
        }
        private async void GetOrder()
        {
            int userid = Convert.ToInt32(await SecureStorage.GetAsync("userId"));
            orders = new ObservableCollection<Order>();
            user = await userRepository.GetUserAsync(userid);
            allOrders = await orderRepository.GetOrdersForDriverAsync(userid);
            for (int i = 0; i < allOrders.Count; i++)
            {
                orders.Add(allOrders[i]);
            }
            OnPropChanged(nameof(user));
            OnPropChanged(nameof(orders));
        }

        private async void Profile()
        {
            await Shell.Current.GoToAsync("//Profile", false);
        }
        private async void Home()
        {
            await Shell.Current.GoToAsync("//Ordre");
        }
        private async void Ratings()
        {
            await Shell.Current.GoToAsync("//Ratings");
        }
        private async void Settings()
        {
            await Shell.Current.GoToAsync("//Settings");
        }
    }
}
