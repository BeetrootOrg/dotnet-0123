byte byteNumber = 8;
short shortNumber = 16;
int intNumber = 32;
long longNumber = 64;
bool lever = false;
char letter = 'U';
float floatNumber = 2022.2402f;
double doubleNumber = 2023.0402;
decimal decimalNumber = 20234.235324623462345324m;
string title = "Beetroot Academy - Online courses";

Console.WriteLine(" here's several variables (byte, short, int, long, bool, char, float, double, decimal, string):");
Console.WriteLine($"byte value = {byteNumber}\n"
                + $"short value = {shortNumber}\n"
                + $"int value = {intNumber}\n"
                + $"long value = {longNumber}\n"
                + $"bool value = {lever}\n"
                + $"char value = '{letter}'\n"
                + $"float value = {floatNumber}\n"
                + $"double value = {doubleNumber}\n"
                + $"decimal value = {decimalNumber}\n"
                + $"string value = \"{title}\"\n");

Console.WriteLine(" here's a result of addition, subtraction, multiplication of several of them:");
Console.WriteLine($"byte + short = {byteNumber + shortNumber}");
Console.WriteLine($"int - long = {intNumber - longNumber}");
Console.WriteLine($"float * double = {floatNumber * doubleNumber}\n");

Console.WriteLine(" here's a result of several math functions:");

int random = new Random().Next(999);
int y = 65;
Console.WriteLine($"  X = {random} (the random number between 0 and 999)\n  Y = {y} (why not?)");
Console.WriteLine($"-6*x^3+5*x^2-10*x+15 = {-6*Math.Pow(random,3)+5*Math.Pow(random,2)-10*random+15}");
Console.WriteLine($"abs(x)*sin(x) = {Math.Abs(random)*Math.Sin(random)}");
Console.WriteLine($"2*pi*x = {2*Math.PI*random}");
Console.WriteLine($"max(x, y) = {Math.Max(random, y)}\n");

//Extra exercise
Console.WriteLine(" Extra exercise:");
Console.WriteLine($"{(new DateTime(2024, 1, 1) - DateTime.Now).Days} days left to New Year");
Console.WriteLine($"{(DateTime.Now - new DateTime(2022, 12, 31)).Days} days passed from New Year");
