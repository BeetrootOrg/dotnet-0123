int a = 5;
long Factorial(int n)
{
    if (n == 0)
    {
        return 1;
    }
    return n * Factorial(n - 1);
}
Console.WriteLine(Factorial(a));

void WriteNumbers(int n)
{
    Console.WriteLine(n);
    if (n != 1)
    {
        WriteNumbers(n - 1);
    }
}
WriteNumbers(a);