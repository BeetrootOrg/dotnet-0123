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

Random random = new((int)DateTime.Now.Ticks);
Console.WriteLine(random.Next());
Console.WriteLine(random.Next(10)); // [0; 10)
Console.WriteLine(random.Next(-10, 10)); // [-10; 10)

float f1 = random.NextSingle(); // [0.0; 1.0)
Console.WriteLine(f1);

double d1 = random.NextDouble(); // [0.0; 1.0)
Console.WriteLine(d1);
