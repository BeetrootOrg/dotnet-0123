using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal interface ICatClient
    {
        Task<byte[]> GetCatSaysAsync(string text, CancellationToken cancellationToken = default);
    }
    internal class CatClient : ICatClient
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public CatClient(string baseUri, HttpClient httpClient)
        {
            _baseUri = baseUri;
            _httpClient = httpClient;
        }

        public async Task<byte[]> GetCatSaysAsync(string text, CancellationToken cancellationToken = default)
        {
           var response = await _httpClient.GetAsync($"{_baseUri}/cat/says/{text}", cancellationToken);
           return await response.Content.ReadAsByteArrayAsync(cancellationToken);
        }
    }
}