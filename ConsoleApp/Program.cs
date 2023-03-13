using System;
using GenericStack;

Stack <string> first = new Stack<string>();
Console.WriteLine(first.Count);
first.Puch("hello");
first.Puch("hello1");
first.Puch("hello2");
first.Puch("hello3");
Console.WriteLine(first.Count);
first.Pop();
Console.WriteLine(first.Peek());
Console.WriteLine(first.Count);
first.Clear();
first.Pop();
Console.WriteLine(first.Count);

