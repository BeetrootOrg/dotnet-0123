//Define several variables in your program 
//(byte, short, int, long, bool, char, float, double, decimal, string) 
//and write to console the result of addition, subtraction, multiplication of several of them.

byte b1 = 5;
short s1 = 10;
int i1 = 15;
long l1 = 20;

bool bo1 = true;
bool bo2 = false;
char c1 = 'A';

float f1 = 1.5F;
double d1 = 1.6;
decimal de1 = -3.14M;

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
System.Console.WriteLine($"bo1 && (de1 >= d1) || bo2 = {bo1 && (de1 >= (decimal) d1) || bo2}"); //explicit casting to the same type
System.Console.WriteLine($"help me now = {st1 + " me " + DateTime.Now.ToString("D")}");
System.Console.WriteLine($"Multiplication of integer numbers of integer numbers b1 * s1 * i1 * l1 = {b1 * s1 * i1 * l1}");
System.Console.WriteLine($"Subtraction of integer numbers (l1 - b1) == i1 -> {(l1 - b1) == i1}");

System.Console.WriteLine(Math.Abs (de1));

// Write to console result of several math functions:

// -6*x^3+5*x^2-10*x+15
// abs(x)*sin(x)
// 2*pi*x
// max(x, y)

System.Console.WriteLine("X = ");
string x1 = Console.ReadLine();
double xd = Convert.ToDouble(x1);
double f = -6 * Math.Pow( xd, 3) + 5 * Math.Pow( xd, 2) - 10 * xd + 15;
System.Console.WriteLine($"f(x) = {f}");

double x2 = Math.PI/2;
System.Console.WriteLine($"x2 = {x2}");
System.Console.WriteLine($"abs(x2)*sin(x2) = {Math.Abs(x2) * Math.Sin(x2)}");

double x3 = -0.5;
System.Console.WriteLine($"x3 = {x3}");
System.Console.WriteLine($"2*pi*x3 = {2 * Math.PI * x3}");

System.Console.WriteLine($"max(x2, x3) = {Math.Max(x2, x3)}");

//Date task

DateOnly startdate = new DateOnly(2023, 1, 1);
DateOnly enddate = new DateOnly(2023, 12, 31);
DateOnly currentdate = DateOnly.FromDateTime(DateTime.Now);

System.Console.WriteLine($"X days left to New Year = {currentdate.DayNumber - startdate.DayNumber + 1}");
System.Console.WriteLine($"Y days passed from New Year = {enddate.DayNumber - currentdate.DayNumber}");


