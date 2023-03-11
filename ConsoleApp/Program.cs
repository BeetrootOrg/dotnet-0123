using Coordinate;

Point3d point1 = new Point3d(3, 5, 4);
Point3d point2 = new Point3d(5, -2, 0);
Point3d point3 = new Point3d(3, 5, 4);

Console.WriteLine(point1==point2);
Console.WriteLine(point1!=point3);
Console.WriteLine(point1.ToCastPoint());
Console.WriteLine(point1.ToCalculteDistance(point1, point2));
Console.WriteLine(point2);

Console.WriteLine(point3 = point1 - point2);
