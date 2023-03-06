namespace Geometry
{
    public class Circle : Figures
    {
        private double _r;
        public override double Perimeter
        {
            get => Math.PI * 2 * _r;
        }
        public override double Area 
        {
            get => Math.PI * _r;
        }
        public Circle(double r)
        {
            if( r <= 0)
            {
                throw new ArgumentException("The value is incorrectly");
            }
            _r = r;
            Type = "Circle";
            SidesNumber = 0;
        }
        public override string ToString()
        {
            return $"Type: {Type}  Area: {Area}  Perimeter: {Perimeter}  SidesNumber: {SidesNumber}";
        }
    }
}