int a=42;
int b=41;
int c=a+b;
Console.WriteLine(a+b);
Console.WriteLine(c);

Console.WriteLine(6/3);
Console.WriteLine(7/3);
Console.WriteLine(8/3);
Console.WriteLine(9/3);
Console.WriteLine();

Console.WriteLine(6%3);
Console.WriteLine(7%3);
Console.WriteLine(8%3);
Console.WriteLine(9%3);

float f=1.1F;
double d=1.2;
decimal dl=1.3M;
Console.WriteLine();
Console.WriteLine(f);
Console.WriteLine(d);
Console.WriteLine(dl);
Console.WriteLine(d/2.5);

Console.WriteLine(6.0/3.0);
Console.WriteLine(7.0/3.0);
Console.WriteLine(8.0/3.0);
Console.WriteLine(9.0/3.0);


bool b1=true;
bool b2=false;
Console.WriteLine(b1);
Console.WriteLine(b2);

Console.WriteLine("AND");
System.Console.WriteLine(b1&&b2);
System.Console.WriteLine($"true and true={true&&true}");
System.Console.WriteLine($"false and true={false&&true}");
System.Console.WriteLine($"true and false={true&&false}");
System.Console.WriteLine($"false and false={false&&false}");

Console.WriteLine("Or");
System.Console.WriteLine(b1||b2);
System.Console.WriteLine($"true or true={true||true}");
System.Console.WriteLine($"false or true={false||true}");
System.Console.WriteLine($"true or false={true||false}");
System.Console.WriteLine($"false or false={false||false}");

System.Console.WriteLine("comparison");
int i1=42;
int i2=42;
int i3=43;
System.Console.WriteLine($"i1 == i2 ={i1 == i2}");
System.Console.WriteLine($"i1 == i3 ={i1 == i3}");
System.Console.WriteLine($"i1 != i2 ={i1 != i2}");
System.Console.WriteLine($"i1 != i3 ={i1 != i3}");

System.Console.WriteLine($"i1 > i2 ={i1 > i2}");
System.Console.WriteLine($"i1 >= i2 ={i1 >= i2}");
System.Console.WriteLine($"i1 < i2 ={i1 < i2}");
System.Console.WriteLine($"i1 <= i2 ={i1 <= i2}");

System.Console.WriteLine($"i1 > i3 ={i1 > i3}");
System.Console.WriteLine($"i1 >= i3 ={i1 >= i3}");
System.Console.WriteLine($"i1 < i3 ={i1 < i3}");
System.Console.WriteLine($"i1 <= i3 ={i1 <= i3}");

System.Console.WriteLine("combination");
System.Console.WriteLine($"b1 || b2 || (i1 >= i3 && i2 <= i1) = {b1 || b2 || (i1 >= i3 && i2 <= i1)}") ;

System.Console.WriteLine("increment/decrement");
int inc = 42;
System.Console.WriteLine($"++inc = {++inc}");//preincrement
System.Console.WriteLine($"inc++={inc++}");//postincrement
System.Console.WriteLine("inc = {inc}"); // inc
System.Console.WriteLine($"--inc = {--inc}");//predecrement
System.Console.WriteLine($"inc--={inc--}");//postdecrement
System.Console.WriteLine("inc = {inc}"); // inc

System.Console.WriteLine("MATH");
System.Console.WriteLine("ABS");
System.Console.WriteLine($"ABS = {Math.Abs(51)}");
System.Console.WriteLine($"ABS = {Math.Abs(-42.2)}");
System.Console.WriteLine("ROUND");
System.Console.WriteLine($"ROUND(42) = {Math .Round(42.0)}");
System.Console.WriteLine($"ROUND(42.2) = {Math .Round(42.2)}");
System.Console.WriteLine($"ROUND(42.6) = {Math .Round(42.6)}");

System.Console.WriteLine("Ceiling");
System.Console.WriteLine($"Ceiling(42) = {Math .Ceiling(42.0)}");
System.Console.WriteLine($"Ceiling(42.2) = {Math .Ceiling(42.2)}");
System.Console.WriteLine($"Ceiling(42.6) = {Math .Ceiling(42.6)}");

System.Console.WriteLine("Floor");
System.Console.WriteLine($"Floor(42) = {Math .Floor(42.0)}");
System.Console.WriteLine($"Floor(42.2) = {Math .Floor(42.2)}");
System.Console.WriteLine($"Floor(42.6) = {Math .Floor(42.6)}");

System.Console.WriteLine("Truncate");
System.Console.WriteLine($"Truncate(42) = {Math .Truncate(42.0)}");
System.Console.WriteLine($"Truncate(42.2) = {Math .Truncate(42.2)}");
System.Console.WriteLine($"Truncate(42.6) = {Math .Truncate(42.6)}");


System.Console.WriteLine("ROUND");
System.Console.WriteLine($"ROUND(42) = {Math .Round(42.0)}");
System.Console.WriteLine($"ROUND(42.2) = {Math .Round(42.2)}");
System.Console.WriteLine($"ROUND(42.6) = {Math .Round(42.6)}");

System.Console.WriteLine("Ceiling");
System.Console.WriteLine($"Ceiling(42) = {Math .Ceiling(42.0)}");
System.Console.WriteLine($"Ceiling(42.2) = {Math .Ceiling(42.2)}");
System.Console.WriteLine($"Ceiling(42.6) = {Math .Ceiling(42.6)}");

System.Console.WriteLine("negative numbers");
System.Console.WriteLine("Floor");
System.Console.WriteLine($"Floor(-42) = {Math .Floor(-42.0)}");
System.Console.WriteLine($"Floor(-42.2) = {Math .Floor(-42.2)}");
System.Console.WriteLine($"Floor(-42.6) = {Math .Floor(-42.6)}");

System.Console.WriteLine("Truncate");
System.Console.WriteLine($"Truncate(-42) = {Math .Truncate(-42.0)}");
System.Console.WriteLine($"Truncate(-42.2) = {Math .Truncate(-42.2)}");
System.Console.WriteLine($"Truncate(-42.6) = {Math .Truncate(-42.6)}");

System.Console.WriteLine("Pow");
System.Console.WriteLine($"Pow(9^4) = {Math.Pow(9,4)}");
System.Console.WriteLine($"9^4 = {9^4}");//not the same as pow
System.Console.WriteLine( $"Pow(1.3,2.5) = {Math.Pow(1.3,2.5)}");

//x^2+3*x+5
int x = 5;
System.Console.WriteLine($"x^2+3*x+5 = {Math.Pow(x,2)+3*x+5}");





