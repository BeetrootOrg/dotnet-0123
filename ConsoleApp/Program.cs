using System.Reflection;
using System.Text;

var assembly = typeof(Console).Assembly;
Console.WriteLine($"Assembly location: {assembly.Location}");

List<Type> list = new List<Type>(); 

foreach(Type item in assembly.GetTypes())
{
    list.Add(item);    
}

Type type = list.Where(p => p.FullName == "System.Console").First();

Console.WriteLine($"ConsoleColor properties of type: {type.Name}");

foreach (PropertyInfo prop in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
{
    if (prop.PropertyType == typeof(ConsoleColor))
    {
        Console.WriteLine($"\t{prop.Name}. Type: {prop.PropertyType.Name}");
        if (prop.Name == "ForegroundColor")
        {
            var defaultForegroundColor = prop.GetValue(prop); 
            Console.WriteLine(prop.GetValue(prop));
            prop.SetValue(prop, ConsoleColor.Blue);
            Console.WriteLine("Changed foreground color is on this string");
            prop.SetValue(prop, defaultForegroundColor);
        }
    }    
}

Console.WriteLine($"Example method from type: {type.Name}");

foreach (MethodInfo method in type.GetMethods())
{
    if (method.Name == "get_Title")
    {
       object? consoleTitle = method.Invoke(method, Array.Empty<object>());
        if (consoleTitle != null)
        {
            Console.WriteLine(consoleTitle);
        }
    } 

    if (method.Name == "set_Title")
    {
        var parameters = method.GetParameters();
        Console.WriteLine($"Parameters (count: {parameters.Length}) list of the {method.Name} method:");
        
        foreach(var parameter in parameters)
        {
            Console.WriteLine(parameter.ToString());
        }

        method.Invoke(method, new object[] {"Another console title"});
    }
}


Type stringBuilder = typeof(StringBuilder);

Console.WriteLine("Constructors of StringBuilder class:");

foreach (ConstructorInfo construct in stringBuilder.GetConstructors())
{
    Console.WriteLine($"{stringBuilder.Name}");

    foreach (ParameterInfo parameter in construct.GetParameters())
    {
        Console.WriteLine($"\tParameter: {parameter.ParameterType.Name} {parameter.Name}");
    }
}

Console.WriteLine("Fields of StringBuilder class:");

foreach (FieldInfo field in stringBuilder.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
{
    Console.Write("\t");
    
    if (field.IsPublic)
    {
       Console.Write("public");
    } 

    if (field.IsPrivate)
    {
        Console.Write("private");
    } 

    if (field.IsAssembly)
    {
        Console.Write("internal");
    }

    if (field.IsFamily)
    {
        Console.Write("protected");
    } 

    if (field.IsFamilyAndAssembly)
    {
        Console.Write("private protected");
    }

    if (field.IsFamilyOrAssembly)
    {
        Console.Write("protected internal");
    }

    Console.WriteLine($" {field.FieldType.Name} {field.Name}");
}