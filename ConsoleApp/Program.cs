//byte, short, int, long, bool, char, float, double, decimal, string

byte b1 = 5;
short s1 = 10;
int i1 = 15;
long l1 = 20;

bool bo1 = true;
char c1 = 'c';

float f1 = 1.5F;
double d1 = 1.6;
decimal de1 = 3.14M;

string st1 = "help";

System.Console.WriteLine($"byte = {b1}");
System.Console.WriteLine($"short = {s1}");
System.Console.WriteLine($"int = {i1}");
System.Console.WriteLine($"long = {l1}");
System.Console.WriteLine($"bool = {bo1}");
System.Console.WriteLine($"char = {c1}");
System.Console.WriteLine($"float = {f1}");
System.Console.WriteLine($"double = {d1}");
System.Console.WriteLine($"decimal = {de1}");
System.Console.WriteLine($"string = {st1}");

System.Console.WriteLine($"b1 + s1 + i1 + l1 = {b1 + s1 + i1 + l1}"); //implicit casting to the same type
System.Console.WriteLine($"b1 && ");