using FrontendModels;
using MauiRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class RatingsViewModel : BaseViewModels
    {
        public ObservableCollection<Rating> ratings{ get; set; }
        UserRepository userRepository {  get; set; }
        RatingsRepository RatingsRepository { get; set; }
        public Command profile { get; set; }
        public Command gotoratings { get; set; }
        public Command home { get; set; }
        public Command settings { get; set; }
        public RatingsViewModel() 
        {
            RatingsRepository = new RatingsRepository();
            userRepository = new UserRepository();
            GetRating();
            profile = new Command(Profile);
            home = new Command(Home);
            gotoratings = new Command(Ratings);
            settings = new Command(Settings);
        }
        public async void GetRating()
        {
            int userId = Convert.ToInt32(await SecureStorage.GetAsync("userId"));
            ratings = new ObservableCollection<Rating>();
            List<Rating> allRatings = await RatingsRepository.GetRatingsAsync(userId);
            foreach (Rating rating in allRatings)
            {
                ratings.Add(rating);
            }
            OnPropChanged(nameof(ratings));
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
