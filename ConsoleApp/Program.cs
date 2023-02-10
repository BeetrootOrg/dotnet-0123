//Create a program that will start with declaration of two constants (X and Y) 
//and will count the sum of all numbers between these constants. 
//If they are equal then sum should be one of them

System.Console.WriteLine("Declare X");
string input = Console.ReadLine();
// int x1 = int.Parse(input);
bool success = int.TryParse(input, out int x1);

if (!success)
{
    System.Console.WriteLine("Invalid input");
    return;
}

System.Console.WriteLine("Declare Y");
input = Console.ReadLine();
// int y1 = int.Parse(input);
success = int.TryParse(input, out int y1);

if (!success)
{
    System.Console.WriteLine("Invalid input");
    return;
}

int min = 0;
int max = 0;

if (x1 < y1)
{
    min = x1;
    max = y1;
}
else
{
    min = y1;
    max = x1;
};

int sum = 0; 
for (int i = min; i <= max; i++)
    {
        sum +=i;
    }

System.Console.WriteLine($"Sum = {sum}");