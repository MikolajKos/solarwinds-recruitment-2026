using System.Net;
using System.Threading.Tasks;
using RickAndMortyApi.Services;

namespace RickAndMortyApi.Tests
{
    public class FindTopPairsAsyncTest
    {
        public class HttpMessageHandlerMock : HttpMessageHandler
        {
            // Using function delegate so we can handle different requests (episodes and characters in this case)
            // HttpRequestMessage - parameter
            // HttpResponseMessage - return type
            private readonly Func<HttpRequestMessage, HttpResponseMessage> _responseStrategy;

            public HttpMessageHandlerMock(Func<HttpRequestMessage, HttpResponseMessage> responseStrategy)
            {
                _responseStrategy = responseStrategy;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                // We have to fetch response from request
                var response = _responseStrategy(request);
                return Task.FromResult(response);
            }
        }

        [Fact]
        public async Task FindTopPairs_AndReturnObjects_OfProvidedType()
        {
            var fakeEpisodeJson = @"
            {
                ""info"": { ""next"": null },
                ""results"": [
                    { ""id"": 1, ""name"": ""Pilot"", ""characters"": [ ""url/1"", ""url/2"" ] }
                ]
            }";

            var fakeCharacterJson = @"
            [
                { ""id"": 1, ""name"": ""Rick Sanchez"", ""url"": ""url/1"" },
                { ""id"": 2, ""name"": ""Morty Smith"", ""url"": ""url/2"" }
            ]";

            // Thanks to Func delegate i can specify behavior for each request
            var handlerMocK = new HttpMessageHandlerMock(request =>
            {
                var url = request.RequestUri!.ToString();

                if (url.Contains("episode"))
                {
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(fakeEpisodeJson) };
                }
                else if (url.Contains("character")) 
                {
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content= new StringContent(fakeCharacterJson) };
                }

                return new HttpResponseMessage { StatusCode= HttpStatusCode.NotFound };
            });

            var httpClient = new HttpClient(handlerMocK)
            {
                BaseAddress = new Uri("https://rickandmortyapi.com/api/")
            };

            // Create service object
            var service = new RickAndMortyService(httpClient);

            var result = await service.FindTopPairsAsync(min: null, max: null);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Rick Sanchez", result[0].Character1.Name);
            Assert.Equal("Morty Smith", result[0].Character2.Name);
        }
    }
}
