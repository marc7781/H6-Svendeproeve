using FrontendModels;

namespace BlazorRepository
{
    public interface IRatingRepository
    {
        Task<bool> CreateRatingAsync(Rating rating);
        Task<List<Rating>> GetUsersRatingFromIdAsync(int id);
    }
}