using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal interface ICovidClient
    {
        Task<CovidInfo> GetCovidInfoAsync(CancellationToken cancellationToken = default);
    }

    internal class CovidClient : ICovidClient
    {
        private readonly HttpClient _httpClient;

        public CovidClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CovidInfo> GetCovidInfoAsync(CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync("/", cancellationToken);
            Stream content = await response.Content.ReadAsStreamAsync(cancellationToken);
            return await JsonSerializer.DeserializeAsync<CovidInfo>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }, cancellationToken);
        }
    }
}