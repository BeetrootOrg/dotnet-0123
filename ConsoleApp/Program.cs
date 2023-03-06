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