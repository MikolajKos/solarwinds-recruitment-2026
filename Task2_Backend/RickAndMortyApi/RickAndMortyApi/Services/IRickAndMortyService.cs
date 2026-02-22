using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services
{
    public interface IRickAndMortyService
    {
        Task<List<TopPairsDto>> FindTopPairs(int? min, int? max);
    }
}
