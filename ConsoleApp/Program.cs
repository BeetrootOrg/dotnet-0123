using System;
using System.IO;
using System.Net.Http;
using System.Threading;

using ConsoleApp;

Console.WriteLine("Enter picture text:");
string text = Console.ReadLine();
if (string.IsNullOrWhiteSpace(text))
{
    throw new ArgumentException("Enter some text!");
}

Console.WriteLine("Enter filename:");
string path = Console.ReadLine();
if (string.IsNullOrWhiteSpace(path))
{
    throw new ArgumentException("Enter a valid filename!");
}

using HttpClient httpClient = new()
{
    BaseAddress = new Uri("https://cataas.com/")
};

ICatClient catClient = new CatClient(httpClient);
using CancellationTokenSource cts = new(TimeSpan.FromSeconds(5));

byte[] content = await catClient.GetCatSaysAsync(text, cts.Token);
await File.WriteAllBytesAsync(path, content, cts.Token);

Console.WriteLine($"Random cat generated!");