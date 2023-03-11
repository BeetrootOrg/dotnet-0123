using ConsoleApp;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Point p1 = new Point(4,12,6);

Point p2 = new Point(1, 1, 1);

Console.WriteLine((p2 * 2).ToString());
Console.WriteLine(Point.Cast(p2));