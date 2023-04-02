//=============18/03/2023===========
// Homework 19-Extensions

using System;
using System.Collections.Generic;

using ConsoleApp;

var list = new List<(string, int)>(){new (){Item1="1",Item2=1}, new (){Item1="1",Item2=2},new (){Item1="1",Item2=3},
new (){Item1="2",Item2=1},new (){Item1="2",Item2=2},new (){Item1="2",Item2=3},new (){Item1="3",Item2=3},
new (){Item1="3",Item2=1}};
var groulist = list.GroupBy(x => x.Item1);
foreach (var group in groulist)
{
    Console.WriteLine($"{group.Key}");
    foreach (var item in group)
    {
        Console.WriteLine($"\t{item.Item1} {item.Item2}");
    }
}