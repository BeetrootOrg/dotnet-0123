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

Test testObj1 = obj as Test;
testObj1.PublicValue = "abc";
Console.WriteLine($"PublicValue is {testObj1.PublicValue}");

BadCast bc1 = obj as BadCast;
Console.WriteLine($"BadCast is null = {bc1 == null}");

Test testObj2 = (Test)obj;
Console.WriteLine($"PublicValue is {testObj2.PublicValue}");

try
{
    BadCast bc2 = (BadCast)obj;
}
catch (InvalidCastException)
{
    Console.WriteLine("INVALID CAST!");
}

Console.WriteLine($"obj is Test = {obj is Test}");
Console.WriteLine($"obj is BadCast = {obj is BadCast}");

Test test2 = CreateInstance<Test>();
Console.WriteLine(test2);

int fourtyTwo = Convert.ToInt32("42");
Console.WriteLine(fourtyTwo);
Console.WriteLine(Convert.ToInt32(new Convertible()));

T CreateInstance<T>() where T : new()
{
    T instance = new();

    foreach (PropertyInfo propertyInfo in testType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
    {
        DefaultValueAttribute attr = propertyInfo.GetCustomAttribute<DefaultValueAttribute>();
        if (attr != null)
        {
            propertyInfo.SetValue(instance, attr.Value);
        }
    }

    return instance;
}

// Assembly assembly = typeof(StringBuilder).Assembly;
// foreach (Type t in assembly.GetTypes())
// {
//     Console.WriteLine($"{t.Name}");
// }

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class DefaultValueAttribute : Attribute
{
    public object Value { get; init; }
}

internal record Test
{
    private static readonly int PrivateStaticFieldNumber;
    public static int PublicStaticFieldNumber;

    private static int PrivateStaticNumber { get; set; }
    public static int PublicStaticNumber { get; set; }

    private readonly int _privateFieldNumber;
    public int PublicFieldNumber;

    private int PrivateNumber { get; set; }

    [DefaultValue(Value = 42)]
    public int PublicNumber { get; set; }

    [DefaultValue(Value = "Hello, world!")]
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

internal class BadCast
{
}

internal class Convertible : IConvertible
{
    public TypeCode GetTypeCode()
    {
        return TypeCode.Object;
    }

    public bool ToBoolean(IFormatProvider provider)
    {
        return true;
    }

    public byte ToByte(IFormatProvider provider)
    {
        return 42;
    }

    public char ToChar(IFormatProvider provider)
    {
        return 'c';
    }

    public DateTime ToDateTime(IFormatProvider provider)
    {
        return new DateTime(2005, 01, 02);
    }

    public decimal ToDecimal(IFormatProvider provider)
    {
        return 42.5M;
    }

    public double ToDouble(IFormatProvider provider)
    {
        return 42.5;
    }

    public short ToInt16(IFormatProvider provider)
    {
        return 42;
    }

    public int ToInt32(IFormatProvider provider)
    {
        return 42;
    }

    public long ToInt64(IFormatProvider provider)
    {
        return 42;
    }

    public sbyte ToSByte(IFormatProvider provider)
    {
        return 42;
    }

    public float ToSingle(IFormatProvider provider)
    {
        return 42.5f;
    }

    public string ToString(IFormatProvider provider)
    {
        return "Hello, world!";
    }

    public object ToType(Type conversionType, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public ushort ToUInt16(IFormatProvider provider)
    {
        return 42;
    }

    public uint ToUInt32(IFormatProvider provider)
    {
        return 42;
    }

    public ulong ToUInt64(IFormatProvider provider)
    {
        return 42;
    }
}