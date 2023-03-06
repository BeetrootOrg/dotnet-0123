using Geometry;

Triangle triangle1 = new Triangle(4, 5, 6);

Rectangle rectangle1 = new Rectangle(5, 6);

static void PrintGeometryInfo(Figures figures)
{
    figures.PrintInfo();
}

PrintGeometryInfo(triangle1);
PrintGeometryInfo(rectangle1);

