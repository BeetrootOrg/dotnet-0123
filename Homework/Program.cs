// Create a program that will start with declaration of two constants (X and Y)
// and will count the sum of all numbers between these constants. If they are equal then sum should be one of them
//
// Example:
//
// X=10
// Y=12
// Sum=10+11+12=33
//
// X=5
// Y=2
// Sum=2+3+4+5=14
//
// X=10
// Y=10
// Sum=10
//
// Extra:
//
// Read values of X and Y from the console. If output is invalid - write to console Invalid input and exit the program.
//
Console.WriteLine("Hello, please enter the value of X");
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Hello, please enter the value of Y");
string input = Console.ReadLine();
int y;
Int32.TryParse(input, out y);
Console.WriteLine($"{x} {y}");
if (x == y)
{
    Console.WriteLine($"Sum = {x}");
}
else
{
    if (x < y)
    {
        Console.WriteLine(Sum(x, y));
    }
    else
    {
        Console.WriteLine(Sum(y, x));
    }
    
}

static int Sum(int x, int y)
{
    int sum = (x + y) * (y - x + 1) / 2;
    return sum;
}