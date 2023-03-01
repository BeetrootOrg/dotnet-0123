namespace Geometry
{
    public class Rectangle : Shape
    {
        private double _a; 
        public double _b;

        public override double Perimeter
        {
            get => (_a + _b) * 2;
        }

        public override double Area
        {
            get => _a * _b;
        } 

        public Rectangle(double a, double b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new Exception(); 
            }
            _a = a;
            _b = b;
            _sides = 4;
        }

        public override string ToString()
        {
            return $"Type: {Type}; " +
                $"Side A: {_a}; " +
                $"Side B: {_b}; " +
                $"Perimeter: {Perimeter}; " +
                $"Area: {Area}; " + 
                $"SidesNumber: {_sides}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Rectangle rectangle && _a == rectangle._a && _b == rectangle._b;  
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

