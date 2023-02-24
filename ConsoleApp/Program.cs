using ConsoleApp;

SoftwareEngineer engineer = new("John", "Smith", "jsmith", "jsmith@gmail.com",
    Positions.SoftwareEngineer, 50000);

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(engineer.GetFullInformation());
    engineer.Promote();
}
