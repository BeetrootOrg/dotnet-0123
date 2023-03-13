using ConsoleApp;

Point p1 = new(2, 3, 4);
Point p2 = new(2, 3, 4);
Console.WriteLine(p1);
Console.WriteLine(p1.Equals(p2));
Console.WriteLine(p1 + p2);
Console.WriteLine(p1 - p2);
Console.WriteLine(p1 * 5);

// Console.WriteLine(p1 == p2);
// Console.WriteLine(p1 != p2);

Console.WriteLine(Point.Const(p2));