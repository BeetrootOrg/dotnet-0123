using System;
using System.Net.Http;

using ConsoleApp;

Console.WriteLine("Enter picture text:");
var input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input))
{
    throw new ArgumentException("Enter some text!");
}

Console.WriteLine("Enter filename:");
string filename = Console.ReadLine();
if (string.IsNullOrWhiteSpace(filename))
{
    throw new ArgumentException("Enter a valid filename!");
}

using HttpClient httpClient = new HttpClient
{
    BaseAddress = new Uri("https://cataas.com/")
};

var catClient = new CatClient(httpClient);