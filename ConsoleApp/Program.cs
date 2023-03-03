using ConsoleApp;

Complex c1 = new();
Complex c2 = new();

Console.WriteLine(c1);
Console.WriteLine(c2);
// COMPILATION ERROR WITHOUT OPERATOR OVERLOAD
// Console.WriteLine(c1 == c2);
Console.WriteLine(c1.Equals(c2));
Console.WriteLine(c1.GetHashCode());
Console.WriteLine(c2.GetHashCode());

Console.WriteLine(c1.Imaginary);
Console.WriteLine(c1.Real);

Complex c3 = new(5);

Console.WriteLine(c3.Imaginary);
Console.WriteLine(c3.Real);

Complex c4 = new(5, 2);
Console.WriteLine(c4);

TestValueType(c4);
Console.WriteLine($"AFTER CHANGE = {c4}");

static void TestValueType(Complex c)
{
    c.Real += 1;
    c.Imaginary += 1;
}

Complex c5 = new(10, 3);
Console.WriteLine(c5);

Console.WriteLine(c4 + c5);
Console.WriteLine(c4 - c5);

Console.WriteLine(c5 == c4);
Console.WriteLine(c5 != c4);

Console.WriteLine(c5 + 10);

Complex c6 = new(3, 4);
double d1 = (double)c6;

Console.WriteLine(d1);

System.Numerics.Complex c7 = c6;
Console.WriteLine(c7);

Console.WriteLine(c6[0]);
Console.WriteLine(c6[1]);

(c6[0], c6[1]) = (c6[1], c6[0]);
Console.WriteLine(c6);

RecordStruct rs = new()
{
    Num1 = 42,
    Num2 = 100
};

Console.WriteLine(rs);

Complex c8 = c6.Prototype();
Console.WriteLine(c8);