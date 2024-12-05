using BackendModels;
using BlazorDBAccess;
using FrontendModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRepository
{
    public class RatingRepository : IRatingRepository
    {
        private DBAccess db { get; set; }
        public RatingRepository()
        {
            db = new DBAccess();
        }
        public async Task<List<Rating>> GetUsersRatingFromIdAsync(int id)
        {
            List<DtoRating> dtoRatings = null;
            try
            {
                dtoRatings = await db.GetUsersRatingFromIdAsync(id);
            }
            catch
            {
                return null;
            }
            if (dtoRatings != null && dtoRatings.Count != 0)
            {
                List<Rating> ratings = new List<Rating>();
                foreach (DtoRating rating in dtoRatings)
                {
                    ratings.Add(ConvertFromDto(rating));
                }
                return ratings;
            }
            return null;
        }
        public async Task<bool> CreateRatingAsync(Rating rating)
        {
            if (rating != null)
            {
                return await db.CreateRatingAsync(ConvertToDto(rating));
            }
            return false;
        }
        private Rating ConvertFromDto(DtoRating dto)
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
                        Name = dto.Sender.UserInfo.Name,
                    }
                },
                ReceiverId = dto.ReceiverId
            };
            return rating;
        }
        private DtoRating ConvertToDto(Rating rating)
        {
            DtoRating dto = new DtoRating
            {
                Id = rating.Id,
                Ratings = rating.Ratings,
                Reason = rating.Reason,
                SenderId = rating.SenderId,
                ReceiverId = rating.ReceiverId
            };
            return dto;
        }
    }
}
