using FrontendModels;
using MauiRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class InspectOrderViewModel : BaseViewModels
    {
        private int id {  get; set; }
        public string description { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int weight { get; set; }
        public string size { get; set; }
        public int price { get; set; }
        public string name { get; set; }
        OrderRepository orderRepository;
        UserRepository userRepository;
        public Command profile { get; set; }
        public Command ratings { get; set; }
        public Command home { get; set; }
        public Command settings { get; set; }
        public Command report { get; set; }
        public Command complete { get; set; }
        public InspectOrderViewModel(Order order)
        {
            orderRepository = new OrderRepository();
            userRepository = new UserRepository();
            FillOrder(order);
            profile = new Command(Profile);
            home = new Command(Home);
            ratings = new Command(Ratings);
            settings = new Command(Settings);
            report = new Command(Report);
            complete = new Command(Complete);
        }
        public async void FillOrder(Order order)
        {
            User user = await userRepository.GetUserAsync(order.OwnerId);
            id = order.Id;
            name = user.UserInfo.Name;
            description = order.Description;
            from = order.Address;
            to = order.Destination;
            weight = order.Weight;
            size = order.Size;
            price = order.Price;
            OnPropChanged(nameof(name));
            OnPropChanged(nameof(description));
            OnPropChanged(nameof(from));
            OnPropChanged(nameof(to));
            OnPropChanged(nameof(weight));
            OnPropChanged(nameof(size));
            OnPropChanged(nameof(price));
        }
        private async void Report()
        {

        }
        private async void Complete()
        {
            await orderRepository.DeleteOrderAsync(id);
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
