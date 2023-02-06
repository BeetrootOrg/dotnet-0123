Console.WriteLine("Enter the value X :");
string? x = Console.ReadLine();
bool success = int.TryParse(x, out int  num1);
if (success)
{
    Console.WriteLine("Enter the value Y :");
    string? y = Console.ReadLine();
    bool success1 = int.TryParse(y, out int  num2);
    if (success1)
    {
        int min = num1 < num2 ? num1 : num2; // if {5 < 2}  {2 = num1} else {2 = num2}  
        int max = num1 > num2 ? num1 : num2;// if {5 > 2} { 5 = num1} else {5 = num2}
        int sum = 0;
        for(int i = min; i <= max; ++i )
        {
            sum += i;
        }
        Console.WriteLine($"Sum of values = {sum}");
    }
    else
    {
        Console.WriteLine($"Invalid input ");
    }
}
else
{
    Console.WriteLine($"Invalid input ");
}

 
