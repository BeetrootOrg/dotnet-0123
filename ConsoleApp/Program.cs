// 1. Calculate N! = 1 * 2 * 3 .. * N
// Example:
// 0! = 1
// 1! = 1
// 2! = 2
// 3! = 6 (1 * 2 * 3)
// 4! = 24 (1 * 2 * 3 * 4)
long Factorial(int n)
{
    return n == 0 ? 1 : n * Factorial(n - 1);
}

// 2. Write all numbers from N to 1 in Console
// 5 -> 5 4 3 2 1
void WriteNumbers(int n)
{
    Console.WriteLine(n);
    if (n > 1)
    {
        WriteNumbers(n - 1);
    }
}

Console.WriteLine(Factorial(0));
Console.WriteLine(Factorial(1));
Console.WriteLine(Factorial(2));
Console.WriteLine(Factorial(5));

WriteNumbers(1);
WriteNumbers(10);