﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontendModels;
using BackendModels;
using BlazorDBAccess;

namespace BlazorRepository
{
    public class UserRepository : Encryption
    {
        DBAccess db {  get; set; }
        public UserRepository()
        {
            db = new DBAccess();
        }
        public async Task<User> LogInUserAsync(string mail, string password)
        {
            DtoUser dtoUser = await db.GetUserFromMailAsync(mail);
            if(dtoUser != null)
            {
                if(ValidatePassword(password, dtoUser.UserCredentials.Password))
                {
                    return ConvertDtoToUser(dtoUser);
                }
                throw new Exception("Password don't match");
            }
            throw new Exception($"Couldn't find a user with {mail} mail");
        }

        public async Task<User> SignUserUpAsync(User user)
        {
            user.UserCredentials.Password = HashPassword(user.UserCredentials.Password);
            DtoUser dtoUser;
            try
            {
                dtoUser = await db.CreateUserAsync(ConvertUserToDto(user));
            }
            catch
            {
                dtoUser = null;
            }
            if(dtoUser != null)
            {
                return ConvertDtoToUser(dtoUser);

            }
            return null;
        }

        #region 

        private DtoUser ConvertUserToDto(User user)
        {
            DtoUser dto = new DtoUser
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
                    Id = user.UserInfo.Id,
                    Name = user.UserInfo.Name,
                    Email = user.UserInfo.Email,
                    Address = user.UserInfo.Address,
                    Phone_number = user.UserInfo.Phone_number,
                },

            };
            return dto;
        }
        private User ConvertDtoToUser(DtoUser dto)
        {
            User user = new User
            {
                Id = dto.Id,
                Driver = dto.Driver,
                UserCredentials = new UserCredentials
                {
                    Id = dto.UserCredentials.Id,
                    Password = dto.UserCredentials.Password,
                },
                UserInfo = new UserInfo
                {
                    Id = dto.UserInfo.Id,
                    Name = dto.UserInfo.Name,
                    Email = dto.UserInfo.Email,
                    Address = dto.UserInfo.Address,
                    Phone_number = dto.UserInfo.Phone_number,
                },

            };
            return user;
        }

        #endregion
    }
}