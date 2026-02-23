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

        public async Task<List<TopPairsDto>> FindTopPairsAsync(int? min, int? max, int limit = 20)
        {
            try
            {
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
                            var url2 = episode.Characters[j];

                            // Sort characters to avoid duplicates like Rick - Morty & Morty - Rick
                            var pair = string.Compare(url1, url2) < 0 ? (url1, url2) : (url2, url1);

                            if (pairs.ContainsKey(pair))
                                pairs[pair]++;
                            else
                                pairs.Add(pair, 1);
                        }
                    }
                }

                // Sort and limit pairs
                pairs = SortAndLimitTheScope(pairs, max, min, limit);
                
                return await FetchCharactersNames(pairs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown error occurred: {ex.Message}");
                return new List<TopPairsDto>();
            }
        }

        private static Dictionary<(string, string), int> SortAndLimitTheScope(Dictionary<(string, string), int> pairs, int? max, int? min, int limit)
        {
            // Sort and Limit by max, min allowed values and element count limit
            return pairs.Where(x =>
                // if max or min == null statement returns true without checking right side of || operator
                (!max.HasValue || x.Value <= max.Value) &&
                (!min.HasValue || x.Value >= min.Value)
            )
            .OrderByDescending(x => x.Value)
            .Take(limit) // If limit is not set return 20 pairs by default
            .ToDictionary(x => x.Key, x => x.Value);
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

                    if (!response.IsSuccessStatusCode) break;

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
            if (pairs.Count() == 0) return new List<TopPairsDto>();

            try
            {
                // Get unique character id pairs
                var uniqueIds = new HashSet<string>();
                
                foreach (var key in pairs.Keys)
                {
                    uniqueIds.Add(key.Item1.TrimEnd('/').Split('/').Last());
                    uniqueIds.Add(key.Item2.TrimEnd('/').Split('/').Last());
                }

                // Join id pairs
                var charIdsQuery = string.Join(",", uniqueIds);

                var url = $"character/{charIdsQuery}";

                // For character/[id list] url, rick and morty api doesnt use pagination
                // So i can read characters without searching through all pages
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return new List<TopPairsDto>();

                var content = await response.Content.ReadAsStringAsync();

                var characters = JsonSerializer.Deserialize<List<Character>>(content) ?? new List<Character>();
                var charDict = characters.ToDictionary(c => c.Url, c => c.Name);

                // Populating result list with names and episodes
                return pairs.Select(p => new TopPairsDto {
                    Character1 = { Name = charDict[p.Key.Item1], Url = p.Key.Item1 },
                    Character2 = { Name = charDict[p.Key.Item2], Url = p.Key.Item2 },
                    Episodes = p.Value
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown error occurred: {ex.Message}");
                return new List<TopPairsDto>();
            }
        }
    }
}