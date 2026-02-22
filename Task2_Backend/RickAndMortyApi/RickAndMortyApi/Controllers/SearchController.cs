using Microsoft.AspNetCore.Mvc;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services;

namespace RickAndMortyApi.Controllers
{
    [Route("search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IRickAndMortyClient _client;

        public SearchController(IRickAndMortyClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string term, int? limit = null)
        {

            if (string.IsNullOrEmpty(term))
                return BadRequest("term is required");

            // Searching for all Entities at once
            var characterTask = _client.SearchByNameAsync<Character>("character", term);
            var locationTask = _client.SearchByNameAsync<Location>("location", term);
            var episodeTask = _client.SearchByNameAsync<Episode>("episode", term);

            // Wait for all search responses
            await Task.WhenAll(characterTask, locationTask, episodeTask);

            var results = new List<SearchDataDto>();

            if (characterTask.Result?.Results?.Count > 0)
            {
                results.AddRange(characterTask.Result.Results.Select(c => new SearchDataDto
                {
                    Name = c.Name,
                    Type = "character",
                    Url = c.Url
                }));
            }

            if (locationTask.Result?.Results?.Count > 0)
            {
                results.AddRange(locationTask.Result.Results.Select(l => new SearchDataDto
                {
                    Name = l.Name,
                    Type = "location",
                    Url = l.Url
                }));
            }

            if (episodeTask.Result?.Results?.Count > 0)
            {
                results.AddRange(episodeTask.Result.Results.Select(e => new SearchDataDto
                {
                    Name = e.Name,
                    Type = "episode",
                    Url = e.Url
                }));
            }

            // Checks if limit was set
            if (limit.HasValue && limit.Value > 0)
            {
                results = results.GetRange(0, limit.Value).ToList();
            }

            return Ok(results);
        }
    }
}
