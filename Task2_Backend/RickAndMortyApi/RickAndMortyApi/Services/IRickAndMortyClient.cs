using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services
{
    public interface IRickAndMortyClient
    {
        Task<RickAndMortyResponse<T>?> SearchByNameAsync<T>(string endpoint, string name);
    }
}
