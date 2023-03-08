using System;
using ConsoleApp;

Stack<int> stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);

int pop = stack.Pop();
Console.WriteLine(pop);

stack.Clear();
Console.WriteLine(stack.Count);

stack.Push(4);
stack.Push(5);

int peek = stack.Peek();
Console.WriteLine(peek);

int[] arr = new int[3];
stack.CopyTo(arr);
Console.WriteLine(String.Join(',', arr));
