namespace Geometry
{
    public class Triangle : Shape
    {   
        private double _a;
        private double _b;
        private double _c;

        public override double Perimeter
        {
            get => _a + _b + _c;
        }

        public override double Area
        {
            get
            {
                double p = Perimeter / 2;
                return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
            }
        }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new Exception(); 
            }
            _a = a;
            _b = b;
            _c = c;
            _sides = 3;
        }

        public override string ToString()
        {
            return $"Type: {Type}; " +
                $"Side A: {_a}; " +
                $"Side B: {_b}; " +
                $"Side C: {_c}; " +
                $"Perimeter: {Perimeter}; " +
                $"Area: {Area}; " + 
                $"SidesNumber: {_sides}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Triangle triangle && _a == triangle._a && _b == triangle._b && _c == triangle._c;  
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}