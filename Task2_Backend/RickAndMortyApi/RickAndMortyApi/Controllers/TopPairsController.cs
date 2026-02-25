using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMortyApi.Services;

namespace RickAndMortyApi.Controllers
{
    [Route("top-pairs")]
    [ApiController]
    public class TopPairsController : ControllerBase
    {
        private readonly IRickAndMortyService _client;

        public TopPairsController(IRickAndMortyService client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Search(int? min, int? max, int limit = 20)
        {
            var topPairs = await _client.FindTopPairsAsync(min, max, limit);

            return Ok(topPairs);
        }
    }
}
