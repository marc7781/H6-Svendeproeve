using BackendModels;
using FrontendModels;
using MauiDBlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiRepository
{
    public class RatingsRepository
    {
        DBAccess db;
        public RatingsRepository() 
        {
            db = new DBAccess();
        }
        public async Task<List<Rating>> GetRatingsAsync(int userId)
        {
            List<DtoRating> dtoRatings = await db.GetRatingAsync(userId);
            List<Rating> ratings = new List<Rating>();
            foreach (DtoRating dtoRating in dtoRatings)
            {
                Rating rating = new Rating
                {
                    Id = dtoRating.Id,
                    Ratings = dtoRating.Ratings,
                    Reason = dtoRating.Reason,
                    SenderId = dtoRating.SenderId,
                    Sender = new User
                    {
                        Id = dtoRating.Sender.Id,
                        UserInfo = new UserInfo
                        {
                            Id = dtoRating.Sender.UserInfo.Id,
                            Name = dtoRating.Sender.UserInfo.Name,
                        },
                    },
                    ReceiverId = dtoRating.ReceiverId,
                };
                ratings.Add(rating);
            }
            return ratings;
        }
        public async Task<bool> CreateRatingAsync(Rating rating)
        {
            DtoRating dtoRating = new DtoRating
            {
                Id = rating.Id,
                Ratings = rating.Ratings,
                Reason = rating.Reason,
                ReceiverId = rating.ReceiverId,
                SenderId = rating.SenderId,
            };
            return await db.CreateRatingAsync(dtoRating);
        }
    }
}
