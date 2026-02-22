using System.Text.Json;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services
{
    public class RickAndMortyClient : IRickAndMortyClient
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RickAndMortyResponse<T>?> SearchByNameAsync<T>(string endpoint, string name)
        {
            try
            {
                var url = $"{endpoint}?name={Uri.EscapeDataString(name)}";

                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return null;

                // Reads text from response
                var content = await response.Content.ReadAsStringAsync();
                
                return JsonSerializer.Deserialize<RickAndMortyResponse<T>>(content);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
