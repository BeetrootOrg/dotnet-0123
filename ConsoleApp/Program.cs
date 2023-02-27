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
Console.WriteLine($"Changes: {person3.Tracker.Changes}");

person3.FirstName = "B";
Console.WriteLine($"Changes: {person3.Tracker.Changes}");

person3.LastName = "A";
Console.WriteLine($"Changes: {person3.Tracker.Changes}");

person3.Age = 43;
Console.WriteLine($"Changes: {person3.Tracker.Changes}");

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
phoneBook.Add(new Contact
{
    Person = person3,
    PhoneNumber = "-+"
});

Console.WriteLine(phoneBook.Contacts.Length);

User user1 = new(42, "user");

User user2 = new()
{
    Username = "user1",
    Id = 43
};
Console.WriteLine(user1.Id);
Console.WriteLine(user1.Username);

Console.WriteLine(user2.Id);
Console.WriteLine(user2.Username);

ChangesTracker c1 = new ChangesTracker();
ChangesTracker c2 = new ChangesTracker();

c1.IncChanges();
c1.IncChanges();
c1.IncChanges();

Console.WriteLine(c1.Changes);
Console.WriteLine(c2.Changes);

Console.WriteLine(ChangesTracker.GlobalChanges);

ChangesTracker.ResetGlobalCounter();

Console.WriteLine(ChangesTracker.GlobalChanges);

