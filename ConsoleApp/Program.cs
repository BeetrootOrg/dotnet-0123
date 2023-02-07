// "Find the Maximum" functions
int Max2(int a, int b)
{
    return a > b ? a : b;
}
int Max3(int a, int b, int c)
{
    return Max2(Max2(a, b), Max2(b, c));
}
int Max4(int a, int b, int c, int d)
{
    return Max2(Max3(a, b, c), d);
}

// "Find the Minimum" functions
int Min2(int a, int b)
{
    return a < b ? a : b;
}
int Min3(int a, int b, int c)
{
    return Min2(Min2(a, b), Min2(b, c));
}
int Min4(int a, int b, int c, int d)
{
    return Min2(Min3(a, b, c), d);
}

bool TrySumIfOdd(int a, int b, out int result)
{
    result = a + b;
    return result % 2 != 0;
}

// Extra exercise
string Repeat(string str, int number)
{
    return number <= 0
    ? ""
    : number > 1
    ? str + Repeat(str, number - 1)
    : str;
}

Console.WriteLine(Max2(2, 2));
Console.WriteLine(Max3(3, 7, 8));
Console.WriteLine(Max4(3, 7, 2, 5));

Console.WriteLine(Min2(-1, 1));
Console.WriteLine(Min3(3, 0, 9));
Console.WriteLine(Min4(9, 7, 2, 4));

Console.WriteLine(TrySumIfOdd(1, 6, out int result));
Console.WriteLine(result);

Console.WriteLine(Repeat("hell0", 4));