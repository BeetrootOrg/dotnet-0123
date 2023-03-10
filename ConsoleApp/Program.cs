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