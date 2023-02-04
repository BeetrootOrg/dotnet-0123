/*
int a = 42;
int b = 41;
int c = a + b;

Console.WriteLine (a + b);
Console.WriteLine (c);

Console.WriteLine (6 / 3);
Console.WriteLine (7 / 3);
Console.WriteLine (8 / 3);
Console.WriteLine (9 / 3);

Console.WriteLine ("result of %");
Console.WriteLine (6 % 3);
Console.WriteLine (7 % 3);
Console.WriteLine (8 % 3);
Console.WriteLine (9 % 3);




float f = 1.5F;
double d = 1.2;
decimal dl = 1.3M;

Console.WriteLine (f); Console.WriteLine (d); Console.WriteLine (dl);
Console.WriteLine(d / 2.5);

Console.WriteLine ("MATH -- float");
Console.WriteLine (6 / 3F);
Console.WriteLine (7 / 3F);
Console.WriteLine (8 / 3F);
Console.WriteLine (9 / 3F);


Console.WriteLine ("MATH -- double");
Console.WriteLine (6 / 3.0);
Console.WriteLine (7 / 3.0);
Console.WriteLine (8 / 3.0);
Console.WriteLine (9 / 3.0);

Console.WriteLine ("MATH -- decimal");
Console.WriteLine (6 / 3.0M);
Console.WriteLine (7 / 3.0M);
Console.WriteLine (8 / 3.0M);
Console.WriteLine (9 / 3.0M);


*/

/*
bool b1 = true;
bool b2 = false;

Console.WriteLine(b1);
Console.WriteLine(b2);

Console.WriteLine("'AND'");
Console.WriteLine(b1 && b2);
Console.WriteLine($"true and true = {true && true}");
Console.WriteLine($"true and false = {true && false}");
Console.WriteLine($"false and true = {false && true}");
Console.WriteLine($"false and false = {false  && false}");


Console.WriteLine("'OR'");
Console.WriteLine(b1 || b2);
Console.WriteLine($"true and true = {true || true}");
Console.WriteLine($"true and false = {true || false}");
Console.WriteLine($"false and true = {false || true}");
Console.WriteLine($"false and false = {false  || false}");


Console.WriteLine("Comparison");
int i1 = 42;
int i2 = 42;
int i3 = 44;
Console.WriteLine($"i1 == i2 =  {i1 == i2}");
Console.WriteLine($"i1 == i3 =  {i1 == i3}");
Console.WriteLine($"i1 != i2 =  {i1 != i2}");
Console.WriteLine($"i1 != i3 =  {i1 != i3}");

Console.WriteLine("Comparison go on");
Console.WriteLine($"i1 > i2 =  {i1 > i2}");
Console.WriteLine($"i1 >= i2 =  {i1 >= i2}");
Console.WriteLine($"i1 < i2 =  {i1 < i2}");
Console.WriteLine($"i1 <= i2 =  {i1 <= i2}");

Console.WriteLine("Comparison go on");
Console.WriteLine($"i1 > i3 =  {i1 > i3}");
Console.WriteLine($"i1 >= i3 =  {i1 >= i3}");
Console.WriteLine($"i1 < i3 =  {i1 < i3}");
Console.WriteLine($"i1 <= i3 =  {i1 <= i3}");


Console.WriteLine("Combination");
Console.WriteLine($"b1 || b2 || (i1 >= i3 && i2 <=i1) = {b1 || b2 || (i1 >= i3 && i2 <=1)}");

Console.WriteLine("Decimal / Float");
decimal n1 = 7.0M;
float n2 = 3.0F;
Console.WriteLine(n1 / (decimal)n2);
Console.WriteLine((float)n1 / n2);

Console.WriteLine("INT / Float");
float n3 = 6.0F;
int n4 = 7;
Console.WriteLine(n3 / n4);

Console.WriteLine("Increment / Decrement");
int inc = 42;
Console.WriteLine ($"++inc = {++inc}");
Console.WriteLine ($"inc++ = {inc++}");
Console.WriteLine ($"inc = {inc}");
Console.WriteLine ($"--inc = {--inc}");
Console.WriteLine ($"inc-- = {inc--}");
Console.WriteLine ($"inc = {inc}");

*/

