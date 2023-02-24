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
