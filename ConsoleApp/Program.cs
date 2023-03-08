using ConsoleApp;

Figure figure = new();
Figure figure1 = new();

System.Console.WriteLine(figure.Equals(figure1));

Circle circle1 = new Circle(30);
Circle circle2 = new Circle(31);
Circle circleEmpty = new();

Console.WriteLine(figure.Equals(circle1));
Console.WriteLine(figure.Equals(circleEmpty));
Console.WriteLine(circle1.Equals(circle2));

Square square = new Square(10);
Square square2 = new Square(10);
Square square3 = new Square(11);

Rectangle rectangle = new Rectangle(10,10);

Console.WriteLine(square.GetHashCode());
Console.WriteLine(rectangle.GetHashCode());
Console.WriteLine(square.Equals(square2));
Console.WriteLine(square.Equals(square3));

