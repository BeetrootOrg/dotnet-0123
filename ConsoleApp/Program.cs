using System;
using ConsoleApp;

LinkedList<int> list = new();
Console.WriteLine(list);
list.Add(1);
Console.WriteLine(list);
list.Add(2);
Console.WriteLine(list);
list.Add(3);
Console.WriteLine(list);
list.Add(4);
Console.WriteLine(list);

list.Clear();
list.Add(1);
Console.WriteLine(list);
list.Add(2);
list.Add(3);
list.Add(4);

list.RemoveAt(0);
list.RemoveAt(1);
list.RemoveAt(1);

list.Clear();
list.Add(1);
list.Add(2);
list.Add(3);

int[] arr1 = new int[2];
int[] arr2 = new int[4];
int[] arr3 = new int[3];

list.CopyTo(arr1);
list.CopyTo(arr2);
list.CopyTo(arr3);

static void WriteLineArray<T>(T[] arr)
{
    Console.WriteLine(string.Join(", ", arr));
}

WriteLineArray(arr1);
WriteLineArray(arr2);
WriteLineArray(arr3);

list.Clear();
list.Add(1);
list.Add(2);
list.Add(3);

list.Insert(4, 0);
list.Insert(5, 2);