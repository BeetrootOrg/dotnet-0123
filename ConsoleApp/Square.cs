namespace Geometric
{
    public class Square : Figure
    {
        public double Side {get; set;}
        public Square(double a)
        {
            Type = "Square";
            Side = a;
            Perimeter = SetPerimeter(a);
            Area = SetArea(a);
            SidesNumber = 4;
        }
        private double SetPerimeter(double a)
        {
            if(a<= 0)
            {
                throw new ArgumentException("Invalid data");
            }
            return a*4;
        }
        private double SetArea(double a)
        {
            if(a<= 0)
            {
                throw new ArgumentException("Invalid data");
            }
            return a*a;
        }

        public override bool Equals(object? obj)
        {
            return obj is Square newobj &&
            Side == newobj.Side;
        }
    }
}