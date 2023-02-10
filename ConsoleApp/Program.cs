// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

byte byte1 = 42;
short short1 = 24;
int a = 15;
long long1 = 100;

var x = a;
System.Console.WriteLine($"-6*x^3+5*x^2-10*x+15 = {(-6)*x*x*x+5*x*x-10*x+15}");

x = short1;
System.Console.WriteLine($"abs(x)*sin(x) = {Math.Abs(x)*Math.Sin(x)}");

x = (int)long1;
System.Console.WriteLine($"2*pi*x = {2*Math.PI*x}");

x = byte1;
int b = a;
System.Console.WriteLine($"max(x, y) = {Math.Max(x,b)}");

var a1 = new DateTime(2023, 1, 1);
var a2 = new DateTime();
var a3 = new DateTime(2024, 1, 1);


a2 = DateTime.Now;

TimeSpan leftTo = new TimeSpan();
TimeSpan passedFrom = new TimeSpan();
leftTo = a3 - a2;
passedFrom = a2 - a1;
System.Console.WriteLine($"{leftTo.Days} days left to New Year");
System.Console.WriteLine($"{passedFrom.Days} days passed from New Year");