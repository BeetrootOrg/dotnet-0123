(string,string,string)[] contacts = new (string,string,string)[0];


void PhoneBook()
{
    Console.Clear();

    System.Console.WriteLine("1.Add new contact");
    System.Console.WriteLine("2.Show all contacts");
    System.Console.WriteLine("3.Find contact");
    System.Console.WriteLine("0.Exit");
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.D0)
    {
        Exit();
    }
    else if (key.Key == ConsoleKey.D1)
    {
        AddNewContact();
    }
    else if (key.Key == ConsoleKey.D2)
    {
        ShowContacts();
    }

}
static void Exit()
{
    Environment.Exit(0);
}

void AddNewContact()
{
    Console.Clear();

    System.Console.WriteLine("Enter First Name");
    string FirstName = Console.ReadLine();

    System.Console.WriteLine("Enter Last Name");
    string LastName = Console.ReadLine();

    System.Console.WriteLine("Enter phone number");
    string PhoneNumber = Console.ReadLine();


Array.Resize(ref contacts,contacts.Length +1);
contacts[^1] = (FirstName, LastName, PhoneNumber);

    System.Console.WriteLine("Contact succesfully added");
    System.Console.WriteLine($"To continue press ENTER...");
    Console.ReadLine();
}
void ShowContacts()
{
    Console.Clear();
    System.Console.WriteLine($"{"Name",-20}{"Start",-20}{"End",-20}{"Room",-20}");
    foreach (var (FirstName, LastName, PhoneNumber) in contacts)
    {
        System.Console.WriteLine();
        System.Console.WriteLine($"{FirstName ,-20},{LastName,-20}{PhoneNumber,-20}");

    }
}

while (true)
{
    PhoneBook();
}