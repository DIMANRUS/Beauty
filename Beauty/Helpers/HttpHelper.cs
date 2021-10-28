using Beauty.Shared.Requests;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Beauty.Helpers {
    class HttpHelper {
        static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://api.beauty.dimanrus.ru/")
        };
        public static async Task<T> GetRequest<T>(string url)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("UserToken"));
            string jsonResponse = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
        public static async Task<HttpResponseMessage> PostRequest<T>(string url, T model)
        {
            var token = await SecureStorage.GetAsync("UserToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonConvert.SerializeObject(model);
            return await _httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
        }
    }
}