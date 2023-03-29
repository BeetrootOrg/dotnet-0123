using System.Text.Json;

namespace ConaoleApp
{
    internal class CoffeeClient : ICoffeeCleint
    {
        private readonly HttpClient _httpClient;

        public CoffeeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Coffee> GetCoffeeAsync(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync("/random.json", cancellationToken);
            Stream content = await response.Content.ReadAsStreamAsync(cancellationToken);

            return await JsonSerializer.DeserializeAsync<Coffee>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }, cancellationToken);
        }

        public async Task<byte[]> GetCoffeFileAsync(string filename, CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"/{filename}", cancellationToken);

            return await response.Content.ReadAsByteArrayAsync(cancellationToken);
        }
    }
}