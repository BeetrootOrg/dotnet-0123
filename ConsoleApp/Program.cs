using ConsoleApp;

Employee employee = new("John", "Smith", "jsmith", Positions.SoftwareEngineer, 50000);
Console.WriteLine(employee.GetFullInformation());
employee.Promote();
Console.WriteLine(employee.GetFullInformation());
