﻿using Geometry;

Triangle triangle1 = new Triangle(4, 5, 6);

Triangle triangle2 = new Triangle(4, 5, 6);

Rectangle rectangle1 = new Rectangle(5, 6);

Rectangle rectangle2 = new Rectangle(7, 6);

Square square1 = new Square(5);

Circle circle1 = new Circle(7);

static void PrintGeometryInfo(Figures figures)
{
    figures.PrintInfo();
}

PrintGeometryInfo(triangle1);
PrintGeometryInfo(rectangle1);
PrintGeometryInfo(square1);
PrintGeometryInfo(circle1);

Console.WriteLine(triangle1.Equals(triangle2));
Console.WriteLine(triangle1.GetHashCode());
Console.WriteLine(triangle2.GetHashCode());

Console.WriteLine(rectangle1.Equals(rectangle2));
Console.WriteLine(rectangle1.GetHashCode());
Console.WriteLine(rectangle2.GetHashCode());