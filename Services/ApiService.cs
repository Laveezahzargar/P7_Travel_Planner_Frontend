using P7_Travel_Planner_Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace P7_Travel_Planner_Frontend.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5030/api/")
            };
            if (!string.IsNullOrEmpty(SessionManager.Token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                        "Bearer",
                        SessionManager.Token);
            }
        }

        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        // GET
        public async Task<T?> GetAsync<T>(string endpoint)
        {
            return await _httpClient.GetFromJsonAsync<T>(endpoint);
        }

        // POST

        public async Task<HttpResponseMessage> PostAsync<T>(
    string endpoint,
    T data)
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, data);

            response.EnsureSuccessStatusCode();

            return response;
        }

        // PUT
        public async Task<HttpResponseMessage> PutAsync<T>(
            string endpoint,
            T data)
        {
            return await _httpClient.PutAsJsonAsync(endpoint, data);
        }

        // DELETE
        public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            return await _httpClient.DeleteAsync(endpoint);
        }
    }
}