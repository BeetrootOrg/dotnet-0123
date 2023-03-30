using Models;

using System.Text.Json;

namespace Helpers
{
    public class CoffeeHelper : IDisposable
    {
        private readonly string uri = "https://coffee.alexflipnote.dev/random.json";
        private MyHttpClient? _myHttpClient;
        private CancellationTokenSource? _cancellationTokenSource;

        public CoffeeHelper()
        {
            _myHttpClient = new MyHttpClient();
        }

        public async Task ActionAsync()
        {
            try
            {
                _cancellationTokenSource = new(5000);
                string? text = await _myHttpClient?.GetTextAsync(uri, _cancellationTokenSource.Token);
                if (text == null) throw new ArgumentNullException();
                Coffee? coffee = await Task<Coffee>.Run(() =>
                {
                    try
                    {
                        return JsonSerializer.Deserialize<Coffee>(text);
                    }
                    catch
                    {
                        Console.WriteLine("Cannot Deserialize response");
                        return null;
                    }
                });
                if (coffee == null || string.IsNullOrEmpty(coffee.file)) throw new ArgumentNullException();
                var content = await _myHttpClient.GetBytesAsync(coffee.file, _cancellationTokenSource.Token);
                await File.WriteAllBytesAsync($"Downloads/{Path.GetFileName(coffee.file)}", content, _cancellationTokenSource.Token);
                Console.WriteLine($"\t\tCoffee Downloads/{Path.GetFileName(coffee.file)} waiting for you!");
            }
            catch
            {
                Console.WriteLine("ooooppps. Something wrong. Try again.");
            }
        }

        public void Dispose()
        {
            _myHttpClient?.Dispose();
            _cancellationTokenSource?.Dispose();
        }
    }

}