Console.WriteLine("MATH");
Console.WriteLine($"ABS = {Math.Abs(-42.2)}"); 

Console.WriteLine($"Round (42) = {Math.Round(42.0)}");
Console.WriteLine($"Round (42.2) = {Math.Round(42.2)}");
Console.WriteLine($"Round (42.6) = {Math.Round(42.6)}");

Console.WriteLine($"Ceiling (42) = {Math.Ceiling(42.0)}");
Console.WriteLine($"Ceiling (42.2) = {Math.Ceiling(42.2)}");
Console.WriteLine($"Ceiling (42.6) = {Math.Ceiling(42.6)}");

Console.WriteLine($"Floor (42) = {Math.Floor(42.0)}");
Console.WriteLine($"Floor (42.2) = {Math.Floor(42.2)}");
Console.WriteLine($"Floor (42.6) = {Math.Floor(42.6)}");

Console.WriteLine($"Truncate (42) = {Math.Truncate(42.0)}");
Console.WriteLine($"Truncate (42.2) = {Math.Truncate(42.2)}");
Console.WriteLine($"Truncate (42.6) = {Math.Truncate(42.6)}");


Console.WriteLine("NEGATIVE");

Console.WriteLine($"Round (-42) = {Math.Round(-42.0)}");
Console.WriteLine($"Round (-42.2) = {Math.Round(-42.2)}");
Console.WriteLine($"Round (-42.6) = {Math.Round(-42.6)}");

Console.WriteLine($"Ceiling (-42) = {Math.Ceiling(-42.0)}");
Console.WriteLine($"Ceiling (-42.2) = {Math.Ceiling(-42.2)}");
Console.WriteLine($"Ceiling (-42.6) = {Math.Ceiling(-42.6)}");

Console.WriteLine($"Floor (-42) = {Math.Floor(-42.0)}");
Console.WriteLine($"Floor (-42.2) = {Math.Floor(-42.2)}");
Console.WriteLine($"Floor (-42.6) = {Math.Floor(-42.6)}");

Console.WriteLine($"Truncate (-42) = {Math.Truncate(-42.0)}");
Console.WriteLine($"Truncate (-42.2) = {Math.Truncate(-42.2)}");
Console.WriteLine($"Truncate (-42.6) = {Math.Truncate(-42.6)}");

Console.WriteLine($"POW (9, 4) = {Math.Pow(9, 4)}");
Console.WriteLine($"POW (1.5, 4.5) = {Math.Pow(1.5, 4.5)}");

// x^2 + 3x + 5
int x = 5;

Console.WriteLine($"x^2 + 3x + 5 = {Math.Pow (x, 2) + 3*x + 5}");

Console.WriteLine("Byte AND");
// 6 & 4 => 110 & 100 => 100 =>4
// 6 & 5 => 110 & 101 => 100 =>4
Console.WriteLine($"6 & 4 = {6&4}");
Console.WriteLine($"6 & 5 = {6&5}");
Console.WriteLine($"8 & 4 = {8&4}");


Console.WriteLine("Byte OR");
// "або" |
// 6 | 4 => 110 | 100 => 110 =>6
// 6 | 5 => 110 | 101 => 111 =>7
// 8 | 4 => 1000 | 0100 => 1100 =>12
Console.WriteLine($"6 | 4 = {6|4}");
Console.WriteLine($"6 | 5 = {6|5}");
Console.WriteLine($"8 | 4 = {8|4}");


Console.WriteLine("Byte XOR");
// "виключення" -- вертає одиницю, якщо значення бітів різні
// 6 ^ 4 => 110 ^ 100 => 010 =>2
// 6 ^ 5 => 110 ^ 101 => 011 =>3
// 8 ^ 4 => 1000 ^ 0100 => 1100 =>12
Console.WriteLine($"6 ^ 4 = {6^4}");
Console.WriteLine($"6 ^ 5 = {6^5}");
Console.WriteLine($"8 ^ 4 = {8^4}");

Console.WriteLine("Оператори зміщення");
//  зміщують біти вправо, або вліво
//  3<<2 => 0011<<2 => 1100 =>12
Console.WriteLine($"3<<2 = {3<<2}");

//  3>>1 => 0011>1 => 0001 =>1
Console.WriteLine($"3>>1 = {3>>1}");


