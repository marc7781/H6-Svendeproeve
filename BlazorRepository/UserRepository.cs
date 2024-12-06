using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontendModels;
using BackendModels;
using BlazorDBAccess;

namespace BlazorRepository
{
    public class UserRepository : Encryption, IUserRepository
    {
        DBAccess db { get; set; }
        public UserRepository()
        {
            db = new DBAccess();
        }
        public async Task<User> LogInUserAsync(string mail, string password)
        {
            DtoUser dtoUser = await db.GetUserFromMailAsync(mail);
            if (dtoUser != null)
            {
                if (ValidatePassword(password, dtoUser.UserCredentials.Password))
                {
                    dtoUser = await db.GetOneUserFromIdAsync(dtoUser.Id);
                    return ConvertDtoToUser(dtoUser);
                }
                throw new Exception("Kodeorderne passer ikke sammen");
            }
            throw new Exception($"Kunne ikke finde en bruger med mailen: {mail}");
        }
        public async Task<User> GetUserFromIdAsync(int userId)
        {
            DtoUser dtoUser = await db.GetOneUserFromIdAsync(userId);
            if (dtoUser != null)
            {
                return ConvertDtoToUser(dtoUser);
            }
            return null;
        }

        public async Task<bool> SignUserUpAsync(User user)
        {
            user.TruckTypeId = 0;
            user.UserCredentials.Password = HashPassword(user.UserCredentials.Password);
            bool checkIfSucces = false;
            try
            {
                checkIfSucces = await db.CreateUserAsync(ConvertUserToDto(user));
            }
            catch
            {
                return false;
            }
            return checkIfSucces;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            if(user != null)
            {
                return await db.UpdateUserAsync(ConvertUserToDto(user));
            }
            return false;
        }
        public async Task<bool> UpdateUserAndPasswordAsync(User user)
        {
            if (user != null)
            {
                user.UserCredentials.Password = HashPassword(user.UserCredentials.Password);
                return await db.UpdateUserAsync(ConvertUserToDto(user));
            }
            return false;
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
                TruckTypeId = user.TruckTypeId,
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
