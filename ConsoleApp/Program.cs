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