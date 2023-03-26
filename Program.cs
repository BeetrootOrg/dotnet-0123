using System;
using System.Collections.Generic;
using ConsoleApp;
using Extentions;


Element a = new Element(1, 1);
Element b = new Element(1, 3);
Element c = new Element(2, 2);

Element[] array = new Element[] {a, b, c};

Dictionary<int, List<Element>> dictionary = array.GroupBy<int, Element>(x => x.A);

foreach (var item in dictionary)
{
    Console.WriteLine($"{item.Key}:");

    foreach (var value in item.Value)
    {
        Console.WriteLine(value);       
    }
}