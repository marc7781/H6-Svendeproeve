using BackendModels;
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
        public async Task<DtoUser> GetUserAsync(string username)
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5245/api/User?username={username}");
            string json = await response.Content.ReadAsStringAsync();
            var serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            DtoUser user = JsonConvert.DeserializeObject<DtoUser>(json, serializerSettings);
            return user;
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
    }
}
