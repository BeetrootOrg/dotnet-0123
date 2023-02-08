static int Sum(int a, int b)
{
    int sum = a + b;
    return sum;
}

static int Mul(int a, int b)
{
    int mul = a * b;
    return mul;
}

int result = Sum(42, 80);
Console.WriteLine(result);

result = Mul(10, 12);
Console.WriteLine(result);

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

static long Fibonacci(int n)
{
#pragma warning disable IDE0046
    if (n == 1)
    {
        return 1;
    }

    if (n == 2)
    {
        return 1;
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
#pragma warning restore IDE0046
}

Fibonacci(3);
Fibonacci(5);