using System;

int Max2(int a, int b)
{
    return a > b ? a : b;
}

int Max(int a, int b, int c = int.MinValue, int d = int.MinValue)
{
    return Max2(Max2(Max2(a, b), c), d);
}

int Min2(int a, int b)
{
    return a < b ? a : b;
}

int Min(int a, int b, int c = int.MaxValue, int d = int.MaxValue)
{
    return Min2(Min2(Min2(a, b), c), d);
}

bool TrySumIfOdd(int a, int b, out int result)
{
    result = a + b;
    return result % 2 == 0;
}

string Repeat(string str, int n)
{
    return n > 0
        ? str + Repeat(str, n - 1)
        : string.Empty;
}

Console.WriteLine(Max(1, 2));
Console.WriteLine(Max(1, 2, 3));
Console.WriteLine(Max(1, 2, 3, 4));
Console.WriteLine(Min(1, 2, 3, 4));

Console.WriteLine(TrySumIfOdd(2, 5, out _));
Console.WriteLine(Repeat("Str", 3));