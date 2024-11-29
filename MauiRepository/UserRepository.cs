using BackendModels;
using FrontendModels;
using MauiDBlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MauiRepository
{
    public class UserRepository
    {
        DBAccess db { get; set; }
        public UserRepository() 
        {
            db = new DBAccess();
        }
        public async Task<User> GetUserAsync(string username)
        {
            DtoUser dtoUser = await db.GetUserUsernameAsync(username);
            User user = new User
            {
                Id = dtoUser.Id,
                UserCredentials = new UserCredentials
                {
                    Id = dtoUser.UserCredentials.Id,
                    Password = dtoUser.UserCredentials.Password,
                }
            };
            return user;
        }
        public async Task<User> GetUserAsync(int userId)
        {
            DtoUser dtoUser = await db.GetUserUserIdAsync(userId);
            User user = new User
            {
                Id = dtoUser.Id,
                Driver = dtoUser.Driver,
                UserCredentials = new UserCredentials { Id = dtoUser.UserCredentials.Id, Password = dtoUser.UserCredentials.Password },
                UserInfo = new UserInfo 
                { 
                    Id = dtoUser.UserInfo.Id,
                    Name = dtoUser.UserInfo.Name,
                    Email = dtoUser.UserInfo.Email,
                    Phone_number = dtoUser.UserInfo.Phone_number,
                },
                TruckTypeId = (int)dtoUser.TruckTypeId,
            };
            return user;
        }
        public async Task<bool> UpdateUserAync(User user)
        {
            DtoUser dtoUser = new DtoUser
            {
                Id = user.Id,
                Driver = user.Driver,
                UserCredentials = new DtoUserCredentials
                {
                    Id = user.UserCredentials.Id,
                    Password = user.UserCredentials.Password,
                },
                UserInfo = new DtoUserInfo
                {
                    Id =user.UserInfo.Id,
                    Name = user.UserInfo.Name,
                    Email = user.UserInfo.Email,
                    Phone_number = user.UserInfo.Phone_number,
                },
                TruckTypeId = user.TruckTypeId,
            };
            return await db.UpdateUserAsync(dtoUser);
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            DtoUser dtoUser = new DtoUser
            {
                Driver = user.Driver,
                UserCredentials = new DtoUserCredentials
                {
                    Password = user.UserCredentials.Password,
                },
                UserInfo = new DtoUserInfo
                {
                    Name = user.UserInfo.Name,
                    Email = user.UserInfo.Email,
                    Phone_number = user.UserInfo.Phone_number,
                },
                TruckTypeId = user.TruckTypeId,
            };
            return await db.CreateUserAsync(dtoUser);
        }
        private User GetUser(DtoUser dtoUser) 
        {
            User user = new User
            {
                Id = dtoUser.Id,
                Driver = dtoUser.Driver,
                UserCredentials = new UserCredentials
                {
                    Id = dtoUser.UserCredentials.Id,
                    Password = dtoUser.UserCredentials.Password
                },
                UserInfo = new UserInfo
                {
                    Id = dtoUser.UserInfo.Id,
                    Name = dtoUser.UserInfo.Name,
                    Email = dtoUser.UserInfo.Email,
                    Address = dtoUser.UserInfo.Address,
                    Phone_number = dtoUser.UserInfo.Phone_number

                },
                TruckType = new TruckType
                {
                    Id = dtoUser.TruckType.Id,
                    Trucktype = dtoUser.TruckType.Trucktype
                }

            };
            return user;
        }
    }
}
