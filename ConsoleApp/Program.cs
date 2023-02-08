// 1. Calculate N! = 1 * 2 * 3 .. * N
// Example:
// 0! = 1
// 1! = 1
// 2! = 2
// 3! = 6 (1 * 2 * 3)
// 4! = 24 (1 * 2 * 3 * 4)
long Factorial(int n)
{
    return n == 0
    ? 1
    : n * Factorial(n - 1);
}
Console.WriteLine(Factorial(5));

// 2. Write all numbers from N to 1 in Console
// 5 -> 5 4 3 2 1
void WriteNumbers(int n)
{
    for (int i = n; i >= 1; i--)
    {
        Console.Write($"{i} ");
    }
}
WriteNumbers(5);