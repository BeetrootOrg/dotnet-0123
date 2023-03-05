using Geometry;

Point3D point1 = new Point3D(1, 2, 3);
Point3D point2 = new Point3D(2, 3, 4);

Console.WriteLine(point1);
Console.WriteLine(point2);

Point3D point3 = point1 + point2;

Console.WriteLine(point3);

Console.WriteLine(5 * point3);
Console.WriteLine(point3 * 5);

double d = (double)point1;
Console.WriteLine(d);

Console.WriteLine(point1 == point2);
