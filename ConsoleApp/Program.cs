using ConsoleApp;

Person person1 = new("Dima", "Misik", 26);
Person person2 = new("John", "Doe", 50);

Console.WriteLine(person1.GetFullInfo());
Console.WriteLine(person2.GetFullInfo());

Console.WriteLine(person1.FirstName);
Console.WriteLine(person1.LastName);
Console.WriteLine(person1.Age);
Console.WriteLine(person1.FullName);

person2.FirstName = "Jane";

Console.WriteLine(person2.FirstName);
Console.WriteLine(person2.LastName);
Console.WriteLine(person2.FullName);

Person person3 = new("A", "B", 42);

Console.WriteLine($"Changes: {person3.Changes}");

person3.FirstName = "B";
Console.WriteLine($"Changes: {person3.Changes}");

person3.LastName = "A";
Console.WriteLine($"Changes: {person3.Changes}");

person3.Age = 43;
Console.WriteLine($"Changes: {person3.Changes}");