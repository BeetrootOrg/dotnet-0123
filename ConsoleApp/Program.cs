using ConsoleApp;

Point3D p1 = new(1, 2, 3);
Point3D p2 = new(1, 2, 3);

Console.WriteLine(p1);
Console.WriteLine(p1 == p2);
Console.WriteLine(p1.Equals(p2));