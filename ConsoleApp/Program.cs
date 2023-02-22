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