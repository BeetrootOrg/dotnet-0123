using Geometry;

Triangle triangle1 = new Triangle(4, 5, 6);

Rectangle rectangle1 = new Rectangle(5, 6);

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

