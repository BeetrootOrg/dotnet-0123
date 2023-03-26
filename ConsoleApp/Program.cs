using System;
using System.Collections.Generic;

using ConsoleApp;

int[] numbers = new[] {1, 2, 3, 4, 5};
string[] words = new[] { "one", "two", "three", "four", "five" };

//ANALOGUE
//foreach (int item in new WhereEnumerable<int>(new[] { 1, 2, 3, 4 }, (item) => item % 2 == 0))
foreach (var item in numbers.Where((item) => item % 2 == 0))
{
    Console.WriteLine(item);
}

foreach (int item in numbers.Select((item) => item * 2))
{
    Console.WriteLine(item);
}

foreach (string item in numbers.Zip(words, (number, word) => $"{number} - {word}"))
{
    Console.WriteLine(item);
}

// ANALOGUE BELOW
// foreach (var item in new SelectEnumerable<int, int>(new WhereEnumerable<int>(numbers, (item) => item % 2 == 0), (item) => item * 2))
foreach (int item in numbers.Where((item) => item % 2 == 0).Select((item) => item * 2))
{
    Console.WriteLine(item);
}

foreach (IEnumerable<int> item in new[] { 1, 2, 3, 4 }.ChunkBy(2))
{
    Console.WriteLine(string.Join(", ", item));
}

foreach (IEnumerable<int> item in new[] { 1, 2, 3 }.ChunkBy(2))
{
    Console.WriteLine(string.Join(", ", item));
}

foreach (IEnumerable<int> item in new[] { 1, 2, 3 }.ChunkBy(5))
{
    Console.WriteLine(string.Join(", ", item));
}

IEnumerable<int>[] result = System.Linq.Enumerable.ToArray(new[] { 1, 2, 3, 4 }.ChunkBy(2));
foreach (IEnumerable<int> item in result)
{
    Console.WriteLine(string.Join(", ", item));
}

Console.WriteLine(string.Join(", ", new DateOnly(2023, 3, 1).DaysBetween(new DateOnly(2023, 3, 15))));
Console.WriteLine(string.Join(", ", new DateOnly(2023, 3, 1).DaysBetween(new DateOnly(2023, 3, 1))));

Console.WriteLine(new DateOnly(1996, 07, 11).Age());
Console.WriteLine(new DateOnly(1996, 03, 15).Age());
Console.WriteLine(new DateOnly(1996, 03, 16).Age());

Console.WriteLine(new DateOnly(2023, 03, 15).IsWeekend());
Console.WriteLine(new DateOnly(2023, 03, 17).IsWeekend());
Console.WriteLine(new DateOnly(2023, 03, 18).IsWeekend());
Console.WriteLine(new DateOnly(2023, 03, 19).IsWeekend());
Console.WriteLine(new DateOnly(2023, 03, 20).IsWeekend());

Console.WriteLine(new DateOnly(2023, 03, 15).NextWorkday());
Console.WriteLine(new DateOnly(2023, 03, 17).NextWorkday());
Console.WriteLine(new DateOnly(2023, 03, 18).NextWorkday());
Console.WriteLine(new DateOnly(2023, 03, 19).NextWorkday());
Console.WriteLine(new DateOnly(2023, 03, 20).NextWorkday());

Console.WriteLine("TrUE".ToBool());
Console.WriteLine("FALse".ToBool());
Console.WriteLine("0".ToBool());