﻿using BackendModels;
using System.Text;
using Newtonsoft.Json;

namespace MauiDBlayer
{
    public class DBAccess
    {
        protected HttpClient HttpClient;
        public DBAccess()
        {
            HttpClient = new HttpClient();
        }
        public async Task<List<DtoOrder>> GetOrderAsync()
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5245/api/Order");
            string json = await response.Content.ReadAsStringAsync();
            var serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            List<DtoOrder> orders = JsonConvert.DeserializeObject<List<DtoOrder>>(json, serializerSettings);
            return orders;
        }
        public async Task<List<DtoOrder>> GetOrdersForDriverAsync(int driverId)
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5245/api/Order/Driver/{driverId}");
            string json = await response.Content.ReadAsStringAsync();
            var serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            List<DtoOrder> orders = JsonConvert.DeserializeObject<List<DtoOrder>>(json, serializerSettings);
            return orders;
        }
        public async Task<bool> UpdateDriverOrderAsync(DtoOrder dtoOrder)
        {
            HttpResponseMessage response;
            var content = new StringContent(JsonConvert.SerializeObject(dtoOrder), Encoding.UTF8, "application/json");
            response = await HttpClient.PutAsync("http://10.0.2.2:5245/api/Order", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdatePriceOrderAsync(DtoOrder dtoOrder)
        {
            HttpResponseMessage response;
            var content = new StringContent(JsonConvert.SerializeObject(dtoOrder), Encoding.UTF8, "application/json");
            response = await HttpClient.PutAsync("http://10.0.2.2:5245/api/Order", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            HttpResponseMessage response;
            response = await HttpClient.DeleteAsync($"http://10.0.2.2:5245/api/Order?orderId={orderId}");
            return response.IsSuccessStatusCode;
        }
        public async Task<DtoUser> GetUserUsernameAsync(string username)
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5245/api/User?username={username}");
            string json = await response.Content.ReadAsStringAsync();
            var serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            DtoUser user = JsonConvert.DeserializeObject<DtoUser>(json, serializerSettings);
            return user;
        }
        public async Task<DtoUser> GetUserUserIdAsync(int userid)
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5245/api/User/{userid}");
            string json = await response.Content.ReadAsStringAsync();
            var serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            DtoUser user = JsonConvert.DeserializeObject<DtoUser>(json, serializerSettings);
            return user;
        }
        public async Task<bool> UpdateUserAsync(DtoUser dtoUser)
        {
            HttpResponseMessage response;
            var content = new StringContent(JsonConvert.SerializeObject(dtoUser), Encoding.UTF8, "application/json");
            response = await HttpClient.PutAsync("http://10.0.2.2:5245/api/User", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> CreateUserAsync(DtoUser user)
        {
            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response;
            try
            {
                response = await HttpClient.PostAsync("http://10.0.2.2:5245/api/User", content);
            }
            catch
            {
                return false;
            }
            return response.IsSuccessStatusCode;
        }
        public async Task<List<DtoTruckType>> GetAllTruckAsync()
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5245/api/TruckType");
            string json = await response.Content.ReadAsStringAsync();
            var serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            List<DtoTruckType> truckTypes = JsonConvert.DeserializeObject<List<DtoTruckType>>(json, serializerSettings);
            return truckTypes;
        }
        public async Task<List<DtoRating>> GetRatingAsync(int userId)
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5245/api/Rating");
            string json = await response.Content.ReadAsStringAsync();
            var serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            List<DtoRating> ratings = JsonConvert.DeserializeObject<List<DtoRating>>(json, serializerSettings);
            return ratings;
        }
        public async Task<bool> CreateRatingAsync(DtoRating rating)
        {
            string json = JsonConvert.SerializeObject(rating);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response;
            try
            {
                response = await HttpClient.PostAsync("http://10.0.2.2:5245/api/Rating", content);
            }
            catch
            {
                return false;
            }
            return response.IsSuccessStatusCode;
        }
    }
}
