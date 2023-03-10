using System;
using System.Collections.Generic;

List<int> list = new() { 1, 2, 3 };
Console.WriteLine(list);

static void WriteLineElements<T>(IEnumerable<T> collection)
{
    Console.WriteLine(string.Join(", ", collection));
}

WriteLineElements(list);
WriteLineElements(new[] { 4, 5, 6 });

list.Add(4);
Console.WriteLine("AFTER ADD");
WriteLineElements(list);
Console.WriteLine($"Count = {list.Count}");
Console.WriteLine($"Capacity = {list.Capacity}");

list.Add(5);
Console.WriteLine("AFTER ADD");
WriteLineElements(list);
Console.WriteLine($"Count = {list.Count}");
Console.WriteLine($"Capacity = {list.Capacity}");

List<int> list2 = new(10);
Console.WriteLine("NEW LIST");
Console.WriteLine($"Count = {list2.Count}");
Console.WriteLine($"Capacity = {list2.Capacity}");

list.AddRange(new[] { 6, 7, 8 });
Console.WriteLine("AFTER ADD");
WriteLineElements(list);

list.Clear();
Console.WriteLine("AFTER CLEAR");
WriteLineElements(list);
Console.WriteLine($"Count = {list.Count}");
Console.WriteLine($"Capacity = {list.Capacity}");

list.Add(1);
Console.WriteLine($"CONTAINS 1 = {list.Contains(1)}");
Console.WriteLine($"CONTAINS 2 = {list.Contains(2)}");

List<int> l1 = new() { 1, 2, 3 };
List<int> l2 = new() { 1, 2, 3 };

Console.WriteLine($"l1.Equals(l2) = {l1.Equals(l2)}");

list.Add(42);
list.Add(100);
Console.WriteLine($"INDEX OF 42 = {list.IndexOf(42)}");
Console.WriteLine($"INDEX OF 43 = {list.IndexOf(43)}");

list.Insert(1, 43);
WriteLineElements(list);

list.Remove(43);
list.RemoveAt(1);

WriteLineElements(list);
