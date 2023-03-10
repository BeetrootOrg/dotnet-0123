using ConsoleApp;

Point3D point1 = new Point3D(42, 0, 0.56);
Console.WriteLine($"point1: {point1}");

Point3D point2 = new Point3D(42, 0, 0.56);
Console.WriteLine($"point2: {point2}");

Point3D point3 = new Point3D(42, 1, 0.56);
Console.WriteLine($"point3: {point3}");

Console.WriteLine($"point1==point2: {point1==point2}");
Console.WriteLine($"point1!=point2: {point1!=point2}");
Console.WriteLine($"point1==point3: {point1==point3}");

Console.WriteLine($"point1+point2: {point1+point2}");
Console.WriteLine($"point1-point2: {point1-point2}");
Console.WriteLine($"point1*3: {point1*3}");

double number = (double)point1;
Console.WriteLine($"number: {number}");
