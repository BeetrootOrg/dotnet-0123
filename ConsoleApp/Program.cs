using System;
using System.Collections.Generic;
using System.Threading;

using ConsoleApp;

AddOverflowDelegate overflow = (long result) => (int)result;
#pragma warning disable
AddSuccessDelegate success = (int result) => Console.WriteLine(result);
#pragma warning restore

int result1 = Test.Add(1, 2, overflow, success);
int result2 = Test.Add(int.MaxValue, 1, overflow, success);

int result3 = Test.Add(10, 20,
    (long result) => throw new Exception("Unexpected"),
    (int result) => Console.WriteLine($"10+20={result}"));

List<int> numbers = new();

OnChangeableChange writeline = (obj, args) => Console.WriteLine($"Number changed from {args.Old} to {args.New}");
OnChangeableChange tracker = (obj, args) => numbers.Add(args.Old);

Changeable c1 = new()
{
    Number = 42
};

c1.OnChangeableChangeEvent += writeline;
c1.OnChangeableChangeEvent += tracker;

c1.Number = 43;
c1.Number = 44;
c1.Number = 44;
c1.Number = 42;

Console.WriteLine(string.Join(", ", numbers));

foreach (int item in new WhereEnumerable<int>(new[] { 1, 2, 3, 4 }, (item) => item % 2 == 0))
{
    Console.WriteLine(item);
}

foreach (string item in new WhereEnumerable<string>(new[] { "hello", "world", "!" }, (item) => item.Length > 3))
{
    Console.WriteLine(item);
}

#pragma warning disable
foreach (string item in new WhereEnumerable<object>(new object[] { "hello", 1, "world", 2, "!", 3 }, (item) => item is string))
#pragma warning restore
{
    Console.WriteLine(item);
}

int called = 0;
Timer t1 = new((state) => Console.WriteLine($"Called: {++called}"),
    null,
    TimeSpan.Zero,
    TimeSpan.FromSeconds(1));

Timer t2 = new((state) => Console.WriteLine("Second timer"),
    null,
    Timeout.Infinite,
    Timeout.Infinite);

Thread.Sleep(5000);
Console.ForegroundColor = ConsoleColor.Yellow;
t2.Change(TimeSpan.Zero, TimeSpan.FromSeconds(1));
Thread.Sleep(5000);

