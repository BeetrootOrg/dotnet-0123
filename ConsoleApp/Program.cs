using ConaoleApp;

using var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://coffee.alexflipnote.dev/")
};

ICoffeeCleint coffeeClient = new CoffeeClient(httpClient);
var result = await coffeeClient.GetCoffeeAsync();

string filename = result.file.Split("/")[^1];
byte[] content = await coffeeClient.GetCoffeFileAsync(filename);
await File.WriteAllBytesAsync(filename, content);
 
Console.WriteLine($"Random coffee file was downloaded: {result.file}");