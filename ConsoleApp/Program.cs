Console.WriteLine("Hello, World!");
byte by=0;
short sh=1000;
int i=20000;
long an=(by+sh)*20000;
bool flag=true;
char sym='s';
string s="text";
decimal n1=7.0M;
double db=10.15;
float n2=6.0F;

Console.WriteLine($"(by={by}+sh={sh})*i={i}={an}");
Console.WriteLine($"flag and a ={flag==(an<0)}");
Console.WriteLine($"{s}\n{sym}");
Console.WriteLine("DECIMAL/FLOAT");
Console.WriteLine((double)6.0M/(double)7.0F*db);
Console.WriteLine((float)n1/n2);

int x=30;
Console.WriteLine($"-6*x^3+5*x^2-10*x+15, where x {x}={Math.Pow(-6*x,3)+5*x*5*x-10*x+15}");
double rad=Math.PI/4;
Console.WriteLine($"x={rad} abs(x)*sin(x)={Math.Abs(rad)*Math.Sin(rad)}");
float y=-14;
Console.WriteLine($"x={y}.  2*pi*x={2*Math.PI*y}");
Console.WriteLine($"x={x} y={y}.  max(x, y)={Math.Max(x,(int)y)}");

Console.WriteLine("Extra");
DateTime today=DateTime.Now;
int newyear=(new DateTime(2023,12,31)).DayOfYear;
int y1=today.DayOfYear;
int x1=newyear-y1;
Console.WriteLine($"days left to New Year {x1}");
Console.WriteLine($"days passed from New Year {y1}");