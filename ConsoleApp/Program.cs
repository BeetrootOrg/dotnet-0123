﻿int a = 5;
long Factorial(int n)
{
    if (n==0)
    {
        return 1;
    }
    return n*Factorial(n-1);
}
Console.WriteLine(Factorial(a));

void WriteNumbers(int n)
{
    if (n ==1 )
    {
        Console.WriteLine(1);
    }
    else
    {
        Console.WriteLine(n);
        WriteNumbers(n-1);
    }
}
WriteNumbers(a);