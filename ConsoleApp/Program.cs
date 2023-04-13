using System;

Console.WriteLine("Enter picture text:");
var input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input))
{
    throw new ArgumentException("Enter some text!");
}

Console.WriteLine("Enter filename:");