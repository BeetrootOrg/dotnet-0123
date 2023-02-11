int Max(int a, int b, int c = Int32.MinValue, int d = Int32.MinValue)
{
    int max1 = Math.Max(a, b);
    int max2 = Math.Max(c, d);
    return Math.Max(max1, max2);
}

int Min(int a, int b, int c = Int32.MaxValue, int d = Int32.MaxValue)
{
    int min1 = Math.Min(a, b);
    int min2 = Math.Min(c, d);
    return Math.Min(min1, min2);
}

bool TrySumIfOdd(int a, int b, out int result)

{
    result = a + b;
    return (a + b) % 2 != 0;
}

void Repeat(string str, int n)
{
    Console.Write(str);
    if (n > 1)
    {
        Repeat(str, n - 1);
    }
}

