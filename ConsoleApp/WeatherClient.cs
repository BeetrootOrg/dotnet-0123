using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal interface IWeatherClient
    {
        Task<WeatherInfo> GetWeatherInfoAsync(CancellationToken cancellationToken = default);
    }

    internal class WeatherClient : IWeatherClient
    {
        private readonly HttpClient _httpClient;

        public WeatherClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherInfo> GetWeatherInfoAsync(CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress, cancellationToken);
            return await response.Content.ReadFromJsonAsync<WeatherInfo>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }, cancellationToken);
        }
    }
}