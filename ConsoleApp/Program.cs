using System;
using System.Net.Http;

using ConsoleApp;

using var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://coronavirus.m.pipedream.net/")
};

ICovidClient client = new CovidClient(httpClient);
var result = await client.GetCovidInfoAsync();

Console.WriteLine($"There are {result.SummaryStats.Global.Confirmed} confirmed COVID");