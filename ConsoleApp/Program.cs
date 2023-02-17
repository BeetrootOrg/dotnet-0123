
void WriteLineArray(int[] array)
{
    Console.WriteLine(string.Join(",", array));
}

int[] Sort(int[] arr)
{
    return arr;
}

WriteLineArray(Sort(new[] { -10, -7, 1, 5, 6, 10 }));
WriteLineArray(Sort(new[] { 10, 6, 5, 1, -7, -10 }));
WriteLineArray(Sort(new[] { 5, 6, -10, 10, 1, -7 }));
WriteLineArray(Sort(Array.Empty<int>()));