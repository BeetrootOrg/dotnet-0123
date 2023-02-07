// homework/03-Conditions & Loops

/*
Create a program that will start with declaration of two constants (X and Y) and will count the sum of all numbers between these constants. 
If they are equal then sum should be one of them

Example:

X=10
Y=12
Sum=10+11+12=33

X=5
Y=2
Sum=2+3+4+5=14

X=10
Y=10
Sum=10

Extra:

Read values of X and Y from the console. If output is invalid - write to console Invalid input and exit the program.

*/
int x;
int y;
decimal suma = 0; // ініціалізуємо змінну
string input;


// тут вводимо Х
for (; ; )
{
    Console.WriteLine("Enter X");
    input = Console.ReadLine();
    bool isOk = int.TryParse(input, out int x1);
    if (isOk && x1 >=0 && x1 < 2147483647) // не допускаємо від'ємних чисел і не допускаємо виходу за межі int
    {
        x = x1;
        break;
    }
    else
    {
        Console.WriteLine("...");
        Console.WriteLine("try again");
        Console.WriteLine("...");
    }

}
// Console.WriteLine(x);


// тут вводимо У
for (; ; )
{
    Console.WriteLine("Enter У");
    input = Console.ReadLine();
    bool isOk = int.TryParse(input, out int y1);
    if (isOk && y1 >=0 && y1 < 2147483647) // не допускаємо від'ємних чисел і не допускаємо виходу за межі int
    {
        y = y1;
        break;
    }
    else
    {
        Console.WriteLine("...");
        Console.WriteLine("try again");
        Console.WriteLine("...");
    }

}
// Console.WriteLine(y);


if (x == y)
{
    suma = x;
}
else
{
    int maximum = Math.Max(x, y);
    int minimum = Math.Min(x, y);

    for (int i = minimum; i <= maximum; ++i)
    {
        suma += i;
    }
}

Console.WriteLine($"sum from X to Y = {suma}");
