using ApiDBlayer;
using DbModels;
using FrontendModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class UserRepository
    {
        Database db;
        public UserRepository()
        {
            db = new Database();
        }
        public async Task<User> GetUserAsync(int userId)
        {
            DtoUser dtoUser = new DtoUser();
            dtoUser = await db.Users.FirstOrDefaultAsync(x => x.Id == userId);
            User user = new User
            {
                Id = dtoUser.Id,
                Driver = dtoUser.Driver,
                UserCredentialsId = dtoUser.UserCredentialsId,
                UserInfoId = dtoUser.UserInfoId,
                OrderId = dtoUser.OrderId,
                TruckTypeId = dtoUser.TruckTypeId,
                RatingId = dtoUser.RatingId,
            };
            return user;
        }
        public async Task<bool> UpdateUserAsync(User user)
        {
            DtoUser dtoUser = new DtoUser
            {
                Id = user.Id,
                Driver = user.Driver,
                UserCredentialsId = user.UserCredentialsId,
                UserInfoId = user.UserInfoId,
                OrderId = user.OrderId,
                TruckTypeId = user.TruckTypeId,
                RatingId = user.RatingId
            };
            db.Users.Update(dtoUser);
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
        public async Task<bool> CreateUserAsync(User user)
        {
            DtoUser dtoUser = new DtoUser
            {
                Id = user.Id,
                Driver = user.Driver,
                UserCredentialsId = user.UserCredentialsId,
                UserInfoId = user.UserInfoId,
                OrderId = user.OrderId,
                TruckTypeId = user.TruckTypeId,
                RatingId = user.RatingId
            };
            db.Users.Add(dtoUser);
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
