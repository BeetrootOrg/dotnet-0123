bool yes = true;
bool no = false;
string a = "A";
string b = "B";
string c = "C"; 
float X = 1.564f;
float Y = 2f;

Console.WriteLine($"YES & NO={yes&&no}.");
Console.WriteLine($"YES or NO={yes||no}.");
Console.WriteLine($"A+B+C={a+b+c}.");
Console.WriteLine($"X*Y={X*Y}.");

Console.WriteLine("------------------------------------------------------");

double x;
double y;
double result;

x = 20;
y = 12;

result=-6*Math.Pow(x,3)+5*Math.Pow(x,2)-10*x+15;
Console.WriteLine($"The result of function 1 is {result}.");
result=Math.Abs(x)*Math.Sin(y);
Console.WriteLine($"The result of function 2 is {result}.");
result=2*Math.PI*x;
Console.WriteLine($"The result of function 3 is {result}.");
result=Math.Max(x,y);
Console.WriteLine($"The result of function 4 is {result}.");

Console.WriteLine("------------------------------------------------------");

DateTime today = new DateTime();
today = DateTime.Today;
DateTime lastday = new DateTime(2023,12,31);
DateTime firstday = new DateTime(2023,01,01);
Console.WriteLine($"{(lastday-today)} days left to New Year.");
Console.WriteLine($"{(today-firstday)} days passed from New Year.");
