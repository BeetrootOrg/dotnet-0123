using System;

using ConsoleApp;

int[] numbers = new[] { 1, 2, 3, 4, 5 };
string[] words = new[] { "one", "two", "three", "four", "five" };

// ANALOGUE BELOW
// foreach (int item in new WhereEnumerable<int>(new[] { 1, 2, 3, 4 }, (item) => item % 2 == 0))
foreach (int item in numbers.Where((item) => item % 2 == 0))
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