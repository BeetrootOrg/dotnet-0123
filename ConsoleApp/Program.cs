using System;

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

Changeable c1 = new()
{
    OnChangeableChange = (obj, args) => Console.WriteLine($"Number changed from {args.Old} to {args.New}"),
    Number = 42
};

c1.Number = 43;