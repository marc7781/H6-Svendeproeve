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
        public async Task<List<Rating>> GetAllRatingAsync()
        {
            List<DtoRating> dtoRatings = new List<DtoRating>();
            dtoRatings = await db.Rating.ToListAsync();
            List<Rating> Ratings = new List<Rating>();
            foreach (DtoRating dtoRating in dtoRatings)
            {
                Rating rating = new Rating
                {
                    Id = dtoRating.Id,
                    Ratings = dtoRating.Ratings,
                    Reason = dtoRating.Reason,
                    SenderId = dtoRating.SenderId,
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
