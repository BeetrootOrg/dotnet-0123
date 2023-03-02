using Company;

Console.WriteLine();
Employee manager = new Manager("John", "Smith", 1000.0M, "09:00", "17:00"); 
Console.WriteLine(manager);

Console.WriteLine("\nPromoting manager...\n");

Employee promotedManager = manager.Promote(2000M, "11:00", "18:00");
Console.WriteLine(promotedManager);
Console.WriteLine();
