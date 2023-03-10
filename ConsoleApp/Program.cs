using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleApp;

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

Dictionary<int, string> numberToWord = new()
{
    { 1, "one" },
};

Dictionary<int, string> numberToWord2 = new()
{
    [1] = "two"
};

numberToWord.TryAdd(2, "two");
numberToWord.Add(3, "three");
numberToWord[4] = "four";

WriteLineElements(numberToWord);
WriteLineElements(numberToWord2);

numberToWord2.Clear();
Console.WriteLine("AFTER CLEAR");
WriteLineElements(numberToWord2);

Console.WriteLine($"CONTAINS KEY 1 = {numberToWord.ContainsKey(1)}");
Console.WriteLine($"CONTAINS VALUE 'five' = {numberToWord.ContainsValue("five")}");

Console.WriteLine($"REMOVE 1 = {numberToWord.Remove(1)}");
WriteLineElements(numberToWord);

Console.WriteLine($"TRY REMOVE 2 = {numberToWord.Remove(2, out string two)}");
Console.WriteLine($"TWO = {two}");

try
{
    numberToWord.Add(4, "five");
}
catch (ArgumentException)
{
    // ignore
}

WriteLineElements(numberToWord);

Console.WriteLine($"TRY ADD 4 = {numberToWord.TryAdd(4, "five")}");
WriteLineElements(numberToWord);

numberToWord[4] = "five";
WriteLineElements(numberToWord);

Dictionary<Test, string> testDict1 = new()
{
    [new Test()] = "one",
    [new Test()] = "two"
};

WriteLineElements(testDict1);

BadHashCode bh1 = new();
BadHashCode bh2 = new();

Console.WriteLine($"EQUALS = {bh1.Equals(bh2)}");

Dictionary<BadHashCode, string> testDict2 = new()
{
    [bh1] = "one",
    [bh2] = "two"
};

WriteLineElements(testDict2);

BadEquals be1 = new();
BadEquals be2 = new();

Dictionary<BadEquals, string> testDict3 = new()
{
    [be1] = "one",
    [be2] = "two"
};

WriteLineElements(testDict3);

HashSet<string> uniqueStrings = new() { "one", "two", "three" };
WriteLineElements(uniqueStrings);

Console.WriteLine($"ADD 'one' = {uniqueStrings.Add("one")}");
Console.WriteLine($"ADD 'four' = {uniqueStrings.Add("four")}");
WriteLineElements(uniqueStrings);

Console.WriteLine("ExceptWith");
uniqueStrings.ExceptWith(new[] { "one", "five" });
WriteLineElements(uniqueStrings);

Console.WriteLine("IntersectWith");
uniqueStrings.IntersectWith(new[] { "two", "three", "five" });
WriteLineElements(uniqueStrings);

Console.WriteLine("UnionWith");
uniqueStrings.UnionWith(new[] { "one", "two" });
WriteLineElements(uniqueStrings);

Console.WriteLine($"IsProperSubsetOf = {uniqueStrings.IsProperSubsetOf(new[] { "one", "two", "three", "four" })}");
Console.WriteLine($"IsProperSupersetOf = {uniqueStrings.IsProperSupersetOf(new[] { "one", "two" })}");

Console.WriteLine($"OVERLAPS 1 = {uniqueStrings.Overlaps(new[] { "three", "four" })}");
Console.WriteLine($"OVERLAPS 2 = {uniqueStrings.Overlaps(new[] { "four" })}");

static IEnumerable<int> Power(int number, int exponent)
{
    int result = 1;

    for (int i = 0; i < exponent; i++)
    {
        result *= number;
        yield return result;
    }
}

IEnumerable<int> power = Power(2, 5);
foreach (int item in power)
{
    Console.WriteLine(item);
}

foreach (int item in power)
{
    Console.WriteLine(item);
}

int[] arr = power.ToArray();
WriteLineElements(arr);

int[] numbers = new[] { 1, 2, 3, 4, 5 };
IEnumerable<int> multipliedByThree = new MultiplierEnumerable(numbers, 3);

foreach (int item in multipliedByThree)
{
    Console.WriteLine(item);
}

foreach (int item in new OnlyEvenEnumerable(new[] { 1, 3, 5, 6, 7, 8, 9 }))
{
    Console.WriteLine(item);
}

Console.WriteLine("MUL -> EVEN");
foreach (int item in new MultiplierEnumerable(new OnlyEvenEnumerable(new[] { 1, 3, 4 }), 2))
{
    Console.WriteLine(item);
}

Console.WriteLine("EVEN -> MUL");
foreach (int item in new OnlyEvenEnumerable(new MultiplierEnumerable(new[] { 1, 3, 4 }, 2)))
{
    Console.WriteLine(item);
}