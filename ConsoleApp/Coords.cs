using System;
using System.Text;

namespace ConsoleApp
{
    internal struct Coords
    {
        public Coords(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string BuildUrlPart()
        {
            StringBuilder sb = new();
            _ = sb.Append("latitude=");
            _ = sb.Append($"{Latitude:0.00}".Replace(",", "."));
            _ = sb.Append("&longitude=");
            _ = sb.Append($"{Longitude:0.00}".Replace(",", "."));
            _ = sb.Append("&current_weather=true");
            return sb.ToString(); ;
        }
        public void EnterLatitude()
        {
            while (true)
            {
                Console.WriteLine("Enter Latitude:");
                string input = Console.ReadLine();
                if (double.TryParse(input, out double result))
                {
                    if (result is >= (-90) and <= 90)
                    {
                        Latitude = result;
                        return;
                    }
                }
                Console.WriteLine("Invalid Value");
            }
        }

        public void EnterLongitude()
        {
            while (true)
            {
                Console.WriteLine("Enter Longitude:");
                string input = Console.ReadLine();
                if (double.TryParse(input, out double result))
                {
                    if (result is >= (-180) and <= 180)
                    {
                        Longitude = result;
                        return;
                    }
                }
                Console.WriteLine("Invalid Value");
            }
        }
    }
}