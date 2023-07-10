// Console.WriteLine("Enter the X value:");
// bool successX = int.TryParse(Console.ReadLine(), out int X);
// Console.WriteLine("Enter the Y value:");
// bool successY = int.TryParse(Console.ReadLine(), out int Y);
// if(successX && successY)
// {
//     Console.WriteLine($"You entered this values ({X} , {Y})");
//     return;
// }
// Console.WriteLine("Invalid input");

// int min, max;
// if(X > Y)
// {
//     max = X;
//     min = Y;
    
// }
// else
// {
//     max = Y;
//     min = X;
// }
// int sum = 0;
// for(int i = min; i <= max;  i++)
// {
//     sum += i;
// }
// Console.WriteLine(sum);
// int x = 3;
// int y = 4;
// Console.WriteLine($"-6*x^3+5*x^2-10*x+15 = {-6 * Math.Pow(x , 3) + 5 * Math.Pow(x , 2) - 10 * x + 15}");
// Console.WriteLine(Math.Max(x , y));
// Console.WriteLine(Math.Min(x , y));
// Console.WriteLine(Math.Abs(x));
// float i = 4F;
// decimal j = 5;
// double k = 6;
// Console.WriteLine(j ); 

DateTime dateTime1 = new DateTime(2024, 01, 01);
DateTime dateTime2 = DateTime.Now;
Console.WriteLine($"Days left to New Year {dateTime1 - dateTime2}");
Console.WriteLine($"Days passed fron New Year {dateTime2.DayOfYear}");

// int sum = 0;
// for(int l = 0; l <= 42; l++)
// {
//     if(l % 2 == 1)
//     {
//         continue;
//     }

//     sum += l;
// }
// Console.WriteLine(sum);

Console.WriteLine("Enter the number");
string? input = Console.ReadLine();
int num1 = int.Parse(input);

DateTime currentDateTime = DateTime.Now;
string formattedDateTime = currentDateTime.ToString("MM/dd/yyyy");
Console.WriteLine("Current date and time: " + formattedDateTime);

Console.WriteLine("Enter x");
input = Console.ReadLine();
bool success = int.TryParse(input, out int x);
{
    if(!success)
    {
        Console.WriteLine("Invalid input"); 
        return;
    }
}

Console.WriteLine("Enter y");
input = Console.ReadLine();
bool success1 = int.TryParse(input, out int y);
{
    if(!success1)
    {
        Console.WriteLine("Invalid input");
        return;
    }
}

int min , max;
if (x > y)
{
    max = x;
    min = y;
}
else
{
    max = y;
    min = x;
}

int sum = 0;
for(int i = min; i <= max; i++)
{
    sum += i;
}
Console.WriteLine(sum);