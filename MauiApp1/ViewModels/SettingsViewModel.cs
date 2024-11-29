using FrontendModels;
using MauiRepository;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Behaviors;

namespace MauiApp1.ViewModels
{
    public class SettingsViewModel : BaseViewModels
    {
        public string name {  get; set; }
        public string nummer { get; set; }
        public string password { get; set; }
        public string repeatPassword { get; set; }
        public int truckId { get; set; }
        public User user { get; set; }
        public Command profile { get; set; }
        public Command ratings { get; set; }
        public Command home { get; set; }
        public Command settings { get; set; }
        public Command save { get; set; }
        public Command logout { get; set; }
        
        public List<TruckType> trucks { get; set; }
        private TruckType selectedTruck;
        public TruckType SelectedTruck { get; set; }
        //{
        //    get => selectedTruck;
        //    set
        //    {
        //        if (selectedTruck != value)
        //        {
        //            selectedTruck = value;
        //        }
        //    }
        //}
        UserRepository userRepository { get; set; }
        TruckRepository truckRepository { get; set; }
        public SettingsViewModel() 
        {
            userRepository = new UserRepository();
            truckRepository = new TruckRepository();
            profile = new Command(Profile);
            home = new Command(Home);
            ratings = new Command(Ratings);
            settings = new Command(Settings);
            save = new Command(Save);
            logout = new Command(Logout);
            GetInfo();
        }
        private async void GetInfo()
        {
            int id = Convert.ToInt32(await SecureStorage.GetAsync("userId"));
            user = await userRepository.GetUserAsync(id);
            name = user.UserInfo.Name;
            nummer = user.UserInfo.Phone_number.ToString();
            trucks = await truckRepository.GetAllTrucksAsync();
            if (user.TruckTypeId > 0)
            {
                for (int i = 0; i < trucks.Count; i++)
                {
                    if (user.TruckTypeId == trucks[i].Id)
                    {
                        SelectedTruck = trucks[i];
                        OnPropChanged(nameof(SelectedTruck));
                    }
                }
            }
            OnPropChanged(nameof(trucks));
            OnPropChanged(nameof(name));
            OnPropChanged(nameof(nummer));
        }
        private async void Save()
        {
            user.TruckTypeId = SelectedTruck.Id;
            user.UserInfo.Name = name;
            user.UserInfo.Phone_number = Convert.ToInt32(nummer);
            if (password != null && repeatPassword != null && password == repeatPassword)
            {
                user.UserCredentials.Password = BCrypt.Net.BCrypt.HashPassword(password);
            }
            await userRepository.UpdateUserAync(user);
            await Shell.Current.GoToAsync("//Ordre");
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
        private async void Logout()
        {
            SecureStorage.Default.Remove("userId");
            await Shell.Current.GoToAsync("//Login");
        }
    }
}
