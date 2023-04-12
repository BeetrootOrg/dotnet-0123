
ConsoleApp.Stack<string> stack = new ConsoleApp.Stack<string>();
Console.WriteLine(stack.Count);

stack.Push("Hello");
stack.Push("World");
stack.Push("!");

Console.WriteLine(stack.Count);

string[] arr1 = new string[3];

stack.CopyTo(arr1, 0);

Console.WriteLine(String.Join("-*-", arr1));

string b = stack.Peek();

Console.WriteLine(b);

stack.CopyTo(arr1, 0);

Console.WriteLine(String.Join("-!-", arr1));

stack.Pop();

string[] arr2 = new string[2];

stack.CopyTo(arr2, 0);

Console.WriteLine(String.Join("(*)", arr2));

stack.Clear();

