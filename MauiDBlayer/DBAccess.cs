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
        public async Task<DtoUser> GetUserAsync(string username, string password)
        {
            HttpResponseMessage response;
            response = await HttpClient.GetAsync($"http://10.0.2.2:5245/api/username");
            string json = await response.Content.ReadAsStringAsync();
            var serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            DtoUser user = JsonConvert.DeserializeObject<DtoUser>(json, serializerSettings);
            return user;
        }
    }
}
