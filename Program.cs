Console.WriteLine("INPUT X:");
string input1 = Console.ReadLine();
Console.WriteLine("INPUT Y:");
string input2 = Console.ReadLine();
bool success1 = int.TryParse(input1, out int x);
bool success2 = int.TryParse(input2, out int y);

if (success1 & success2)
{
    int a = 0;
    int sum = 0;

    if (x >= y)
    {
        a = y;
        y = x;
        x = a;
    }
    for (int i = x; i <= y; i++)
    {
        sum += i;
    }
    Console.WriteLine($"SUM = {sum}");
}
else
{
    Console.WriteLine("Invalid input");
}