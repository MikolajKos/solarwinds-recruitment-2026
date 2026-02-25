using System.Text.Json.Serialization;

namespace RickAndMortyApi.Models
{
    public class RickAndMortyResponse<T>
    {
        [JsonPropertyName("info")]
        public PageInfo Info { get; set; } = new PageInfo();
        [JsonPropertyName("results")]
        public List<T> Results { get; set; } = new List<T>();
    }

    public class PageInfo
    {
        [JsonPropertyName("page")]
        public int Pages { get; set; }
        [JsonPropertyName("next")]
        public string? Next { get; set; }
    }

    public class BaseRickAndMortyEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName ("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }

    public class Character : BaseRickAndMortyEntity { }

    public class Location : BaseRickAndMortyEntity { }

    public class Episode : BaseRickAndMortyEntity 
    {
        [JsonPropertyName("characters")]
        public List<string> Characters { get; set; } = new List<string>();
    }
}
