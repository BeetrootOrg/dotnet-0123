using System;
using System.IO;
using System.Net.Http;
using System.Threading;

using ConsoleApp;

using var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://coffee.alexflipnote.dev/")
};

ICoffeeClient coffeeClient = new CoffeeClient(httpClient);
var result = await coffeeClient.GetCoffeeAsync();

string filename = result.File.Split("/")[^1];

byte[] content =  await coffeeClient.GetCoffeeFileAsync(filename);
await File.WriteAllBytesAsync(filename, content);

Console.WriteLine($"Coffee file {result.File}");
