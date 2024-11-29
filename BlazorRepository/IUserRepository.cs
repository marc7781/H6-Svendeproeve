using FrontendModels;

namespace BlazorRepository
{
    public interface IUserRepository
    {
        Task<User> GetUserFromIdAsync(int userId);
        Task<User> LogInUserAsync(string mail, string password);
        Task<bool> SignUserUpAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> UpdateUserAndPasswordAsync(User user);
    }
}