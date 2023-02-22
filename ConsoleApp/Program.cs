using ConsoleApp;

Person person1 = new Person("Maksym","Oliinyk",20);
Console.WriteLine(person1.GetFullInfo());
Person person2 = new Person("John","Doe",50);
Console.WriteLine(person2.GetFullInfo());
person2.FirstName = "Jane";
System.Console.WriteLine(person2.FullName);

Person person3 = new Person("A","DoBe",42);
System.Console.WriteLine($"Changes: {person3.Changes}");

person3.FirstName = "B";
person3.LastName = "a";
person3.Age = 30;

System.Console.WriteLine($"Changes: {person3.Changes}");


Contact contact1 = new Contact
{
    Person = person1,
    PhoneNumber = "+12345678"
};
Contact contact2 = new Contact
{
    Person = person2,
    PhoneNumber = "+87654321"
};

PhoneBook phoneBook = new(contact1,contact2);
phoneBook.Add(new Contact
{
    Person = person3,
    PhoneNumber = "+-"
});
Console.WriteLine(phoneBook.Contacts.Length);
