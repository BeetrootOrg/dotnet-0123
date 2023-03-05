using ConsoleApp;

Triangle triangle1 = new Triangle()
{
    FirstSide = 5,
    SecondSide = 6,
    ThirdSide = 7
};

Rectangle rectangle1 = new Rectangle()
{
    FirstSide = 5,
    SecondSide = 6
};

Square square1 = new Square()
{
    Side = 5
};

Circle circle1 = new Circle()
{
    Radius = 1
};

Console.WriteLine(triangle1.Type());

Console.WriteLine(triangle1.Area());

Console.WriteLine(triangle1.Perimeter());

Console.WriteLine(triangle1.SidesNumber());

Console.WriteLine(rectangle1.Type());

Console.WriteLine(rectangle1.Area());

Console.WriteLine(rectangle1.Perimeter());

Console.WriteLine(rectangle1.SidesNumber());

Console.WriteLine(square1.Type());

Console.WriteLine(square1.Area());

Console.WriteLine(square1.Perimeter());

Console.WriteLine(square1.SidesNumber());

Console.WriteLine(circle1.Type());

Console.WriteLine(circle1.Area());

Console.WriteLine(circle1.Perimeter());

Console.WriteLine(circle1.SidesNumber());
