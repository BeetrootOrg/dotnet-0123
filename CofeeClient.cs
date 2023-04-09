using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsoleApp
{
    internal interface ICoffeeClient
    {
        Task<byte[]> GetCoffeeAsync(CancellationToken cancellationToken = default);
    }

    internal class CoffeeClient : ICoffeeClient
    {
        private readonly HttpClient _httpClient;

        public CoffeeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> GetCoffeeAsync(CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync("/random.json", cancellationToken);
            Stream coffee = await response.Content.ReadAsStreamAsync(cancellationToken);

            FileAPI? jsonResponse = await JsonSerializer.DeserializeAsync<FileAPI>(coffee,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            },
            cancellationToken);
            
            string jsonString = jsonResponse.file.Split("/")[^1];

            System.Console.WriteLine(jsonString);

            using HttpResponseMessage answer = await _httpClient.GetAsync($"/{jsonString}", cancellationToken);

            return await answer.Content.ReadAsByteArrayAsync(cancellationToken);
        }
    }
}