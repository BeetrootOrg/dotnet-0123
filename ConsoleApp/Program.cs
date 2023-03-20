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

internal class Test
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