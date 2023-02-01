int a = 42;
int b = 41;
int c = a + b;

Console.WriteLine(a + b);
Console.WriteLine(c);

a += b;
Console.WriteLine(a);

Console.WriteLine(6 / 3);
Console.WriteLine(7 / 3);
Console.WriteLine(8 / 3);
Console.WriteLine(9 / 3);

Console.WriteLine("RESULT OF %");
Console.WriteLine(6 % 3);
Console.WriteLine(7 % 3);
Console.WriteLine(8 % 3);
Console.WriteLine(9 % 3);

float f = 1.1F;
double d = 1.2;
decimal dl = 1.3M;

Console.WriteLine(f);
Console.WriteLine(d);
Console.WriteLine(dl);
Console.WriteLine(d / 2.5);

Console.WriteLine("FLOAT MATH");
Console.WriteLine(6.0F / 3.0F);
Console.WriteLine(7.0F / 3.0F);
Console.WriteLine(8.0F / 3.0F);
Console.WriteLine(9.0F / 3.0F);

Console.WriteLine("DOUBLE MATH");
Console.WriteLine(6.0 / 3.0);
Console.WriteLine(7.0 / 3.0);
Console.WriteLine(8.0 / 3.0);
Console.WriteLine(9.0 / 3.0);

Console.WriteLine("DECIMAL MATH");
Console.WriteLine(6.0M / 3.0M);
Console.WriteLine(7.0M / 3.0M);
Console.WriteLine(8.0M / 3.0M);
Console.WriteLine(9.0M / 3.0M);

bool b1 = true;
bool b2 = false;

Console.WriteLine(b1);
Console.WriteLine(b2);

Console.WriteLine("AND");
Console.WriteLine(b1 && b2);
Console.WriteLine($"true and true = {true && true}");
Console.WriteLine($"false and true = {false && true}");
Console.WriteLine($"true and false = {true && false}");
Console.WriteLine($"false and false = {false && false}");

Console.WriteLine("OR");
Console.WriteLine(b1 || b2);
Console.WriteLine($"true and true = {true || true}");
Console.WriteLine($"false and true = {false || true}");
Console.WriteLine($"true and false = {true || false}");
Console.WriteLine($"false and false = {false || false}");

Console.WriteLine("COMPARISON");
int i1 = 42;
int i2 = 42;
int i3 = 43;
Console.WriteLine($"i1 == i2 = {i1 == i2}");
Console.WriteLine($"i1 == i3 = {i1 == i3}");
Console.WriteLine($"i1 != i2 = {i1 != i2}");
Console.WriteLine($"i1 != i3 = {i1 != i3}");