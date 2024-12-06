using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendModels;
using Newtonsoft.Json;

namespace BlazorDBAccess
{
    public class DBAccess
    {
        protected HttpClient httpClient;
        public DBAccess()
        {
            httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7152/api/") };
        }
        public async Task<bool> CreateOrderAsync(DtoOrder order)
        {
            if(order != null)
            {
                string json = JsonConvert.SerializeObject(order);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                try
                {
                    response = await httpClient.PostAsync("Order", content);
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }
        public async Task<List<DtoOrder>> GetOrdersFromOwnerIdAsync(int ownerId)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync($"Order/Customer/{ownerId}");
            }
            catch
            {
                return null;
            }
            if(response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<DtoOrder>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<DtoOrder> GetOrderFromIdAsync(int orderId)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync($"Order/{orderId}");
            }
            catch
            {
                return null;
            }
            if(response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<DtoOrder>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            if (orderId != 0)
            {
                HttpResponseMessage response;
                try
                {
                    response = await httpClient.DeleteAsync($"Order/{orderId}");
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }
        public async Task<bool> UpdateOrderAsync(DtoOrder order)
        {
            if (order != null)
            {
                string json = JsonConvert.SerializeObject(order);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                try
                {
                    response = await httpClient.PutAsync("Order", content);
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }
        public async Task<DtoUser> GetUserFromMailAsync(string mail)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync($"User?username={mail}");
            }
            catch
            {
                return null;
            }
            if(response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<DtoUser>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<DtoUser> GetOneUserFromIdAsync(int id)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync($"User/{id}");
            }
            catch
            {
                return null;
            }
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<DtoUser>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<bool> CreateUserAsync(DtoUser dtoUser)
        {
            if (dtoUser != null)
            {
                string json = JsonConvert.SerializeObject(dtoUser);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                try
                {
                    response = await httpClient.PostAsync("User", content);
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }
        public async Task<bool> UpdateUserAsync(DtoUser dtoUser)
        {
            if(dtoUser != null)
            {
                string json = JsonConvert.SerializeObject(dtoUser);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                try
                {
                    response = await httpClient.PutAsync("User", content);
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }
        public async Task<bool> CreateRatingAsync(DtoRating dtoRating)
        {
            if (dtoRating != null)
            {
                string json = JsonConvert.SerializeObject(dtoRating);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                try
                {
                    response = await httpClient.PostAsync("Rating", content);
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }
        public async Task<List<DtoRating>> GetUsersRatingFromIdAsync(int id)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync($"Rating/UsersRatings/{id}");
            }
            catch
            {
                return null;
            }
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<DtoRating>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}