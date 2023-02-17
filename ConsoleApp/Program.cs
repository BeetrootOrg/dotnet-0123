// Define several variables in your program (byte, short, int, long, bool, char, float, double,
// decimal, string) and write to console the result of addition, subtraction,
// multiplication of several of them.

byte Byte = 5;
short Short = 7;
int Int = 13;
long Long = 1223372036854775808;
bool Bool = false;
char Char = 'y';
float Float = 5.5F;
double Double = 5.5;
decimal Decimal = 5.5M;
string String = "Empt";

Console.WriteLine(String + Char);
Console.WriteLine(Decimal - Int);
Console.WriteLine(Byte * Long);


//     Write to console result of several math functions:
//
// -6*x^3+5*x^2-10*x+15
// abs(x)*sin(x)
// 2*pi*x
// max(x, y)

int x = 24;
int y = 10;

Console.WriteLine(-6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15);
Console.WriteLine(Math.Abs(x) * Math.Sin(x));
Console.WriteLine(2 * Math.PI * x);
Console.WriteLine(Math.Max(x, y));

//
// Extra (if DateTime would be learnt during lesson):
//
// Write to console how many days left to New Year and how many days passed from New Year. Result in console should look like this:
//
// X days left to New Year
Console.WriteLine($"{(DateTime.IsLeapYear(DateTime.Today.Year) ? 366 - DateTime.Today.DayOfYear : 365 - DateTime.Today.DayOfYear)} days left to New Year");

// Y days passed from New Year

Console.WriteLine($"{DateTime.Now.DayOfYear} days passed from New Year");