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
        public async Task<User> GetUserPasswordAsync(string username)
        {
            DtoUser dtoUser = new DtoUser();
            try
            {
                dtoUser = await db.Users.Include(x => x.UserCredentials).FirstOrDefaultAsync(x => x.UserInfo.Email == username);
            }
            catch
            {
                return null;
            }
            if(dtoUser != null)
            {
                User user = new User
                {
                    Id = dtoUser.Id,
                    UserCredentials = new UserCredentials { Id = dtoUser.UserCredentials.Id, Password = dtoUser.UserCredentials.Password },
                };
                return user;
            }
            return null;
        }
        public async Task<User> GetUserAsync(int userId)
        {
            DtoUser dtoUser = new DtoUser();
            try
            {
                dtoUser = await db.Users.Include(x => x.UserInfo).Include(x => x.UserCredentials).FirstOrDefaultAsync(x => x.Id == userId);
            }
            catch
            {
                return null;
            }
            if(dtoUser != null)
            {
                User user = new User
                {
                    Id = dtoUser.Id,
                    Driver = dtoUser.Driver,
                    UserCredentialsId = dtoUser.UserCredentialsId,
                    UserCredentials = new UserCredentials { Id = dtoUser.UserCredentials.Id, Password = dtoUser.UserCredentials.Password },
                    UserInfoId = dtoUser.UserInfoId,
                    UserInfo = new UserInfo
                    {
                        Id = dtoUser.UserInfo.Id,
                        Address = dtoUser.UserInfo.Address,
                        Email = dtoUser.UserInfo.Email,
                        Name = dtoUser.UserInfo.Name,
                        Phone_number = dtoUser.UserInfo.Phone_number
                    },
                    OrderId = dtoUser.OrderId,
                    TruckTypeId = dtoUser.TruckTypeId,
                    RatingId = dtoUser.RatingId,
                };
                return user;
            }
            return null;
        }
        public async Task<bool> UpdateUserAsync(User user)
        {
            if(user != null)
            {
                DtoUser dtoUser = new DtoUser
                {
                    Id = user.Id,
                    Driver = user.Driver,
                    UserCredentialsId = user.UserCredentialsId,
                    UserCredentials = new DtoUserCredentials { Id = user.UserCredentials.Id, Password = user.UserCredentials.Password },
                    UserInfoId = user.UserInfoId,
                    UserInfo = new DtoUserInfo
                    {
                        Id = user.UserInfo.Id,
                        Address = user.UserInfo.Address,
                        Email = user.UserInfo.Email,
                        Name = user.UserInfo.Name,
                        Phone_number = user.UserInfo.Phone_number
                    },
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
            return false;
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            if(user != null)
            {
                DtoUser dtoUser = new DtoUser
                {
                    Id = user.Id,
                    Driver = user.Driver,
                    UserCredentialsId = user.UserCredentialsId,
                    UserCredentials = new DtoUserCredentials { Id = user.UserCredentials.Id, Password = user.UserCredentials.Password },
                    UserInfoId = user.UserInfoId,
                    UserInfo = new DtoUserInfo
                    {
                        Id = user.UserInfo.Id,
                        Address = user.UserInfo.Address,
                        Email = user.UserInfo.Email,
                        Name = user.UserInfo.Name,
                        Phone_number = user.UserInfo.Phone_number
                    },
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
            return false;
        }
    }
}
