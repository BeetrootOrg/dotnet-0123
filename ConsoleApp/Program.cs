string buffer;

Console.WriteLine("Enter X");
buffer = Console.ReadLine();
if (!int.TryParse(buffer, out int x))
{
    Console.WriteLine("Invalid input");
    return;
}

Console.WriteLine("Enter Y");
buffer = Console.ReadLine();
if (!int.TryParse(buffer, out int y))
{
    Console.WriteLine("Invalid input");
    return;
}

int min, max;
if (x < y)
{
    min = x;
    max = y;
}
else
{
    min = y;
    max = x;
}

int sum = 0;
for (int i = min; i <= max; i++)
{
    sum += i;
}

Console.WriteLine(sum);
