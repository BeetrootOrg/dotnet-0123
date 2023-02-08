// 1. Calculate N! = 1 * 2 * 3 .. * N
// Example:
// 0! = 1
// 1! = 1
// 2! = 2
// 3! = 6 (1 * 2 * 3)
// 4! = 24 (1 * 2 * 3 * 4)

// System.Console.WriteLine("Enter n:");
// int n = Console.ReadLine ();


int init = 1;
int n = 5;
long value = 1;


/*
long Factorial(int n,)
{
    sum = ;
    if (init != n )
    
    return 42;
}

*/

for (int i = init; i <= n; ++i)
{
    value *= i;
}

System.Console.WriteLine(value);

