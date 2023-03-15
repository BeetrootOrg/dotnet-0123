namespace ConsoleApp
{
    public class Figure
    {
        public virtual string Type => "Figure";
        public virtual int SidesNumber => 0;

        protected Figure()
        {
        }

        public virtual double Perimeter()
        {
            return 0;
        }

        public virtual double Area()
        {
            return 0;
        }
    }

    public class Triangle : Figure
    {
        public override string Type => "Triangle";
        public override int SidesNumber => 3;

        private readonly decimal _side1;
        private readonly decimal _side2;
        private readonly decimal _side3;

        public Triangle(decimal side1, decimal side2, decimal side3)
        {
            ValidateSides(side1, side2, side3);

            _side1 = side1;
            _side2 = side2;
            _side3 = side3;
        }

        public override double Area()
        {
            decimal p = (_side1 + _side2 + _side3) / 2.0M;
            return Math.Sqrt((double)(p * (p - _side1) * (p - _side2) * (p - _side3)));
        }

        public override double Perimeter()
        {
            return (double)(_side1 + _side2 + _side3);
        }

        public override string ToString()
        {
            return $"Type: {Type}, Sides: {SidesNumber}, Area: {Area()}, Perimeter: {Perimeter()}";
        }

        public override bool Equals(object obj)
        {
            return obj is Triangle triangle &&
                _side1 == triangle._side1 &&
                _side2 == triangle._side2 &&
                _side3 == triangle._side3;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_side1, _side2, _side3);
        }

        private static void ValidateSides(decimal side1, decimal side2, decimal side3)
        {
            if (side1 > side2 + side3 ||
                side2 > side1 + side3 ||
                side3 > side1 + side2)
            {
                throw new ArgumentException("The sum of any two sides must be greater than the third side!");
            }
        }
    }

    public class Rectangle : Figure
    {
        public override string Type => "Rectangle";
        public override int SidesNumber => 4;

        private readonly decimal _side1;
        private readonly decimal _side2;

        public Rectangle(decimal side1, decimal side2)
        {
            ValidateSides(side1, side2);

            _side1 = side1;
            _side2 = side2;
        }

        public override double Area()
        {
            return (double)(_side1 * _side2);
        }

        public override double Perimeter()
        {
            return (double)(2 * (_side1 + _side2));
        }

        public override string ToString()
        {
            return $"Type: {Type}, Sides: {SidesNumber}, Area: {Area()}, Perimeter: {Perimeter()}";
        }

        public override bool Equals(object obj)
        {
            return obj is Rectangle rectangle &&
                _side1 == rectangle._side1 &&
                _side2 == rectangle._side2;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_side1, _side2);
        }

        private static void ValidateSides(decimal side1, decimal side2)
        {
            if (side1 <= 0 || side2 <= 0)
            {
                throw new ArgumentException("Sides must be greater than 0!");
            }
        }
    }

    public class Square : Figure
    {
        public override string Type => "Square";
        public override int SidesNumber => 4;

        private readonly decimal _side;

        public Square(decimal side)
        {
            ValidateSide(side);

            _side = side;
        }

        public override double Area()
        {
            return (double)(_side * _side);
        }

        public override double Perimeter()
        {
            return (double)(4 * _side);
        }

        public override string ToString()
        {
            return $"Type: {Type}, Sides: {SidesNumber}, Area: {Area()}, Perimeter: {Perimeter()}";
        }

        public override bool Equals(object obj)
        {
            return obj is Square square &&
                _side == square._side;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_side);
        }

        private static void ValidateSide(decimal side)
        {
            if (side <= 0)
            {
                throw new ArgumentException("Side must be greater than 0!");
            }
        }
    }

    public class Circle : Figure
    {
        public override string Type => "Circle";
        public override int SidesNumber => -1;

        private readonly decimal _radius;

        public Circle(decimal radius)
        {
            ValidateRadius(radius);

            _radius = radius;
        }

        public override double Area()
        {
            return Math.PI * (double)(_radius * _radius);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * (double)_radius;
        }

        public override string ToString()
        {
            return $"Type: {Type}, Sides: {SidesNumber}, Area: {Area()}, Perimeter: {Perimeter()}";
        }

        public override bool Equals(object obj)
        {
            return obj is Circle circle &&
                _radius == circle._radius;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_radius);
        }

        private static void ValidateRadius(decimal side)
        {
            if (side <= 0)
            {
                throw new ArgumentException("Radius must be greater than 0!");
            }
        }
    }
}