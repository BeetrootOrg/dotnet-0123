// домашня робота по уроку 02 -- типи даних

Console.WriteLine("=================================");

byte b = 10;
short st = 15;
int i = 33;
long l = 200;

float flt = 235.54F;
decimal db = 500.12M;
double dec = i + flt;
dec++;
db = l++; // db = 200 l=201
Console.WriteLine(db);
Console.WriteLine(l);

string s = "Hello";
char cr = '!';
Console.WriteLine("=================================");
Console.WriteLine($"{s + cr}");     // = "Hello!"
Console.WriteLine("=================================");
Console.WriteLine(Math.Pow(st, b)); // підносимо в степінь

Console.WriteLine(st % b);          // остача від ділення

Console.WriteLine(b++);             // операція "10", потім інкремент
Console.WriteLine(b);             // вже показує оновленне значення

Console.WriteLine("=================================");

/* 
-6*x^3+5*x^2-10*x+15
abs(x)*sin(x)
2*pi*x
max(x, y)
*/

double x = 8;
double y = 16;
double result00 = -6 * (Math.Pow (x, 3)) + 5 * Math.Pow(x,2) - 10 * x + 15;
double result01 = -6 * x*x*x + 5 * x*x - 10 * x + 15;
Console.WriteLine($"-6*x^3+5*x^2-10*x+15 = {result00}");
Console.WriteLine($"те саме = {result01}");
Console.WriteLine("=================================");

Console.WriteLine($"2*pi*x = {2 * Math.PI * x}");
Console.WriteLine($"max(x, y) = {Math.Max(x, y)}");


Console.WriteLine("=================================");



