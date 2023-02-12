/*
static int Sum(int a, int b)
{
    int sum = a + b;
    return sum;
}

static int Mul(int a, int b)
{
    int mul = a * b;
    return mul;
}

int result = Sum(42, 80);
Console.WriteLine(result);

result = Mul(10, 12);
Console.WriteLine(result);

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

static long Fibonacci(int n)
{
    if (n == 1)
    {
        return 1;
    }

    if (n == 2)
    {
        return 1;
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

Fibonacci(3);
Fibonacci(5);


Random random = new((int)DateTime.Now.Ticks);
Console.WriteLine(random.Next());

Console.WriteLine(random.Next(10)); // [0; 10)
Console.WriteLine(random.Next(-10, 10)); // [-10; 10)


System.Console.WriteLine("Press ENTER to start");
Random r = new((int)DateTime.Now.Ticks);

while (true)
{
    Console.ReadLine();
    if (random.Next(0, 5) == 3)
    {
        System.Console.WriteLine("Gave over");
        // break;
        return;
    }
    else
    {
        System.Console.WriteLine("continue game");
    }
}



float f1 = random.NextSingle(); // [0.0; 1.0)
Console.WriteLine(f1);

double d1 = random.NextDouble(); // [0.0; 1.0)
Console.WriteLine(d1);



static int SumRecursion(int from, int to)
{
    if (from > to)
    {
        return SumRecursion(to, from);
    }

    if (from == to)
    {
        return from;
    }

    return from + SumRecursion(from + 1, to);
}

Console.WriteLine(SumRecursion(1, 3));


Console.WriteLine(SumRecursion(3, 1));



static double CalculateDistance(double x1, double y1, double x2, double y2)
{
    double dx = x2 - x1;
    double dy = y2 - y1;
    return Math.Sqrt((dx * dx) + (dy * dy));
}

Console.WriteLine(CalculateDistance(0, 3, 4, 0));
Console.WriteLine(CalculateDistance(15.5, 42, -6.3, 101.05));



static int NearestSquare(int n)
{
    double sqrt = Math.Sqrt(n);
    int rounded = (int)Math.Round(sqrt);
    return rounded * rounded;
}

Console.WriteLine(NearestSquare(120));
Console.WriteLine(NearestSquare(111));
Console.WriteLine(NearestSquare(110));

Console.WriteLine(NearestSquare(4));
Console.WriteLine(NearestSquare(5));
Console.WriteLine(NearestSquare(6));
Console.WriteLine(NearestSquare(7));
Console.WriteLine(NearestSquare(8));
Console.WriteLine(NearestSquare(9));


*/

char c = 'a';
string s = "string";

Console.WriteLine(c);
Console.WriteLine(s[2]);

s += " abc";

Console.WriteLine(s);

static string ConvertToBinary(int n)
{
    // 0, 1, 2, ... 9, 10, 11, ..., 99, 100
    // 0, 1, 10, 11, 100, 101, 110, 111

    // 456 = 4 * 100 + 5 * 10 + 6 * 1
    // 101b = 1 * 100b + 0 * 10b + 1 * 1b = 1 * 4 + 0 * 2 + 1 * 1 = 5
    // 2 = 1 * 2 + 0 * 1 = 1 * 10b + 0 * 0b = 10b
    // 5 = 1 * 4 + 0 * 2 + 1 * 1 = 1 * 100b + 0 * 10b + 1 * 1b = 101b
    int num = n;
    string result = "";
    do
    {
        result = (num % 2) + result;
        num /= 2; // num = num / 2
    } while (num > 0);

    return result;
}

Console.WriteLine(ConvertToBinary(0));
Console.WriteLine(ConvertToBinary(1));
Console.WriteLine(ConvertToBinary(2));
Console.WriteLine(ConvertToBinary(3));
Console.WriteLine(ConvertToBinary(4));
Console.WriteLine(ConvertToBinary(5));
Console.WriteLine(ConvertToBinary(10));
