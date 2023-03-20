using System;
using System.Reflection;

int a = 42;
Type type = a.GetType();

Console.WriteLine(type.Name);
Console.WriteLine(type.FullName);

Type testType = typeof(Test);
foreach (PropertyInfo propertyInfo in testType.GetProperties())
{
    Console.WriteLine($"Type {testType.Name} has property {propertyInfo.Name} with type {propertyInfo.PropertyType.Name}");
}

foreach (PropertyInfo propertyInfo in testType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
{
    Console.WriteLine($"Type {testType.Name} has non-public property {propertyInfo.Name} with type {propertyInfo.PropertyType.Name}");
}

Test test = new();
foreach (PropertyInfo propertyInfo in testType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
{
    if (propertyInfo.PropertyType == typeof(int) && propertyInfo.CanWrite)
    {
        propertyInfo.SetValue(test, 42);
    }
}

foreach (FieldInfo fieldInfo in testType.GetFields())
{
    Console.WriteLine($"Type {testType.Name} has field {fieldInfo.Name} with type {fieldInfo.FieldType.Name}");
    fieldInfo.SetValue(test, 100);
}

Console.WriteLine(test);
foreach (MethodInfo methodInfo in testType.GetMethods())
{
    ParameterInfo[] parameters = methodInfo.GetParameters();

    Console.WriteLine($"Type {testType.Name} has method {methodInfo.Name} with returning type {methodInfo.ReturnType.Name} "
        + $"with {parameters.Length} parameters");

    if (parameters.Length == 0 && methodInfo.ReturnType != typeof(void))
    {
        object result = methodInfo.Invoke(test, Array.Empty<object>());
        Console.WriteLine($"Result of {methodInfo.Name} is {result}");
    }
    else if (parameters.Length == 2 &&
        methodInfo.ReturnType != typeof(void) &&
        parameters[0].ParameterType == typeof(Test) &&
        parameters[1].ParameterType == typeof(Test))
    {
        object result = methodInfo.Invoke(test, new object[] { test, test });
        Console.WriteLine($"Result of {methodInfo.Name} is {result}");
    }
}

object obj = Activator.CreateInstance(typeof(Test));
Console.WriteLine(obj);

internal record Test
{
    private static readonly int PrivateStaticFieldNumber;
    public static int PublicStaticFieldNumber;

    private static int PrivateStaticNumber { get; set; }
    public static int PublicStaticNumber { get; set; }

    private readonly int _privateFieldNumber;
    public int PublicFieldNumber;

    private int PrivateNumber { get; set; }

    public int PublicNumber { get; set; }
    public string PublicValue { get; set; }

    public int ReadonlyNumber { get; }

    public Test()
    {
    }

    public static int GetPrivateStaticFieldNumber()
    {
        return PrivateStaticFieldNumber;
    }

    public int GetPrivateFieldNumber()
    {
        return _privateFieldNumber;
    }

    public static int GetPrivateStaticNumber()
    {
        return PrivateStaticNumber;
    }

    public int GetPrivateNumber()
    {
        return PrivateNumber;
    }
}