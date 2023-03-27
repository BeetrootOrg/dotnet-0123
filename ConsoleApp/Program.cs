using System;
using System.Diagnostics;
using System.Threading;

Stopwatch sw = new();

sw.Start();
BoilAKettle();
HeatUpAPan();
FryTwoEggs();
AddButterToBread();
PrepareCoffee();
PourAGlassOfWater();
Breakfast();
sw.Stop();

Console.WriteLine($"Breakfast took {sw.ElapsedMilliseconds}");

void BoilAKettle()
{
    Thread.Sleep(5000);
    Console.WriteLine("Kettle is boiled!");
}

void HeatUpAPan()
{
    Thread.Sleep(2000);
    Console.WriteLine("Pan ready!");
}

void FryTwoEggs()
{
    Thread.Sleep(7000);
    Console.WriteLine("Eggs ready!");
}

void AddButterToBread()
{
    Thread.Sleep(1500);
    Console.WriteLine("Bread ready!");
}

void PrepareCoffee()
{
    Thread.Sleep(2000);
    Console.WriteLine("Coffee ready!");
}

void PourAGlassOfWater()
{
    Thread.Sleep(1000);
    Console.WriteLine("Water in glass!");
}

void Breakfast()
{
    Thread.Sleep(10000);
    Console.WriteLine("Breakfast eaten!");
}