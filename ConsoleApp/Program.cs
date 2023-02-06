using System.Diagnostics;

static int Sum(int a, int b)
{
    int sum = a + b;
    return sum;
}

// static int SumOneLine(int a, int b) => a + b; // { return a + b; }
static int SumOneLine(int a, int b)
{
    return a + b; // { return a + b; }
}

int a = 15;
int b = 20;
Console.WriteLine(Sum(a, b));
Console.WriteLine(SumOneLine(42, 80));

int inc = 0;
void IncrementWithClosure()
{
    ++inc;
}

static void IncrementWithoutClosure()
{
    int inc = 0;
#pragma warning disable IDE0059
    ++inc;
#pragma warning restore all
}

IncrementWithClosure();
IncrementWithClosure();
IncrementWithoutClosure();

Console.WriteLine(inc);

void Assign42(int param)
{
    param = 42;
}

Assign42(a);
Console.WriteLine(a);

void Assign42Ref(ref int param)
{
    param = 42;
}

Assign42Ref(ref a);
Console.WriteLine(a);

void Assign42Out(out int param)
{
    param = 42;
}

int temp1;
Assign42Out(out temp1);
Console.WriteLine(temp1);

Assign42Out(out int temp2);
Console.WriteLine(temp2);

void RefNoAssign(ref int param) { }

// COMPILATION ERROR
// void OutNoAssign(out int param) { }

int temp3 = 15;
RefNoAssign(ref temp3);
Console.WriteLine(temp3);

bool TryReadInt(out int result)
{
    // string input = Console.ReadLine();
    return int.TryParse("42", out result);
}

if (TryReadInt(out int temp4))
{
    Console.WriteLine(temp4);
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

bool TryDivideByThreeBetter(int num, out int result)
{
    if (num % 3 == 0)
    {
        result = num / 3;
        return true;
    }

    result = 0;
    return false;
}


bool TryDivideByThreeBest(int num, out int result)
{
    result = num / 3;
    return num % 3 == 0;
}

bool result = TryDivideByThree(6, out temp4);
Console.WriteLine($"TryDivideByThree(6) = {result}. Result = {temp4}");

result = TryDivideByThreeBetter(7, out temp4);
Console.WriteLine($"TryDivideByThree(7) = {result}. Result = {temp4}");

result = TryDivideByThreeBest(7, out temp4);
Console.WriteLine($"BEST VERSION: TryDivideByThree(7) = {result}. Result = {temp4}");

long Fibonacci(int n)
{
#pragma warning disable IDE0046
    if (n == 1)
    {
        return 1;
    }

    if (n == 2)
    {
        return 1;
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
#pragma warning restore IDE0046
}


long FibonacciLoop(int n)
{
    long prev = 1;
    long curr = 1;

    int i = n - 2;
    while (i-- > 0)
    {
        long temp = prev;
        prev = curr;
        curr += temp;
    }

    return curr;
}

long FibonacciWithTernary(int n)
{
    return n == 1
        ? 1
        : n == 2
        ? 1
        : FibonacciWithTernary(n - 1) + FibonacciWithTernary(n - 2);
}

Console.WriteLine(Fibonacci(3));
Console.WriteLine(Fibonacci(5));
Console.WriteLine(FibonacciWithTernary(3));

const int n = 30;
Stopwatch sw = new();

sw.Start();
Console.WriteLine(FibonacciLoop(n));
sw.Stop();

Console.WriteLine($"Elapsed: {sw.ElapsedMilliseconds}ms");

sw.Reset();

sw.Start();
Console.WriteLine(Fibonacci(n));
sw.Stop();

Console.WriteLine($"Elapsed: {sw.ElapsedMilliseconds}ms");

void PrintHello(string name = "Dima")
{
    Console.WriteLine($"Hello, {name}!");
}

PrintHello("Dima");
PrintHello();
PrintHello("World");

void PrintNumbersLoop(int a, int b)
{
    for (int i = a; i <= b; i++)
    {
        Console.WriteLine(i);
    }
}

void PrintNumbersRecursion(int a, int b)
{
    Console.WriteLine(a);
    if (a != b)
    {
        PrintNumbersRecursion(a + 1, b);
    }
}

PrintNumbersLoop(5, 15);
PrintNumbersRecursion(5, 15);