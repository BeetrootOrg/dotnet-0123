const int a = 10;
const int b = 5;


int Max(int a, int b, int c = -2147483648, int d = -2147483648)
{
    int max = a;
    if (b > max)
    {
        max = b;
    }
    if (c > max)
    {
        max = c;
    }
    if (d > max)
    {
        max = d;
    }
    return max;
}

int Min(int a, int b, int c = 2147483647, int d = 2147483647)
{
    int min = a;
    if (b < min)
    {
        min = b;
    }
    if (c < min)
    {
        min = c;
    }
    if (d < min)
    {
        min = d;
    }
    return min;
}

Console.WriteLine($"a = {a}");
Console.WriteLine($"b = {b}");
Console.WriteLine($"Max(a, b) = {Max(a, b)}");
Console.WriteLine($"Min(a, b) = {Min(a, b)}");

bool TrySumIfOdd(int a, int b, out int result)
{
    result = a + b;
    return ((a + b) % 2) == 1;
}
Console.WriteLine($"TrySumIfOdd(a, b) = {TrySumIfOdd(a, b, out int result)}. Result = {result}");

string input = "str";

void Repeat(string input, int num)
{
    if (num == 1)
    {
        Console.Write(input);
    }
    else
    {
        Console.Write(input);
        Repeat(input, num - 1);
    }

}

Repeat(input, b);