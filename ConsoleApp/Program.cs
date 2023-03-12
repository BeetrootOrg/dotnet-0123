using ConsoleApp;

Figure circle = new Circle(4.5);
Figure triangle = new Triangle(3, 4, 5);
Figure rectangle = new Rectangle(4, 5);
Figure square = new Square(10);
Figure quadrangle = new Quadrangle(6, 8, 6.5, 9, 75, 100, 40, 145);

Figure[] figures = { circle, triangle, rectangle, square, quadrangle };

foreach (var figure in figures)
{
    Console.WriteLine(figure.ToString());
    Console.WriteLine();
}