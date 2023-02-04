Console.Write("X=");
if(!int.TryParse(Console.ReadLine(), out int x))
{
    Console.WriteLine("Invalid input");
    Environment.Exit(0);
}

Console.Write("Y=");
if(!int.TryParse(Console.ReadLine(), out int y))
{
    Console.WriteLine("Invalid input");
    Environment.Exit(0);
}

int min = x < y ? x : y;
int max = x > y ? x : y;

int sum = 0;
for (int i = min; i <= max; i++)
{
    sum += i;
}
Console.Write($"Sum={sum}");