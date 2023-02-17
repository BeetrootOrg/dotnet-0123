const int n = 5;

int fib1=1;
int fib2=1;
int fib3;

for(int r=1;r<=n;r++)
{
    fib3=fib1+fib2;
    fib1=fib2;
    fib2=fib3;
}
System.Console.WriteLine(fib1);