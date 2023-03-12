(string, string, string)[] contacts = new (string, string, string)[0];


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
    else if (key.Key == ConsoleKey.D3)
    {
        FindContact();
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


    Array.Resize(ref contacts, contacts.Length + 1);
    contacts[^1] = (FirstName, LastName, PhoneNumber);

    System.Console.WriteLine("Contact succesfully added");
    System.Console.WriteLine($"Press ENTER to continue...");
    Console.ReadLine();
}
void ShowContacts()
{
    Console.Clear();
    System.Console.WriteLine($"{"First Name",-20}{"Last Name",-20}{"Phone Number",-20}");
    foreach (var (FirstName, LastName, PhoneNumber) in contacts)
    {
        System.Console.WriteLine();
        System.Console.WriteLine($"{FirstName,-20}{LastName,-20}{PhoneNumber,-20}");

    }
    System.Console.WriteLine("Press ENTER to countinue...");
    Console.ReadLine();

}
void FindContact()
{
    Console.Clear();
    System.Console.WriteLine("Enter First/Last name or phone number:");
    string info = Console.ReadLine();
    foreach (var (FirstName, LastName, PhoneNumber) in contacts)
    {
        if (FirstName.Contains(info) || LastName.Contains(info) || PhoneNumber.Contains(info))
        {
            System.Console.WriteLine("What we found:");
            System.Console.WriteLine($"{FirstName,-20}{LastName,-20}{PhoneNumber,-20}");
        }
        else
        {
            System.Console.WriteLine($"There is no contact {info}");
        }
    }
    System.Console.WriteLine("Press ENTER to countinue...");
    Console.ReadLine();

}
while (true)
{
    PhoneBook();
}