 static int Sum (int a, int b)
{
    var sum = a + b;
    return sum;   
}

int a = 15;
int b = 20;
System.Console.WriteLine(Sum(a, b));

static int SumOneLine (int a, int b) => a + b;

System.Console.WriteLine(SumOneLine(42, 80));

int inc = 0;
void Increment()
{
    ++inc;
}

Increment();
Increment();
System.Console.WriteLine(inc);

void Assing42(int c)
{
      c = 42;
}

Assing42(a);
System.Console.WriteLine(a);

void Assing42Ref (ref int c)
{
    c = 42;
}

Assing42Ref(ref a);
System.Console.WriteLine(a);

void Assing42Out (out int c)
{
    c = 42;
}
int d;
Assing42Out(out d);
System.Console.WriteLine(d);

Assing42Out(out int e);
System.Console.WriteLine(e);

