namespace Geometry
{
    public class Triangle : Figures
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
               double _p = Perimeter / 2;
               return Area = Math.Sqrt(_p*(_p - _a)*(_p - _b)*(_p - _c));
            }
        }
        public Triangle(double a, double b, double c)
        {
            if (((a + b) < c) || ((b + c) < a) || ((a + c) < b) || (a < 0) || (b < 0) || (c < 0))
            {
                throw new ArgumentException("The value is incorrectly");
            }
                _a = a;
                _b = b;
                _c = c;
                Type = "Triangle";
                SidesNumber = 3;  
        }

        public override string ToString()
        {
            return $"Type: {Type}  Area: {Area}  Perimeter: {Perimeter}  SidesNumber: {SidesNumber}";
        }

        public override bool Equals(object obj)
        {
            return obj is Triangle triangle &&
            base.Equals(obj) &&
            Type == triangle.Type &&
            Area == triangle.Area &&
            Perimeter == triangle.Perimeter &&
            SidesNumber == triangle.SidesNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode());
        }
    }
}