// ----- 08.03.2023
// ----- Homework 16 Generic classes and methods
// Create generic Stack<T> (what it is) class with next methods:
//        Push(obj) - adds obj at the top of stack
//        Pop() - returns top element of stack & removes it
//        Clear() - clear stack
//    Count - property return number of elements
//    Peek() - returns top element but doesn’t remove it
//    CopyTo(arr) - copies stack to array
using System;
using ConsoleApp.classes;

var stack=new Stack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Push(4);
stack.Push(5);
Console.WriteLine($"Push stack. {stack}");
Console.WriteLine($"Pop stack. Pop Element value={stack.Pop()}. {stack}");
Console.WriteLine($"Peek stack. Peek Element value={stack.Peek()}. {stack}");
var arr=new int[10];
stack.CopyTo(arr);
Console.WriteLine($"CopyTo: {string.Join(',', arr)}");
arr=new int[3];
stack.CopyTo(arr);
Console.WriteLine($"CopyTo: {string.Join(',', arr)}");
stack.Clear();
Console.WriteLine($"Clear stack. {stack}");