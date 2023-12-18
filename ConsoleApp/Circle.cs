namespace Geometry
{
    public class Circle : Figures
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            _radius = radius;
            Type = "Circle";
            SidesNumber = -1;
        }

        public override double Perimeter()
        {
            return 2*(Math.PI * _radius);
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }

        // public override string ToString()
        // {
        //     return $"Type: {Type}, Area: {Area()}, Perimeter: {Perimeter()}, SidesNumber:{SidesNumber}";
        // }
    }
}