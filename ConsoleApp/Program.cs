using System;
using ConsoleApp;

Stack<int> stack = new ConsoleApp.Stack<int>();
System.Console.WriteLine(stack.Count);

stack.Push(30);
stack.Push(1);
stack.Push(2);
stack.Push(24);

System.Console.WriteLine(stack);

int[] arr = stack.ToArray();

System.Console.WriteLine(String.Join(", ", arr));