using System.Text.Json;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services
{
    public class RickAndMortyService : IRickAndMortyService
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TopPairsDto>> FindTopPairs(int? min, int? max)
        {
            try
            {
                /*                var query = (min.HasValue && max.HasValue) ?
                                    $"?min={min}&max={max}" :
                                    (min.HasValue ? $"?min={min}" :
                                    (max.HasValue ? $"?max={max}" : ""));*/

                List<Episode> episodes = await FetchAllEpisodes();

                // Creating all pairs
                var pairs = new Dictionary<(string, string), int>();

                foreach (var episode in episodes)
                {
                    for (int i = 0; i < episode.Characters.Count; ++i)
                    {
                        for (int j = i + 1; j < episode.Characters.Count; ++j)
                        {
                            var url1 = episode.Characters[i];
                            var character2 = episode.Characters[j];

                            // Sort characters to avoid duplicates like Rick - Morty & Morty - Rick
                            var pair = string.Compare(chara);

                            if (pairs.ContainsKey(pair))
                                pairs[pair]++;
                            else
                                pairs.Add(pair, 1);
                        }
                    }
                }
                
                return await FetchCharactersNames(pairs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown error occurred: {ex.Message}");
                return new List<TopPairsDto>();
            }
        }

        private async Task<List<Episode>> FetchAllEpisodes()
        {
            try
            {
                var nextUrl = "episode";
                var allEpisodes = new List<Episode>();

                // Read all episodes with pagination
                while (!string.IsNullOrEmpty(nextUrl))
                {
                    var response = await _httpClient.GetAsync(nextUrl);

                    if (!response.IsSuccessStatusCode)
                        return new List<Episode>();

                    var content = await response.Content.ReadAsStringAsync();

                    var page = JsonSerializer.Deserialize<RickAndMortyResponse<Episode>>(content) ?? new RickAndMortyResponse<Episode>();

                    if (page?.Results.Count() > 0)
                    {
                        allEpisodes.AddRange(page.Results);
                    }

                    nextUrl = page?.Info?.Next;
                }

                return allEpisodes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown error occurred: {ex.Message}");
                return new List<Episode>();
            }
        }

        private async Task<List<TopPairsDto>> FetchCharactersNames(Dictionary<(string, string), int> pairs) 
        {
            try
            {
                // Reading all characters names
                var result = pairs.Select(x => new TopPairsDto { 
                    
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown error occurred: {ex.Message}");
                return new List<TopPairsDto>();
            }
        }
    }
}
