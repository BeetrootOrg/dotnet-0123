namespace Geometric
{
    public class Rectangle : Figure
    {
        public double Side1 {get; set;}
        public double Side2 {get; set;}

        public Rectangle( double a, double b)
        {
            Type = "Rectangle";
            Side1 = a;
            Side2 = b;
            Perimeter = SetPerimeter(a, b);
            Area = SetArea(a, b);
            SidesNumber = 4;
        }

        private double SetPerimeter(double a, double b)
        {
            if(a<= 0||b<0)
            {
                throw new ArgumentException("Invalid data");
            }
            return (a+b)*2;
        }
        private double SetArea(double a, double b)
        {
            if(a<= 0||b<0)
            {
                throw new ArgumentException("Invalid data");
            }
            return a*b;
        }

        public override bool Equals(Object obj)
        {
            return obj is Rectangle newobj &&
            Side1 == newobj.Side1&&
            Side2 == newobj.Side2;
        }
    }
}