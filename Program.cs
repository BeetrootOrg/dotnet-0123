// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int Max2(int a, int b)
{
    if (a >= b)
    {
        return a;
    }
    else
    {
        return b;
    }
}

int Max3(int a, int b, int c)
{
    if (a >= b & a >= c)
    {
        return a;
    }
    else if (b >= a & b >= c)
    {
        return b;
    }
    else
    {
        return c;
    }
}

int Max4(int a, int b, int c, int d)
{
    if (a >= b & a >= c & a >= d)
    {
        return a;
    }
    else if (b >= a & b >= c & b >= d)
    {
        return b;
    }
    else if (c >= a & c >= b & c >= d)
    {
        return c;
    }
    else
    {
        return d;
    }
}
int Max(int a, int b, int c = int.MinValue, int d = int.MinValue, int e = int.MinValue)
{
    if (a >= b & a >= c & a >= d & a >= e)
    {
        return a;
    }
    else if (b >= a & b >= c & b >= d & b >= e)
    {
        return b;
    }
    else if (c >= a & c >= b & c >= d & c >= e)
    {
        return c;
    }
    else if (d >= a & d >= b & d >= c & d >= e)
    {
        return d;
    }
    else
    {
        return e;
    }
}

int Min2(int a, int b)
{
    if (a <= b)
    {
        return a;
    }
    else
    {
        return b;
    }
}

int Min3(int a, int b, int c)
{
    if (a <= b & a <= c)
    {
        return a;
    }
    else if (b <= a & b <= c)
    {
        return b;
    }
    else
    {
        return c;
    }
}

int Min4(int a, int b, int c, int d)
{
    if (a <= b & a <= c & a <= d)
    {
        return a;
    }
    else if (b <= a & b <= c & b <= d)
    {
        return b;
    }
    else if (c <= a & c <= b & c <= d)
    {
        return c;
    }
    else
    {
        return d;
    }
}
int Min(int a, int b, int c = int.MaxValue, int d = int.MaxValue, int e = int.MaxValue)
{
    if (a <= b & a <= c & a <= d & a <= e)
    {
        return a;
    }
    else if (b <= a & b <= c & b <= d & b <= e)
    {
        return b;
    }
    else if (c <= a & c <= b & c <= d & c <= e)
    {
        return c;
    }
    else if (d <= a & d <= b & d <= c & d <= e)
    {
        return d;
    }
    else
    {
        return e;
    }
}

bool TrySumIfOdd(int a, int b, out int result)

{
    int sum = 0;
    if (a >= b)
    {
        int c = b;
        b = a;
        a = c;
    }
    for (int i = a; i <= b; i++)
    {
        sum += i;
    }
    result = sum;
    if (sum % 2 == 1)
    {
        return true;
    }
    else
    {
        return false;
    }
}
string A ="";
string Repeat(string X, int N)
{
    if (N > 0)
    {
        A += X;
        Repeat(X, N-1);
    }
    return A;
}

Console.WriteLine(Min(4, 3, 4, 7));
Console.WriteLine(Repeat("str",4));