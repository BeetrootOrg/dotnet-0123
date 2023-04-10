using System.Net.Http;

using Newtonsoft.Json;

namespace ConsoleApp
{
    internal interface ICoffeeClient
    {
        public Task<byte[]> GetCoffeeAsync(CancellationToken cancellationToken = default);
    }

    internal class CoffeeClient : ICoffeeClient
    {
        private readonly HttpClient _client;
        public CoffeeClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<byte[]> GetCoffeeAsync(CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage response = await _client.GetAsync("", cancellationToken);

            var obj = JsonConvert.DeserializeObject<CoffeeResponseObject>(await response.Content.ReadAsStringAsync(cancellationToken));
            using HttpResponseMessage coffeeResponse = await _client.GetAsync(obj.FileUrl);
            return await coffeeResponse.Content.ReadAsByteArrayAsync();
        }
    }
}