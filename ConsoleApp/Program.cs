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

Console.WriteLine($"Changes: {person3.Tracker.Changes}");

person3.FirstName = "B";
Console.WriteLine($"Changes: {person3.Tracker.Changes}");

person3.LastName = "A";
Console.WriteLine($"Changes: {person3.Tracker.Changes}");

person3.Age = 43;
Console.WriteLine($"Changes: {person3.Tracker.Changes}");

Contact contact1 = new()
{
    Person = person1,
    PhoneNumber = "+12345678"
};

Contact contact2 = new()
{
    Person = person2,
    PhoneNumber = "+87654321"
};

PhoneBook phoneBook = new(contact1, contact2);
phoneBook.Add(new Contact
{
    Person = person3,
    PhoneNumber = "-+"
});

Console.WriteLine(phoneBook.Contacts.Length);

Person p1 = new();
Person p2 = new("C", "D", 42);
Person p3 = new(p2);
Person p4 = new()
{
    FirstName = "F",
    Age = 42
};

Console.WriteLine(p1.GetFullInfo());
Console.WriteLine(p2.GetFullInfo());
Console.WriteLine(p3.GetFullInfo());
Console.WriteLine(p4.GetFullInfo());

User user1 = new(42, "user");
User user2 = new()
{
    Username = "user1",
    Id = 43
};
User user3 = new()
{
    Id = 44,
    Username = "user2"
};

Console.WriteLine(user1.Id);
Console.WriteLine(user1.Username);

Console.WriteLine(user2.Id);
Console.WriteLine(user2.Username);

Console.WriteLine(user3.Id);
Console.WriteLine(user3.Username);

// COMPILATION ERROR BELOW
// user1.Id = 43;

ChangesTracker c1 = new();
ChangesTracker c2 = new();

c1.IncChanges();
c1.IncChanges();
c1.IncChanges();

c2.IncChanges();
c2.IncChanges();

Console.WriteLine(c1.Changes);
Console.WriteLine(c2.Changes);

Console.WriteLine(ChangesTracker.GlobalChanges);

ChangesTracker.ResetGlobalCounter();

Console.WriteLine(ChangesTracker.GlobalChanges);
