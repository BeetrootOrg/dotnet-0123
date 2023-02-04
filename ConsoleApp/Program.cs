 const int X = 5;
 const int Y = 2;

int min = Math.Min(X, Y);
int max = Math.Max(X, Y);
int sum = (min == max) ? min : 0;
string str = "Sum=";

if (sum == 0)
{
    for (int i = min; i <= max; i++)
    {
        str += (i == max) ? $"{i}=" : $"{i}+";
        sum += i;
    }
}

Console.WriteLine($"{str}{sum}");
Console.WriteLine();

// Extra
Console.WriteLine("Enter X:");
string? stringX = Console.ReadLine();
Console.WriteLine("Enter Y:");
string? stringY = Console.ReadLine();

bool isX = int.TryParse(stringX, out int intX);
bool isY = int.TryParse(stringY, out int intY);

if (!(isX && isY))
{
    Console.WriteLine("Invalid input");
    return;
}

Console.WriteLine($"X = {intX}; Y = {intY}");
