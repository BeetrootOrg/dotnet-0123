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