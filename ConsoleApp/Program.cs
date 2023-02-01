int a = 42;
int b = 41;
int c = a + b;

Console.WriteLine(a + b);
Console.WriteLine(c);

a += b; // the same as a = a + b
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

Console.WriteLine($"i1 > i2 = {i1 > i2}");
Console.WriteLine($"i1 >= i2 = {i1 >= i2}");
Console.WriteLine($"i1 < i2 = {i1 < i2}");
Console.WriteLine($"i1 <= i2 = {i1 <= i2}");

Console.WriteLine($"i1 > i3 = {i1 > i3}");
Console.WriteLine($"i1 >= i3 = {i1 >= i3}");
Console.WriteLine($"i1 < i3 = {i1 < i3}");
Console.WriteLine($"i1 <= i3 = {i1 <= i3}");

Console.WriteLine("COMBINATION");
Console.WriteLine($"b1 || b2 || (i1 >= i3 && i2 <= i1) = {b1 || b2 || (i1 >= i3 && i2 <= i1)}");

Console.WriteLine("DECIMAL / FLOAT");
decimal n1 = 7.0M;
float n2 = 6.0F;
Console.WriteLine(n1 / (decimal)n2);
Console.WriteLine((float)n1 / n2);

Console.WriteLine("INT / FLOAT");
float n3 = 6.0F;
int n4 = 7;
Console.WriteLine(n3 / n4);

Console.WriteLine("INCREMENT/DECREMENT");
int inc = 42;
Console.WriteLine($"++inc = {++inc}");
Console.WriteLine($"inc++ = {inc++}");
Console.WriteLine($"inc = {inc}");
Console.WriteLine($"--inc = {--inc}");
Console.WriteLine($"inc-- = {inc--}");
Console.WriteLine($"inc = {inc}");

Console.WriteLine("MATH");
Console.WriteLine($"ABS(51) = {Math.Abs(51)}");
Console.WriteLine($"ABS(-42.2) = {Math.Abs(-42.2)}");

Console.WriteLine($"ROUND(42) = {Math.Round(42.0)}");
Console.WriteLine($"ROUND(42.2) = {Math.Round(42.2)}");
Console.WriteLine($"ROUND(42.6) = {Math.Round(42.6)}");

Console.WriteLine($"CEILING(42) = {Math.Ceiling(42.0)}");
Console.WriteLine($"CEILING(42.2) = {Math.Ceiling(42.2)}");
Console.WriteLine($"CEILING(42.6) = {Math.Ceiling(42.6)}");

Console.WriteLine($"FLOOR(42) = {Math.Floor(42.0)}");
Console.WriteLine($"FLOOR(42.2) = {Math.Floor(42.2)}");
Console.WriteLine($"FLOOR(42.6) = {Math.Floor(42.6)}");

Console.WriteLine($"TRUNCATE(42) = {Math.Truncate(42.0)}");
Console.WriteLine($"TRUNCATE(42.2) = {Math.Truncate(42.2)}");
Console.WriteLine($"TRUNCATE(42.6) = {Math.Truncate(42.6)}");

Console.WriteLine("NEGATIVE NUMBERS");

Console.WriteLine($"ROUND(-42) = {Math.Round(-42.0)}");
Console.WriteLine($"ROUND(-42.2) = {Math.Round(-42.2)}");
Console.WriteLine($"ROUND(-42.6) = {Math.Round(-42.6)}");

Console.WriteLine($"CEILING(-42) = {Math.Ceiling(-42.0)}");
Console.WriteLine($"CEILING(-42.2) = {Math.Ceiling(-42.2)}");
Console.WriteLine($"CEILING(-42.6) = {Math.Ceiling(-42.6)}");

Console.WriteLine($"FLOOR(-42) = {Math.Floor(-42.0)}");
Console.WriteLine($"FLOOR(-42.2) = {Math.Floor(-42.2)}");
Console.WriteLine($"FLOOR(-42.6) = {Math.Floor(-42.6)}");

Console.WriteLine($"TRUNCATE(-42) = {Math.Truncate(-42.0)}");
Console.WriteLine($"TRUNCATE(-42.2) = {Math.Truncate(-42.2)}");
Console.WriteLine($"TRUNCATE(-42.6) = {Math.Truncate(-42.6)}");

Console.WriteLine($"POW(9, 4) = {Math.Pow(9, 4)}");
Console.WriteLine($"POW(i1, i2) = {Math.Pow(i1, i2)}");
Console.WriteLine($"9^4 = {9 ^ 4}"); // NOT THE SAME AS POW!
Console.WriteLine($"POW(1.3, 2.5) = {Math.Pow(1.3, 2.5)}");

// x^2+3*x+5
int x = 5;
Console.WriteLine($"x^2+3*x+5={(x * x) + (3 * x) + 5}"); // PREFERABLE IF POSSIBLE
Console.WriteLine($"x^2+3*x+5={Math.Pow(x, 2) + (3 * x) + 5}");

string s1 = "Hello, Dima";
Console.WriteLine(s1);

Console.WriteLine($"3 * PI = {3 * Math.PI}");

// 0 -> 0
// 1 -> 1
// 2 -> 10
// 3 -> 11
// 4 -> 100
// 5 -> 101
// 6 -> 110
// 7 -> 111
// 8 -> 1000
// ...
// 255 -> 11111111
// 256 -> 100000000

// 6&4 -> 110&100=100 -> 4
Console.WriteLine("BYTE AND");
Console.WriteLine($"6&4={6 & 4}");

// 6&5 -> 110&101=100 -> 4
Console.WriteLine($"6&5={6 & 5}");

// 8&4 -> 1000&0100=0000 -> 0
Console.WriteLine($"8&4={8 & 4}");

// 6|4 -> 110|100=110 -> 6
Console.WriteLine("BYTE OR");
Console.WriteLine($"6|4={6 | 4}");

// 6|5 -> 110|101=111 -> 7
Console.WriteLine($"6|5={6 | 5}");

// 8|4 -> 1000|0100=1100 -> 12
Console.WriteLine($"8|4={8 | 4}");

// 6^4 -> 110^100=010 -> 2
Console.WriteLine("BYTE XOR");
Console.WriteLine($"6^4={6 ^ 4}");

// 6^5 -> 110^101=011 -> 3
Console.WriteLine($"6^5={6 ^ 5}");

// 8^4 -> 1000^0100=1100 -> 12
Console.WriteLine($"8^4={8 ^ 4}");

// 3<<2 -> 0011<<2 -> 1100 -> 12
Console.WriteLine($"3<<2={3 << 2}");

// 3>>1 -> 0011>>1 -> 1 -> 1
Console.WriteLine($"3>>1={3 >> 1}");