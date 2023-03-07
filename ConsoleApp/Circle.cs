namespace Geometric
{
    public class Circle : Figure
    {
        public double Radius {get; set;}
        public Circle(double radius)
        {
            Type = "Circle";
            Radius = radius;
            Perimeter = SetPerimeter(radius);
            Area = SetArea(radius);
            SidesNumber = -1;
        }  
        private double SetPerimeter(double radius)
        {
            if(radius<= 0)
            {
                throw new ArgumentException("Invalid data");
            }
            return Math.PI*radius*2;
        }
        private double SetArea(double radius)
        {
            if(radius<= 0)
            {
                throw new ArgumentException("Invalid data");
            }
            return Math.PI*radius*radius;
        }

        public override bool Equals(object? obj)
        {
            return obj is Circle newobj &&
            Radius == newobj.Radius;
        }
    }
}