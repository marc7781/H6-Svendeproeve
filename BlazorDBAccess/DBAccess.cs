﻿using System;
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
    }
}