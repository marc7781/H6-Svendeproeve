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
    public class UserRepository
    {
        DBAccess db { get; set; }
        public UserRepository() 
        {
            db = new DBAccess();
        }
        public async Task<User> GetUserAsync(string username, string password)
        {
            DtoUser dtoUser = await db.GetUserAsync(username, password);
            User user = GetUser(dtoUser);
            return user;
        }
        private User GetUser(DtoUser dtoUser) 
        {
            User user = new User
            {
                Id = dtoUser.Id,

            };
            return user;
        }
    }
}
