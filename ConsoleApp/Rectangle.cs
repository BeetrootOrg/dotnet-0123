namespace Geometry
{
    public class  Rectangle : Figures
    {
        private readonly double _a;
        private readonly double _b;
        public Rectangle(double a, double b)
        {
            _a = a;
            _b = b;
            Type = "Rectangle";
            SidesNumber = 4;
        }

        public override double Perimeter()
        {
            return (_a + _b)* 2;
        }

        public override double Area()
        {
            return _a * _b;
        }

        // public override string ToString()
        // {
        //     return $"Type: {Type}, Area: {Area()}, Perimeter: {Perimeter()}, SidesNumber:{SidesNumber}";
        // }
    }
}