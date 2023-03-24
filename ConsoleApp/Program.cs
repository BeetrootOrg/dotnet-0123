ConsoleKeyInfo? key1 = null;

// 1st option
Timer timer = new((state) => Console.WriteLine(key1?.Key), null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

// 2nd option
Task.Run(async () =>
{
    while (true)
    {
        Console.WriteLine(key1?.Key);
        await Task.Delay(1000);
    }
});

while (true)
{
    key1 = Console.ReadKey(false);
}