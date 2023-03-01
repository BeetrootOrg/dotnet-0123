using Geometry;

Triangle triangle1 = new Triangle(3, 4, 5);
Console.WriteLine(triangle1);
Triangle triangle2 = new Triangle(3, 4, 5);
Console.WriteLine(triangle1.Equals(triangle2));

Rectangle rectangle1 = new Rectangle(4, 5);
Console.WriteLine(rectangle1);
Rectangle rectangle2 = new Rectangle(4, 5);
Console.WriteLine(rectangle1.Equals(rectangle2));

Square square1 = new Square(5);
Console.WriteLine(square1);
Square square2 = new Square(5);
Console.WriteLine(square1.Equals(square2));

Circle circle1 = new Circle(5);
Console.WriteLine(circle1);
Circle circle2 = new Circle(5);
Console.WriteLine(circle1.Equals(circle2));

Console.WriteLine();
