using ConsoleApp;

CarBuilder cb = new();

Car car = cb
    .WithName("Ford")
    .WithColor("Red")
    .WithYear(2021)
    .WithPrice(10000)
    .Build();

Console.WriteLine(car);

cb.Clear();

Console.WriteLine("Enter name:");
cb.WithName(Console.ReadLine());

Console.WriteLine("Enter color:");
cb.WithColor(Console.ReadLine());

Console.WriteLine("Enter year:");
cb.WithYear(int.Parse(Console.ReadLine()));

Console.WriteLine("Enter price:");
cb.WithPrice(int.Parse(Console.ReadLine()));

Console.WriteLine(cb.Build());