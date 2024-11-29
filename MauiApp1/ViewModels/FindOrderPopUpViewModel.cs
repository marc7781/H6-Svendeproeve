using CommunityToolkit.Maui.Views;
using FrontendModels;
using MauiRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class FindOrderPopUpViewModel : BaseViewModels
    {
        public int price {  get; set; }
        public Order Order { get; set; }
        public Command confirm {  get; set; }
        public bool newPrice { get; set; }
        public Command changePrice { get; set; }
        public OrderRepository OrderRepository { get; set; }
        public FindOrderPopUpViewModel(Order order) 
        {
            OrderRepository = new OrderRepository();
            Order = order;
            confirm = new Command(Confirm);
            changePrice = new Command(ChangePrice);
        }

        private async void Confirm()
        {
            if (newPrice == false)
            {
                Order.DriverId = Convert.ToInt32(await SecureStorage.Default.GetAsync("userId"));
                await OrderRepository.UpdateOrderAsync(Order);
                await Shell.Current.GoToAsync("//Ordre");
            }
            else
            {
                //sende mail til kunde
            }
        }
        private async void ChangePrice()
        {
            if (price > 0)
            {
                newPrice = true;
            }
            else
            {
                newPrice = false;
            }
            OnPropChanged(nameof(price));
            OnPropChanged(nameof(newPrice));
        }
    }
}
