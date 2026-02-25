using System.Text.Json.Serialization;

namespace RickAndMortyApi.Models
{
    public class TopPairsDto
    {
        [JsonPropertyName("character1")]
        public CharacterShortDto Character1 { get; set; } = new CharacterShortDto();
        [JsonPropertyName("character2")]
        public CharacterShortDto Character2 { get; set; } = new CharacterShortDto();
        [JsonPropertyName("episodes")]
        public int Episodes { get; set; }
    }

    public class CharacterShortDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }
}
