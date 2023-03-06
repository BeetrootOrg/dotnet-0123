namespace Geometry
{
    public class Square : Figures
    {
        private double _a;
        public override double Perimeter
        {
            get => _a * 4;
        }
        public override double Area
        {
            get => Math.Pow(_a, 2);
        }
        public Square(double a)
        {
            if( a < 0)
            {
                throw new ArgumentException("The value is incorrectly");
            }
            _a = a;
            Type = "Square";
            SidesNumber = 4;
        }
        public override string ToString()
        {
            return $"Type: {Type}  Area: {Area}  Perimeter: {Perimeter}  SidesNumber: {SidesNumber}";
        }

        public override bool Equals(object obj)
        {
            return obj is Square square &&
            base.Equals(obj) &&
            Type == square.Type &&
            Area == square.Area &&
            Perimeter == square.Perimeter &&
            SidesNumber == square.SidesNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode());
        }
    }
}