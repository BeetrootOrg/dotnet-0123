int N = 10;
int f_n1 = 1;
int f_n2 = 1;
for (int i = 3; i <= N; i++ )
{
    int sum = f_n1 + f_n2;
    f_n1 = f_n2;
    f_n2 = sum;
}

System.Console.WriteLine($"{N}-member of Fibonacci = {f_n2}");

static int Sum(int a, int b)
{
   int sum = a + b;
   return sum;  
}

int a = 10;
int b = 5;
System.Console.WriteLine(Sum(a, b));