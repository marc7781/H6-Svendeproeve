using ApiDBlayer;
using DbModels;
using FrontendModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class RatingRepository
    {
        Database db;
        public RatingRepository()
        {
            db = new Database();
        }
        public async Task<Rating> GetRatingAsync(int ratingid)
        {
            DtoRating dtoRating = new DtoRating();
            dtoRating = await db.Rating.FirstOrDefaultAsync(x => x.Id == ratingid);
            Rating rating = new Rating
            {
                Id = dtoRating.Id,
                Ratings = dtoRating.Ratings,
                Reason = dtoRating.Reason,
                SenderId = dtoRating.SenderId,
                ReceiverId = dtoRating.ReceiverId,
            };
            return rating;
        }
        public async Task<List<Rating>> GetAllUsersRatingsAsync(int userId)
        {
            List<DtoRating> dtoRatings = await db.Rating.Where(x => x.Receiver.Id == userId).Include(x => x.Sender).ThenInclude(x => x.UserInfo).ToListAsync();
            if(dtoRatings != null)
            {
                List<Rating> usersRatings = new List<Rating>();
                foreach (DtoRating dto in dtoRatings)
                {
                    Rating rating = new Rating
                    {
                        Id = dto.Id,
                        Ratings = dto.Ratings,
                        Reason = dto.Reason,
                        SenderId = dto.SenderId,
                        Sender = new User
                        {
                            Id = dto.Sender.Id,
                            UserInfo = new UserInfo
                            {
                                Name = dto.Sender.UserInfo.Name
                            }
                        },
                        ReceiverId = dto.ReceiverId,
                    };
                    usersRatings.Add(rating);
                }
                return usersRatings;
            }
            return null;
        } 
        public async Task<List<Rating>> GetAllRatingAsync()
        {
            List<DtoRating> dtoRatings = new List<DtoRating>();
            dtoRatings = await db.Rating.Include(x => x.Sender).ThenInclude(x => x.UserInfo).ToListAsync();
            List<Rating> Ratings = new List<Rating>();
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
                Ratings.Add(rating);
            }
            return Ratings;
        }
        public async Task<bool> CreateRatingAsync(Rating rating)
        {
            DtoRating dtoRating = new DtoRating
            {
                Id = rating.Id,
                Ratings = rating.Ratings,
                Reason = rating.Reason,
                SenderId = rating.SenderId,
                ReceiverId = rating.ReceiverId,
            };
            await db.Rating.AddAsync(dtoRating);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
