using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using VokabelMeister.Helpers;
using VokabelMeister.Models;

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

        public async Task<CheckGrammarResponse?> CheckGrammarAsync(string text)
        {
            var request = new { text };
            var response = await _client.PostAsJsonAsync(ApiConfig.CheckGrammar, request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CheckGrammarResponse>(json);
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
