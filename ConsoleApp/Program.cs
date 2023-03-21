using System;
using System.Collections.Generic;

using ConsoleApp;


Console.WriteLine("Tuple");
(int, int)[] arr = new (int, int)[] { (1, 2), (2, 3), (5, 2), (2, 2) };

foreach (var item in arr.GroupBy<int, (int, int)>(item => item.Item1))
{
    Console.Write($"{item.Key}: ");
    Console.WriteLine(String.Join(", ", item.Value));
}

Console.WriteLine("Array");
int[] array = new int[] { 1, 2, 3, 4, 5, 2 };

foreach (var item in array.GroupBy<int, int>(item => item))
{
    Console.Write($"{item.Key}: ");
    Console.WriteLine(String.Join(", ", item.Value));
}


List<AB> list = new List<AB>()
{
    new AB(1,1),
    new AB(1,3),
    new AB(2,2),
    new AB(1,2),
    new AB(2,1),

};
Console.WriteLine("Struct");
foreach (var item in list.GroupBy<int, AB>(g => g.A))
{
    Console.Write($"{item.Key}: ");
    Console.WriteLine(String.Join(", ", item.Value));
}

Console.WriteLine("Empty");
List<int> emptyList = new List<int>();
foreach (var item in emptyList.GroupBy(g => 0))
{
    Console.Write($"{item.Key}: ");
    Console.WriteLine(String.Join(", ", item.Value));
}

Console.WriteLine("Null");
emptyList = null;
try
{
    foreach (var item in emptyList.GroupBy(g => 0))
    {
        Console.Write($"{item.Key}: ");
        Console.WriteLine(String.Join(", ", item.Value));
    }

}
catch (ArgumentNullException ane)
{
    Console.WriteLine("Not work with null");
}

public struct AB
{
    public AB(int a, int b)
    {
        A = a;
        B = b;
    }

    public int A { get; init; }
    public int B { get; init; }
    public override string ToString()
    {
        return $"{{{A}: {B}}}";
    }
}