byte bt = 7;
short s = 517;
int i = 33203;
long l = 3_147_483_647L;
bool bl = true;

Console.WriteLine($"bt == {bt}; b + 2 = { bt + 2}");
Console.WriteLine($"s == {s}; s - 17 = { s - 17}");
Console.WriteLine($"i == {i}; i * s = { i * s}");
Console.WriteLine($"l == {l}; l / i = { l / i}");
Console.WriteLine($"l == {l}; l % i = { l % i}");

Console.WriteLine();
Console.WriteLine($"bt == {bt}; bool == {bl}; bt > 255 = { bt > 10 }");

Console.WriteLine();
float f = 1.2345F;
double d = 12.345;
float result1 = (float) (f * d);
Console.WriteLine($"f == {f}; d == {d}; f * d = { result1 }");
decimal dl = 123.45M;
double result2 = (double) (dl / 4); 
Console.WriteLine($"dl == {dl}; result1 == {result1}; dl / 4 = { result2 }");

Console.WriteLine();
char sharp = '#';
string str = "I am learning C" + sharp;
Console.WriteLine(str);

Console.WriteLine();
int x = 17;
int result3 = -6 * (int) Math.Pow(x, 3) + 5 * x * x - 10 * x + 15;
Console.WriteLine($"-6*x^3+5*x^2-10*x+15 = { result3 }");
double result4 = Math.Abs(x) * Math.Sin(x);
Console.WriteLine($"abs(x)*sin(x) = { result4 }");
Console.WriteLine($"2*pi*x = { 2 * Math.PI * x }");
int y = 19;
Console.WriteLine($"max(x, y) = { Math.Max(x, y) }");

Console.WriteLine();
Console.WriteLine("DateTime");
DateTime currentDate = DateTime.Today;
DateTime currentNewYearDate = new DateTime(currentDate.Year, 1, 1);
DateTime nextNewYearDate = new DateTime(currentDate.Year + 1, 1, 1);

int daysLeft = (nextNewYearDate - currentDate).Days;
int daysPassed = (currentDate - currentNewYearDate).Days;

Console.WriteLine($"{daysLeft} days left to New Year");
Console.WriteLine($"{ daysPassed } days passed from New Year");