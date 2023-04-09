using System;
using System.IO;
using System.Net.Http;
using System.Threading;

using ConsoleApp;

Console.WriteLine("Enter coffee filename:");
string path = Console.ReadLine();
if (string.IsNullOrWhiteSpace(path))
{
    throw new ArgumentException("Enter a valid filename!");
}

using HttpClient httpClient = new()
{
    BaseAddress = new Uri("https://coffee.alexflipnote.dev")
};

ICoffeeClient coffeeClient = new CoffeeClient(httpClient);
using CancellationTokenSource cts = new(TimeSpan.FromSeconds(5));

byte[] content = await coffeeClient.GetCoffeeAsync(cts.Token);
await File.WriteAllBytesAsync(path, content, cts.Token);



Console.WriteLine($"Random coffee image generated!");