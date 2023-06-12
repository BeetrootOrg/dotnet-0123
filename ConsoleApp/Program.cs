int a = 42;
int b = 41;
int c = a + b;
Console.WriteLine(a + b);
Console.WriteLine(c);

Console.WriteLine(6 / 3);
Console.WriteLine(7 / 3);
Console.WriteLine(8 / 3);
Console.WriteLine(9 / 3);

Console.WriteLine("Result of %");
Console.WriteLine(6 % 3);
Console.WriteLine(7 % 3);
Console.WriteLine(8 % 3);
Console.WriteLine(9 % 3);

Console.WriteLine("COMPARISON");
int i1 = 42;
int i2 = 42;
int i3 = 43;
Console.WriteLine($"i1 == i2 = {i1 == i2}");
Console.WriteLine($"i1 == i3 = {i1 == i3}");
Console.WriteLine($"i1 != i2 = {i1 != i2}");
Console.WriteLine($"i1 != i3 = {i1 != i3}");
int x = 2;
int y = 4;
Console.WriteLine($"-6*x^3+5*x^2-10*x+15 = {-6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15} ");
Console.WriteLine($"abs(x)*sin(x) = {Math.Abs(x) * Math.Sin(x)}");
Console.WriteLine($"2*pi*x = {2 * Math.PI * x}");
Console.WriteLine($"max(x,y) = {Math.Max(x, y)}");