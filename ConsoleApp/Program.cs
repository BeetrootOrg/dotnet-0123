using System.Reflection;
var assembly = typeof(System.Xml.XmlAttribute).Assembly;
Console.WriteLine("Here is some info about System.Xml assembly:");
Console.WriteLine($"Full Name of the assembly = {assembly.FullName}");
Console.WriteLine($"The location = {assembly.Location}");
Console.WriteLine("\nHere is the first 10 public types defined in the assembly:");
foreach (var type in assembly.GetTypes().Take(10))
{
    Console.WriteLine($"Type {type.Name}");

    Console.WriteLine("\n\tProperties:");
    foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
    {
        Console.WriteLine($"\t{property.PropertyType.Name} {property.Name}()");
    }

    Console.WriteLine("\tMethods:");
    foreach (var method in type.GetMethods())
    {
        Console.Write($"\t{method.ReturnType.Name} {method.Name}(");
        Console.Write(string.Join(',', method.GetParameters().Select(x => ($"{x.ParameterType.Name} {x.Name}"))));
        Console.WriteLine(")");
    }
}
Console.WriteLine("\n");