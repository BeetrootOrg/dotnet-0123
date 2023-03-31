using System;
using System.Net.Http;
using System.Threading;

using ConsoleApp;

Coords coords = new();
coords.EnterLatitude();
coords.EnterLongitude();
// Coords coords = new(49.34, 34.21);

using HttpClient httpClient = new()
{
    BaseAddress = new Uri("https://api.open-meteo.com/v1/forecast?" + coords.BuildUrlPart())
};

CancellationTokenSource cts = new(TimeSpan.FromSeconds(5));

IWeatherClient weatherClient = new WeatherClient(httpClient);
WeatherInfo weatherInfo = await weatherClient.GetWeatherInfoAsync();
weatherInfo.WriteInfo();

