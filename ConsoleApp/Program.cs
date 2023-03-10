List<int> list = new() { 1, 2, 3 };
Console.WriteLine(list);

static void WriteLineElements<T>(IEnumerable<T> collection)
{
    Console.WriteLine(string.Join(", ", collection));
}

WriteLineElements(list);
WriteLineElements(new[] { 4, 5, 6 });