using FrontendModels;
using MauiRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public class CreateRatingsViewModel : BaseViewModels
    {
        public string reason {  get; set; }
        public int stars { get; set; }
        private int receiver {  get; set; }
        public Command setStars {  get; set; }
        public Command profile { get; set; }
        public Command gotoratings { get; set; }
        public Command home { get; set; }
        public Command settings { get; set; }
        public Command send { get; set; }
        RatingsRepository RatingsRepository { get; set; }
        public CreateRatingsViewModel(int userId) 
        {
            receiver = userId;
            setStars = new Command(SetStars);
            profile = new Command(Profile);
            home = new Command(Home);
            gotoratings = new Command(Ratings);
            settings = new Command(Settings);
            send = new Command(Send);
            RatingsRepository = new RatingsRepository();
        }
        private async void Send()
        {
            Rating rating = new Rating
            {
                Reason = reason,
                Ratings = stars,
                ReceiverId = receiver,
                SenderId = Convert.ToInt32(await SecureStorage.GetAsync("userId")),
            };
            await RatingsRepository.CreateRatingAsync(rating);
            await Shell.Current.GoToAsync("//Profile");
        }
        private void SetStars(object obj) 
        {
            stars = Convert.ToInt32(obj);
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
