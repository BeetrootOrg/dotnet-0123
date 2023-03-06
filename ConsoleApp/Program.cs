static void Swap<T>(ref T val1, ref T val2)
{
    (val1, val2) = (val2, val1);
}

int i1 = 5;
int i2 = 10;

Swap(ref i1, ref i2);
Console.WriteLine((i1, i2));

string s1 = "hello";
string s2 = "world";

Swap(ref s1, ref s2);
Console.WriteLine((s1, s2));

static void WriteLineArray<TElement>(TElement[] arr)
{
    Console.WriteLine(string.Join(", ", arr));
}

WriteLineArray(new[] { 1, 2, 3 });
WriteLineArray(new[] { "hello, world" });
