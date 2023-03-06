namespace Geometry
{
    public class Rectangle : Figures
    {
        private double _a;
        private double _b;

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
            if(a == b)
            {
                throw new ArgumentException("The value is incorrectly");
            }
            _a = a;
            _b = b;
            Type = "Rectangle";
            SidesNumber = 4;

        }

        public override string ToString()
        {
            return $"Type: {Type}  Area: {Area}  Perimeter: {Perimeter}  SidesNumber: {SidesNumber}";
        }

        public override bool Equals(object obj)
        {
            return obj is Rectangle rectangle &&
            base.Equals(obj) &&
            Type == rectangle.Type &&
            Area == rectangle.Area &&
            Perimeter == rectangle.Perimeter &&
            SidesNumber == rectangle.SidesNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode());
        }
    }
}