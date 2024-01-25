using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Name;

List<int> list = new () { 1, 2, 3 };

static void WriteLineElements<T>(IEnumerable<T> collection)
{
    Console.WriteLine(string.Join(", ", collection));
}

WriteLineElements(list);
WriteLineElements(new[] {4, 5, 6});

list.Add(4);
Console.WriteLine("After add");
WriteLineElements(list);
Console.WriteLine($"Count = {list.Count}");
Console.WriteLine($"Capacity = {list.Capacity}");

list.Add(5);
Console.WriteLine("After add");
WriteLineElements(list);
Console.WriteLine($"Count = {list.Count}");
Console.WriteLine($"Capacity = {list.Capacity}");

List<int> list2 = new(10);
Console.WriteLine("New list");
Console.WriteLine($"Count = {list2.Count}");
Console.WriteLine($"Capacity = {list2.Capacity}");

list.AddRange(new[] {6, 7, 8});
Console.WriteLine("After add");
WriteLineElements(list);

list.Clear();
Console.WriteLine("After add");
WriteLineElements(list);
Console.WriteLine($"Count = {list.Count}");
Console.WriteLine($"Capacity = {list.Capacity}");

Dictionary<int, string> numberToWord = new()
{
    { 1, "one" },
    { 2, "two" }
};
numberToWord.TryAdd(3, "three");
numberToWord .TryAdd(3, "three");


WriteLineElements(numberToWord);

Console.WriteLine($"Contains key 1 = {numberToWord.ContainsKey(1)}");
Console.WriteLine($"Contains value 'five' = {numberToWord.ContainsValue("five")}");

Dictionary<Test, string> testDict1 = new()
{
    [new Test()] = "one",
    [new Test()] = "two"
};

WriteLineElements(testDict1);