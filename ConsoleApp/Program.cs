int n = 10;


int fib1 = 1;
int fib2 = 0;
int fib3 = 0;

for (int i = 1; i<= n; ++i)
{
    fib3 = fib1;
    System.Console.WriteLine(fib1);
    fib1 = fib1 + fib2;
    fib2 = fib3;

}
