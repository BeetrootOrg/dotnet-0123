
static int Sum(int a, int b)
{
    var sum = a + b;
    return sum;
}
//static int sumoneline(int a,int b)=>a+b;{return a+b;}
static int SumOneLine(int a, int b)
{
    return a + b;
}

int a = 15;
int b = 20;
System.Console.WriteLine(Sum(a, b));
System.Console.WriteLine(SumOneLine(42, 80));

int inc = 0;
void IncrementWithClosure()
{
    ++inc;
}

void IncrementWithoutClosure()
{
    int inc = 0;
    ++inc;
}
IncrementWithClosure();
IncrementWithClosure();
IncrementWithoutClosure();

System.Console.WriteLine(inc);

void Assign42(int param)
{
    param = 42;
}
Assign42(a);
System.Console.WriteLine(a);


void Assign42ref(ref int param)
{
    param = 42;
}
Assign42ref(ref a);
System.Console.WriteLine(a);

void Assign42Out(out int param)
{
    param = 42;

}
int temp1;
Assign42Out(out temp1);
System.Console.WriteLine(temp1);
Assign42Out(out int temp2);
System.Console.WriteLine(temp2);

void RefNoAssign(ref int param)
{

}
int temp3 = 15;
RefNoAssign(ref temp3);
System.Console.WriteLine(temp3);

bool TryReadInt(out int result)
{


    string input = Console.ReadLine();
    return int.TryParse(input, out result);


    // if (int.TryParse(input,out result))
    // {
    //     return true;
    // }
    // else
    //{
    //     return false;
    // } плохой стиль програмирования
}
if (TryReadInt(out int temp4))
{
    System.Console.WriteLine(temp4);
}

bool TryDivideByThree(int num, out int result)
{
    if (num % 3 == 0)
    {
        result = num / 3;
        return true;
    }
    else
    {
        result = 0;
        return false;
    }
}
bool result = TryDivideByThree(6, out temp4);
System.Console.WriteLine($"TryDivideByThree(6) = {result}.Result = {temp4}");
result = TryDivideByThree(7, out temp4);
System.Console.WriteLine($"TryDivideByThree(7) = {result}.Result = {temp4}");

int Fibonacci(int n)
{
    if (n == 1)
    {
        return 1;
    }
    if (n == 2)
    {
        return 1;
    }
    return Fibonacci(n - 1) + Fibonacci(n - 2);

}

int FibonacciWithTernary(int n)
{
    return n == 1
        ? 1
        : n == 2
        ? 1
        : Fibonacci(n - 1) + Fibonacci(n - 2);
}
System.Console.WriteLine(Fibonacci(3));
System.Console.WriteLine(Fibonacci(5));
System.Console.WriteLine(FibonacciWithTernary(3));
System.Console.WriteLine(FibonacciWithTernary(5));
