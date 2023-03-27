using System;
using System.Net.Http;

using ConsoleApp;

using HttpClient httpClient = new()
{
    BaseAddress = new Uri("https://coronavirus.m.pipedream.net/")
};

ICovidClient client = new CovidClient(httpClient);
CovidInfo result = await client.GetCovidInfoAsync();

Console.WriteLine($"There are {result.SummaryStats.Global.Confirmed} confirmed COVID");