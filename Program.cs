using ConsoleApp;

ConsoleApp.Stack<string> s1 = new ConsoleApp.Stack<string>();
Console.WriteLine(s1.count);

s1.Push("Hello");
s1.Push("World");
s1.Push("!");

Console.WriteLine(s1.count);

string[] arr1 = new string[3];

s1.CopyTo(arr1);

Console.WriteLine(String.Join(", ", arr1));

string b = s1.Peek();

Console.WriteLine(b);

s1.CopyTo(arr1);

Console.WriteLine(String.Join(", ", arr1));

s1.Pop();

string[] arr2 = new string[2];

s1.CopyTo(arr2);

Console.WriteLine(String.Join(", ", arr2));
