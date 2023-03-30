using Helpers;

CoffeeHelper cofee = new CoffeeHelper();
while (true)
{
    Console.WriteLine("Hi, need some coffee? Press any key. Esc exit!");
    var k = Console.ReadKey();
    if (k.Key == ConsoleKey.Escape)
    {
        cofee.Dispose(); Environment.Exit(0);
    }
    cofee.ActionAsync();
}
