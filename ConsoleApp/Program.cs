using System;
Console.WriteLine("Hello");
public abstract class GeometricFigure {
    public abstract string Type { get; }
    public abstract double Area { get; }
    public abstract double Perimeter { get; }
    public abstract int SidesNumber { get; }
}

public class Triangle : GeometricFigure {
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public override string Type => "Triangle";
    public override double Area {
        get {
            double s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
    }
    public override double Perimeter => A + B + C;
    public override int SidesNumber => 3;
}

public class Rectangle : GeometricFigure {
    public double Width { get; set; }
    public double Height { get; set; }

    public override string Type => "Rectangle";
    public override double Area => Width * Height;
    public override double Perimeter => 2 * (Width + Height);
    public override int SidesNumber => 4;
}

public class Square : Rectangle {
    public double Side {
        get => Width;
        set {
            Width = value;
            Height = value;
        }
    }

    public override string Type => "Square";
}

public class Circle : GeometricFigure {
    public double Radius { get; set; }

    public override string Type => "Circle";
    public override double Area => Math.PI * Math.Pow(Radius, 2);
    public override double Perimeter => 2 * Math.PI * Radius;
    public override int SidesNumber => -1;
}
