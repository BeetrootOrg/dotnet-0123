using System;
using System.Diagnostics;
using System.Threading.Tasks;

Stopwatch sw = new();

sw.Start();
Task boilAKettleTask = BoilAKettle();
Task heatUpAPanTask = HeatUpAPan();
Task pourAGlassOfWater = PourAGlassOfWater();
await AddButterToBread();
await heatUpAPanTask;
await FryTwoEggs();
await Task.WhenAll(boilAKettleTask, pourAGlassOfWater);
await PrepareCoffee();
await Breakfast();
sw.Stop();

Console.WriteLine($"Breakfast took {sw.ElapsedMilliseconds}");

async Task BoilAKettle()
{
    await Task.Delay(5000);
    Console.WriteLine("Kettle is boiled!");
}

async Task HeatUpAPan()
{
    await Task.Delay(2000);
    Console.WriteLine("Pan ready!");
}

async Task FryTwoEggs()
{
    await Task.Delay(7000);
    Console.WriteLine("Eggs ready!");
}

async Task AddButterToBread()
{
    await Task.Delay(1500);
    Console.WriteLine("Bread ready!");
}

async Task PrepareCoffee()
{
    await Task.Delay(2000);
    Console.WriteLine("Coffee ready!");
}

async Task PourAGlassOfWater()
{
    await Task.Delay(1000);
    Console.WriteLine("Water in glass!");
}

async Task Breakfast()
{
    await Task.Delay(10000);
    Console.WriteLine("Breakfast eaten!");
}