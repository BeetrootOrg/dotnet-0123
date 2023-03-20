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

internal class Test
{
    public int Number { get; set; }
    public string Value { get; set; }
}