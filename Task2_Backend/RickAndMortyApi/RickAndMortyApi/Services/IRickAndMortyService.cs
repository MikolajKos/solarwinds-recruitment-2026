using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services
{
    public interface IRickAndMortyService
    {
        Task<List<TopPairsDto>> FindTopPairsAsync(int? min, int? max, int limit = 20);
    }
}
