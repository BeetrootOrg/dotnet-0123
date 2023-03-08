namespace ConsoleApp
{
    public class Rectangle : Figure
    {
        double[] sides = new double[2];
        
        public Rectangle(double a, double b)
        {
            if ((a<0)||(b<0))
            {
                throw new ArgumentException("incorrect input");
            }
            sides[0] = a;
            sides[1] = b;
            Type = "Rectangle";
            SidesNumber = 4;
            SetArea();
            SetPerimeter();
        }
        public Rectangle()
        {
            Type = "Rectangle";
            SidesNumber = 4;
            base.SetArea();
            base.SetPerimeter();
        }
        protected override void SetArea()
        {
            Area = sides[0]*sides[1];
        }

        protected override void SetPerimeter()
        {
            Perimeter = sides[0]*2+sides[1]*2;
        }

        public override bool Equals(object? obj)
        {
            return obj is Rectangle rectangle && 
                base.Equals(rectangle);
        }
    }
}