using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleApp;

List<SubArray> list = new List<SubArray>()
{
    new SubArray(1,1),
    new SubArray(1,3),
    new SubArray(2,2),
};
Console.WriteLine("Struct");
foreach (var item in list.GroupBy<int, SubArray>(g => g.A))
{
    Console.Write($"{item.Key}: ");
    Console.WriteLine(String.Join(", ", item.Value)); 
}
