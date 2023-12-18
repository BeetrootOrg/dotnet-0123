
namespace Geometry
{
    public class Triangle : Figures
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;
        public Triangle(double a, double b, double c)
        {
            if (((a + b) < c) || ((b + c) < a) || ((a + c) < b) || (a < 0) || (b < 0) || (c < 0))
            {
                throw new ArgumentException("The sides are incorrect!");
            }

            _a = a;
            _b = b;
            _c = c;
            Type = "Triangle";
            SidesNumber = 3;
        }

        public override double Perimeter()
        {
            return _a + _b + _c;
        }

        public override double Area()
        {
            double _p = Perimeter() / 2;
            return Math.Sqrt(_p*(_p - _a)*(_p - _b)*(_p - _c));
        }
        // public override string ToString()
        // {
        //     return $"Type: {Type}, Area: {Area()}, Perimeter: {Perimeter()}, SidesNumber:{SidesNumber}";
        // }

        public override bool Equals(object obj)
        {
           return obj is Triangle triangle &&
            base.Equals(obj) &&
            _a == triangle._a &&
            _b == triangle._b &&
            _c == triangle._c; 
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), _a, _b, _c);
        }


    }
}