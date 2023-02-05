int x;
int y;
int sum = 0;

Console.WriteLine("Enter integer value 1");
string? input = Console.ReadLine();
bool check = int.TryParse(input, out x);
if (check == false)
{
    Console.WriteLine("Not valid input. Try the program one more time");
}
else
{
    Console.WriteLine("Enter integer value 2");
    input = Console.ReadLine();
    check = int.TryParse(input, out y);
    if (check == false)
    {
        Console.WriteLine("Not valid input. Try the program one more time");
    }
    else
    {
        if (x > y)
        {
            for (int i = y; i <= x; i++)
            {
                sum += i;
            }
        }
        else if (x < y)
        {
            for (int i = x; i <= y; i++)
            {
                sum += i;
            }
        }
        else sum = x;
        System.Console.WriteLine($"The sum of all numbers between input numbers is {sum}");
    }
}