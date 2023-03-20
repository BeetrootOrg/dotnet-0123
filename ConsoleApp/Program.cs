using System;

using ConsoleApp;

Stack<int> stack = new();

stack.Push(1);
stack.Push(2);
stack.Push(3);

Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Count);
Console.WriteLine(stack.Peek());
Console.WriteLine(stack.Count);

stack.Clear();
Console.WriteLine(stack.Count);
