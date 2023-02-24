using ConsoleApp;

Person person1 = new Person("Dima", "Misik", 26);
Console.WriteLine(person1.GetFullInfo());

Person person2 = new Person("John", "Doe", 50);
Console.WriteLine(person2.GetFullInfo());

Console.WriteLine(person1.FullName);

person2.FirstName = "Jane";
Console.WriteLine(person2.FirstName);
Console.WriteLine(person2.LastName);
Console.WriteLine(person2.FullName);

Person person3 = new Person("A", "B", 27);
Console.WriteLine($"Changes: {person3.Counter}");

person3.FirstName = "B";
Console.WriteLine($"Changes: {person3.Counter}");

person3.LastName = "A";
Console.WriteLine($"Changes: {person3.Counter}");

person3.Age = 43;
Console.WriteLine($"Changes: {person3.Counter}");

Contact contact1 = new Contact//or - new()
{
    Person = person1,
    PhoneNumber = "+12345678"
};

Contact contact2 = new()
{
    Person = person2,
    PhoneNumber = "+98765432"
};

PhoneBook phoneBook = new(contact1, contact2);