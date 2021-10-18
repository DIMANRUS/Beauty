using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Beauty.Helpers {
    static class HttpHelper {
        static string _baseUri = "https://192.168.228.138:45455/";
        static HttpClient _httpClient = new HttpClient();
        public static async Task<T> GetRequest<T>(string url) {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("UserToken"));
            Stream jsonStream = await _httpClient.GetStreamAsync(_baseUri + url);
            return await JsonSerializer.DeserializeAsync<T>(jsonStream);
        }
    }

    //class HttpHelperResponsee<T> {
    //    public T Data { get; set; }
    //    public bool IsSuccessfully { get; set; }
    //}
}
