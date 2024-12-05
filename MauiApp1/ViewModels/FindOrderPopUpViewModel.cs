using CommunityToolkit.Maui.Views;
using FrontendModels;
using MauiApp1.Views;
using MauiRepository;
using Newtonsoft.Json;
using Plugin.LocalNotification;
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

        private async void Confirm(object result)
        {
            Popup popup = result as Popup;
            Order.DriverId = Convert.ToInt32(await SecureStorage.Default.GetAsync("userId"));
            if (newPrice == false)
            {
                Order.Pending = false;
                await OrderRepository.UpdateDriverOrderAsync(Order);
                SendNotification();
                popup.Close();
            }
            else
            {
                Order.Pending = true;
                await OrderRepository.UpdatePriceOrderAsync(Order);
                popup.Close();
            }
        }
        private async void ChangePrice()
        {
            if (price != Order.Price && price != 0)
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
        private void SendNotification()
        {
            string json = JsonConvert.SerializeObject(Order);
            var request = new NotificationRequest
            {
                NotificationId = 1000,
                Title = "Ordren er nu gået i gennem",
                Subtitle = "",
                ReturningData = json,
                Description = "",
                BadgeNumber = 42,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                    NotifyRepeatInterval = TimeSpan.FromMinutes(1),
                    RepeatType = NotificationRepeat.TimeInterval,
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
    }
}
