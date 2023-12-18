namespace Geometry
{
    public class Square : Figures
    {
        private readonly double _a;
        public Square(double a)
        {
            _a = a;
            Type = "Square";
            SidesNumber = 4;
        }

        public override double Perimeter()
        {
            return _a * 4;
        }

        public override double Area()
        {
            return Math.Pow(_a, 2);
        }

        // public override string ToString()
        // {
        //     return base.ToString();
        // }
    }
}