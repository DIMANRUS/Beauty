using Beauty.Stores;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Helpers {
    class HttpHelper : IDisposable {
        readonly HttpClient _httpClient = new () {
            BaseAddress = new Uri("https://api.beauty.dimanrus.ru/")
        };
        public async Task<T> GetRequest<T>(string url) {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserDataStore.UserToken);
            string jsonResponse = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
        public async Task<HttpResponseMessage> PostRequest<T>(string url, T model) {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserDataStore.UserToken);
            string json = JsonConvert.SerializeObject(model);
            return await _httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
        }

        public void Dispose() {
            _httpClient.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}