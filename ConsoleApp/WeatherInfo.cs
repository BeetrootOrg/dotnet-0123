using System;
using System.Text;

namespace ConsoleApp
{
    internal class WeatherInfo
    {
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public CurrentWeatherInfo Current_Weather { get; init; }
        public void WriteInfo()
        {
            Console.WriteLine("Weather in point");
            StringBuilder sb = new();
            _ = sb.Append($"Latitude: {Latitude}\n");
            _ = sb.Append($"Longitude: {Longitude}\n");
            _ = sb.Append($"Temperature: {Current_Weather.Temperature}\n");
            _ = sb.Append($"Windspeed: {Current_Weather.Windspeed}\n");
            _ = sb.Append($"Winddirection: {Current_Weather.Winddirection}\n");
            _ = sb.Append($"Last time check: {Current_Weather.Time.LocalDateTime}");
            Console.WriteLine(sb.ToString());
        }
    }

    internal class CurrentWeatherInfo
    {
        public double Temperature { get; init; }
        public double Windspeed { get; init; }
        public double Winddirection { get; init; }
        public DateTimeOffset Time { get; init; }
    }
}