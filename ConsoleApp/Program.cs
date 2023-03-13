using System;
using System.Collections.Generic;

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