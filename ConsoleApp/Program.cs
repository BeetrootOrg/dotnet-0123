// int Sum(int a, int b)
// {
//     int sum = a+b;
//     return sum;
// }

static int Mul(int a, int b)
{
    int mul = a*b;
    return mul;
}
// int result = Sum(42,80);
// System.Console.WriteLine(result);

int result = Mul(10,12);
System.Console.WriteLine(result);

for (int i = 0; i < 5; i++)
{
    System.Console.WriteLine(i);
}


Random random = new((int)DateTime.Now.Ticks);
System.Console.WriteLine(random.Next(10));

int Sum(int from, int to)
{
    if (from > to) return Sum(to,from);
    if (from == to) return from;
    return from + Sum(from+1,to);
}
System.Console.WriteLine(Sum(1,3));

