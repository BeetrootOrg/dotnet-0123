String s1 = "Hello world!";
Console.WriteLine(s1);
double d = 12.2;
double d1 = 12.2;
Console.WriteLine(d);
decimal dl = 2.0M;
Console.WriteLine(dl);
float f = 12.2F;
Console.WriteLine(f);
Console.WriteLine($"d == f = {d == f}");
Console.WriteLine($"d != f = {d != f}");
Console.WriteLine($"d ==d1 = {d ==d1}");


int x = 2;
Console.WriteLine($"-6*x^3+5*x^2-10*x+15 = {-6 * Math.Pow(x, 3) + 5 * (x * x) - (10 * x) + 15}");
Console.WriteLine($"abs(x)*sin(x) = {Math.Abs(x) * Math.Sin(x)}");   
Console.WriteLine($"2*pi*x = {2 * Math.PI * x}");
double x1 = 19.9;
double y1 = 7.8;
Console.WriteLine($"max(x, y) = {Math.Max(x1, y1)}");
 
 Console.WriteLine("Extra task");
 DateTime Today =  DateTime.Now;
 DateTime DateNewYear = new DateTime(2023, 31, 12);
 DateTime DateYear = new DateTime(2022, 31, 12);
 TimeSpan  DaysLeft =  DateNewYear - Today ;
 TimeSpan  DaysPassed = Today - DateYear;
 Console.WriteLine($"days left to New Year = {DaysLeft}");
 Console.WriteLine($"days passed from New Year = {DaysPassed}");



