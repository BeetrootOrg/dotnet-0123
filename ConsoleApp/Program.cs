// See https://aka.ms/new-console-template for more information
int a=42;
int b=41;
int c=a+b;

Console.WriteLine(a+b);
Console.WriteLine(c);
a=a+b;
Console.WriteLine(a);

Console.WriteLine(@"RESULT OF /");
Console.WriteLine(6/3);
Console.WriteLine(7/3);
Console.WriteLine(8/3);
Console.WriteLine(9/3);

Console.WriteLine("RESULT OF %");
Console.WriteLine(6%3);
Console.WriteLine(7%3);
Console.WriteLine(8%3);
Console.WriteLine(9%3);

float f=1.1F;
double d=1.2;
decimal dl=1.3M;

Console.WriteLine(f);
Console.WriteLine(d);
Console.WriteLine(dl);
Console.WriteLine(d/2.5);

Console.WriteLine("FLOAT MATH");
Console.WriteLine(6F/3F);
Console.WriteLine(7F/3F);
Console.WriteLine(8F/3F);
Console.WriteLine(9F/3F);

Console.WriteLine("DOUBLE MATH");
Console.WriteLine(6.0/3.0);
Console.WriteLine(7.0/3.0);
Console.WriteLine(8.0/3.0);
Console.WriteLine(9.0/3.0);

Console.WriteLine("DECIMAL MATH");
Console.WriteLine(6M/3M);
Console.WriteLine(7M/3M);
Console.WriteLine(8M/3M);
Console.WriteLine(9M/3M);

bool b1=true;
bool b2=false;

Console.WriteLine(b1);
Console.WriteLine(b2);

Console.WriteLine("AND");
Console.WriteLine(b1 && b2);
Console.WriteLine($"true and true {true && true}");
Console.WriteLine($"false and true {false && true}");
Console.WriteLine($"true and false {true && false}");
Console.WriteLine($"false and false {false && false}");

Console.WriteLine("OR");
Console.WriteLine(b1 || b2);
Console.WriteLine($"true or true {true || true}");
Console.WriteLine($"false or true {false || true}");
Console.WriteLine($"true or false {true || false}");
Console.WriteLine($"false or false {false || false}");

Console.WriteLine("COMPARISONE");
int l1=42;
int l2=42;
int l3=43;

Console.WriteLine($"l1=l2 {l1==l2}");
Console.WriteLine($"l1=l3 {l1==l3}");
Console.WriteLine($"l1!=l2 {l1!=l2}");
Console.WriteLine($"l1!=l3 {l1!=l3}");

Console.WriteLine($"l1>=l2 {l1>=l2}");
Console.WriteLine($"l1<=l2 {l1<=l2}");
Console.WriteLine($"l1>l2 {l1>l2}");
Console.WriteLine($"l1<l2 {l1<l2}");

Console.WriteLine($"l1>=l3 {l1>=l3}");
Console.WriteLine($"l1<=l3 {l1<=l3}");
Console.WriteLine($"l1>l3 {l1>l3}");
Console.WriteLine($"l1<l3 {l1<l3}");

Console.WriteLine("COMBINATION");
Console.WriteLine($"b1 || b2 || (l1>=l3 && l2<=l1)={b1 || b2 || (l1>=l3 && l2<=l1)}");

decimal n1=7.0M;
float n2=6.0F;
Console.WriteLine("DECIMAL/FLOAT");
Console.WriteLine(6.0M/(decimal)7.0F);
Console.WriteLine((float)n1/n2);

Console.WriteLine("INT/FLOAT");
float n3=7.0F;
int n4=6;
Console.WriteLine(n3/n4);

Console.WriteLine("INCREMERNT/DECREMENT");
int inc=42;
Console.WriteLine($"++i={++inc}");
Console.WriteLine($"i++={inc++}");
Console.WriteLine($"i={inc}");
Console.WriteLine($"--i={--inc}");
Console.WriteLine($"i--={inc--}");
Console.WriteLine($"i={inc}");

Console.WriteLine("MATH");
Console.WriteLine($"ABS={Math.Abs(-51)}");
Console.WriteLine($"ABS={Math.Abs(51)}");
Console.WriteLine($"ABS={Math.Abs(-42.2)}");
Console.WriteLine($"Round={Math.Round(42.0)}");
Console.WriteLine($"Round={Math.Round(42.2)}");
Console.WriteLine($"Round={Math.Round(42.6)}");

Console.WriteLine($"Ceiling={Math.Ceiling(42.0)}");
Console.WriteLine($"Ceiling={Math.Ceiling(42.2)}");
Console.WriteLine($"Ceiling={Math.Ceiling(42.6)}");

Console.WriteLine($"Floor={Math.Floor(42.0)}");
Console.WriteLine($"Floor={Math.Floor(42.2)}");
Console.WriteLine($"Floor={Math.Floor(42.6)}");

Console.WriteLine($"Truncate={Math.Truncate(42.0)}");
Console.WriteLine($"Truncate={Math.Truncate(-42.2)}");
Console.WriteLine($"Truncate={Math.Truncate(-42.6)}");

