using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Helpers
{
    public class MyHttpClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public MyHttpClient()
        {
            _httpClient = new HttpClient() { };
        }

        public async Task<byte[]> GetBytesAsync(string uri, CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"{uri}", cancellationToken);
            return await response.Content.ReadAsByteArrayAsync(cancellationToken);
        }

        public async Task<string> GetTextAsync(string uri, CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"{uri}", cancellationToken);
            return await response.Content.ReadAsStringAsync(cancellationToken);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}