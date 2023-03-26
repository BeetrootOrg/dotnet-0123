using ConsoleApp;

ConsoleApp.Stack<int> s = new();
int[] arr = new int[2];
s.Push(1);
s.Push(3);
s.Push(8);

s.CopyTo(arr);
s.Clear();
foreach (var item in arr)
{
    Console.WriteLine(item);
}
Console.WriteLine(s.Count);