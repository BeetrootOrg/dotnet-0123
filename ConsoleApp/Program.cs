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

static int SumOneLine (int a, int b) => a + b;

int a = 10;
int b = 5;
System.Console.WriteLine(Sum(a, b));
System.Console.WriteLine(SumOneLine(a, b));

int inc = 0;
void Increment ()
{
    ++inc;
}

Increment();
Increment();

System.Console.WriteLine(inc);

void Assign42 (int param)
{
    param = 42;
}

Assign42(a);
System.Console.WriteLine(a);

void Assign42Ref (ref int param)
{
    param = 42;
}
Assign42Ref(ref a);
System.Console.WriteLine(a);

// void Assign42Out (out int param1);
// {
//     param1 = 42;
// }
// Assign42Out();

void Repeat(string X, int N)
{
    string r = X;
    for (int i = 2; i <= N; i++ )
    {
        r += X;
    }
    System.Console.WriteLine(r);
};

String x = "mayday_";
int n = 3;
Repeat(x, n);
