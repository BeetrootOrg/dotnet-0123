using ConsoleApp;

SoftwareEngineer engineer = new("John", "Smith", "jsmith", "jsmith@gmail.com",
    Positions.SoftwareEngineer, 50000);

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(engineer.GetFullInformation());
    engineer.Promote();
}

// COMPILATION ERROR BELOW
// Positions.Architect = "SOME STUFF"

SoftwareEngineer example = SoftwareEngineer.Example;
Console.WriteLine(example.GetFullInformation());

// COMPILATION ERROR BELOW
// SoftwareEngineer.Example = new SoftwareEngineer("A", "B", "ab", "ab", Positions.Architect, 100000);

int[] a = new[] { 1, 2, 3 };
int[] b = new[] { 1, 2, 3 };

Console.WriteLine(a == b);

SoftwareEngineer engineer1 = new("John", "Smith", "jsmith", "jsmith@gmail.com",
    Positions.SoftwareEngineer, 50000);

SoftwareEngineer engineer2 = new("John", "Smith", "jsmith", "jsmith@gmail.com",
    Positions.SoftwareEngineer, 50000);

Console.WriteLine(engineer1 == engineer2);

Person person1 = new() { FirstName = "John", LastName = "Smith", Age = 30 };
Person person2 = new() { FirstName = "John", LastName = "Smith", Age = 30 };

Console.WriteLine(person1 == person2);

Console.WriteLine(person1);

Car car1 = new("Ford", "Mustang", 1969, "Red");
Console.WriteLine(car1);
