using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VokabelMeister.Helpers;

namespace VokabelMeister.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(ApiConfig.BaseUrl)
            };
        }

        public async Task<string> CheckGrammarAsync(string text)
        {
            var request = new { text };
            var response = await _client.PostAsJsonAsync(ApiConfig.CheckGrammar, request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> TranslateWordAsync(string word)
        {
            var request = new { word };
            var response = await _client.PostAsJsonAsync(ApiConfig.TranslateWord, request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
