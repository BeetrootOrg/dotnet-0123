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