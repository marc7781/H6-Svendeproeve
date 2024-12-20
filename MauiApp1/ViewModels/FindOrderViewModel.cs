﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using FrontendModels;
using MauiApp1.Views;
using MauiRepository;
using Plugin.LocalNotification;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MauiApp1.ViewModels
{
    public class FindOrderViewModel : BaseViewModels
    {
        OrderRepository orderRepository {  get; set; }
        public ObservableCollection<Order> orders { get; set; }
        public List<Order> allOrders { get; set; }
        public Command profile {  get; set; }
        public Command ratings { get; set; }
        public Command home {  get; set; }
        public Command settings { get; set; }
        public Command tagOrder { get; set; }
        public FindOrderViewModel()
        {
            orderRepository = new OrderRepository();
            GetOrder();
            profile = new Command(Profile);
            home = new Command(Home);
            ratings = new Command(Ratings);
            settings = new Command(Settings);
            tagOrder = new Command<Order>(TagOrder);
            LocalNotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;
        }
        private async void GetOrder()
        {
            Location location = await Geolocation.Default.GetLocationAsync();
            orders = new ObservableCollection<Order>();
            allOrders = await orderRepository.GetOrdersAsync();
            for (int i = 0; i < allOrders.Count; i++)
            {
                IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(allOrders[i].Address);
                Location orderLocation = locations?.FirstOrDefault();
                allOrders[i].Distance = GetDistance(location.Latitude, location.Longitude, orderLocation.Latitude, orderLocation.Longitude);
                orders.Add(allOrders[i]);
            }
            orders.OrderBy(o => o.Distance).ToList();
            OnPropChanged(nameof(orders));
        }
        private int GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            int R = 6371; // Radius of the earth in km
            double dLat = deg2rad(lat2 - lat1);  // deg2rad below
            double dLon = deg2rad(lon2 - lon1);
            double a =
              Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) *
              Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
              ;
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c; // Distance in km
            return Convert.ToInt32(d);
        }
        private double deg2rad(double deg)
        {
            return deg * (Math.PI / 180);
        }
        private async void TagOrder(Order order)
        {
            await Shell.Current.ShowPopupAsync(new FindOrderPopUp(order));
        }
        private async void Current_NotificationActionTapped(Plugin.LocalNotification.EventArgs.NotificationActionEventArgs e)
        {
            Order noticationOrder;
            string test = e.Request.ReturningData;
            noticationOrder = JsonConvert.DeserializeObject<Order>(test);
            await Shell.Current.Navigation.PushModalAsync(new InspectOrder(noticationOrder));
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
