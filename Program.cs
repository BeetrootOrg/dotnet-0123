
using System.Reflection;
using System.Text;

Console.WriteLine("StringBuilder Assembly:");

Assembly assemply = typeof(StringBuilder).Assembly;
int index = 0;

foreach (Type item in assemply.GetTypes().Take(50))
{   
    
    Console.WriteLine($"{++index}) {item.Name}");
    Console.WriteLine("Methods:");
    foreach (var methods in item.GetMethods())
    {
        string a = "";
        foreach (var variable in methods.GetParameters())
        {
            a = string.Join(',', variable.ParameterType.Name);
        }
        Console.WriteLine($"    {methods.Name}({a})");
        Console.WriteLine($"        return: {methods.ReturnParameter}");
    }

}