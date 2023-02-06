Console.WriteLine("Enter x:");
bool successX = int.TryParse(Console.ReadLine(),out int x);
Console.WriteLine("Enter y:");
bool successY = int.TryParse(Console.ReadLine(),out int y);
if (successX && successY)
{
    int sum = 0;
    do
    {
        sum += x++;
    } while (y>=x);
    Console.WriteLine($"Sum = {sum}");
}
else
{
    Console.WriteLine("Invalid input");
}