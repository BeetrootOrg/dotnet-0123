using Geometric;

Rectangle first = new Rectangle(2, 3);
Square second = new Square(2);
Triangle third = new Triangle(2,2,3);
Circle fourth = new Circle(4);
Circle fifth = new Circle(4);
Circle ttt = new Circle(3);
Circle fff = new Circle(4);
  

Console.WriteLine(fourth.Equals(ttt));
Console.WriteLine(fourth.Equals(fifth));
Console.WriteLine(ttt.Equals(fff));



Console.WriteLine(first.ToString());
Console.WriteLine(second.ToString());
Console.WriteLine(third.ToString());
Console.WriteLine(fourth.ToString());
