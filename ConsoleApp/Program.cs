using System.Reflection;
using System.Text;

while (true)
{
    Console.WriteLine("Enter full name of Assembly");
    Console.WriteLine("ex. Or type ex for  exit.");
    string s = Console.ReadLine();
    if (s.ToLower() == "ex") Environment.Exit(0);
    var assembly = Type.GetType(s, false, true)?.Assembly;

    if (assembly == null)
    {
        Console.WriteLine("Error!");
        continue;
    }
    Console.WriteLine($"Types in Assembly {assembly.FullName}:");
    foreach (var type in assembly.GetTypes())
    {
        Console.WriteLine($"Type {type.Name}, ({type.GetMethods().Count()}) Methods");
        foreach (var method in type.GetMethods())
        {
            Console.WriteLine($"\tMethod {method.Name} Public:{method.IsPublic} Static:{method.IsPublic} ReturnType:{method.ReturnType.Name}");
            Console.WriteLine($"\tParameters ({method.GetParameters().Count()}):");
            foreach (var param in method.GetParameters())
            {
                Console.WriteLine($"\t{param.Name} Type:{param.ParameterType.Name}");
            }
        }
    }
}
