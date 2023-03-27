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
        private readonly HttpClient _httpClient;

        public CatClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> GetCatSaysAsync(string text, CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"/cat/says/{text}", cancellationToken);
            return await response.Content.ReadAsByteArrayAsync(cancellationToken);
        }
    }
}