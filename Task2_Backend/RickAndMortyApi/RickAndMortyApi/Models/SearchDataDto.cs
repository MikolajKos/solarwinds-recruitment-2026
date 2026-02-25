using System.Text.Json.Serialization;

namespace RickAndMortyApi.Models
{
    public class SearchDataDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }
}
