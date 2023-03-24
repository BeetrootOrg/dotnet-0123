using System;
using System.Collections.Generic;
using ConsoleApp;

Example ex1 = new Example(a: 1, b: 1);
Example ex2 = new Example(a: 1, b: 3);
Example ex3 = new Example(a: 2, b: 2);

Example[] collection = new Example[] {ex1, ex2, ex3};

Dictionary<int, List<Example>> dictionary = CollExtentions.GroupBy(collection, x => x.A);

foreach (var item in dictionary)
{
    Console.WriteLine($"Grouping by: {item.Key}");

    foreach (var value in item.Value)
    {
        Console.WriteLine("\t" + value);       
    }
}