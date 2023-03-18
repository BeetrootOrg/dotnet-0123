using System;

using ConsoleApp;


Stack<int> stack = new();

stack.Push(1);
stack.Push(2);
stack.Push(3);
Console.WriteLine(stack);

stack.Pop();
Console.WriteLine(stack);

stack.Clear();
Console.WriteLine(stack);

stack.Push(10);
stack.Push(11);
stack.Push(12);

Console.WriteLine(stack.Peek());

int[] arr1 = new int[2];
int[] arr2 = new int[3];
int[] arr3 = new int[4];

stack.CopyTo(arr1);
stack.CopyTo(arr2);
stack.CopyTo(arr3);

static void WriteLineArray<T>(T[] arr)
{
    Console.WriteLine(string.Join(", ", arr));
}

WriteLineArray(arr1);
WriteLineArray(arr2);
WriteLineArray(arr3);