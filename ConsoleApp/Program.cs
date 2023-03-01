using ConsoleApp;

SoftwareEnginner engineer = new("John", "Smith", "jsmith", "jsmith@gmail.com",  Positions.SoftwareEnginner, 50000);

for (int i =0; i < 5; i++)
{
    Console.WriteLine(engineer.GetFullInformation());
    engineer.Promote();
}

SoftwareEnginner example = SoftwareEnginner.Example;
Console.WriteLine(example.GetFullInformation());

Car car = new("Ford", "Mustang", 1969, "Red");
Console.WriteLine(car);

Singleton s1 = Singleton.Instance;
Singleton s2 = Singleton.Instance;

Console.WriteLine(s1 == s2);

Cache c1 = Cache.Instane;
Console.WriteLine(c1._veryHardData[0]);
Cache c2 = Cache.Instane;
Console.WriteLine(c2._veryHardData[0]);
