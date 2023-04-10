using ConsoleApp;
Console.WriteLine("Enter filename:");
string path = Console.ReadLine();
if (string.IsNullOrWhiteSpace(path))
{
    throw new ArgumentException("Enter a valid filename!");
}

using HttpClient httpClient = new HttpClient()
{
    BaseAddress = new Uri("https://coffee.alexflipnote.dev/random.json")
};

ICoffeeClient coffeeClient = new CoffeeClient(httpClient);
using CancellationTokenSource cts = new(TimeSpan.FromSeconds(5));

byte[] content = await coffeeClient.GetCoffeeAsync(cts.Token);
await File.WriteAllBytesAsync(path, content, cts.Token);

Console.WriteLine("Here's your random coffee.");
Console.ReadLine();
