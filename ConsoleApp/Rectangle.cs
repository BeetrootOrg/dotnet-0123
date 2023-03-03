namespace ConsoleApp
{
    public class Rectangle : Figure
    {
        double[] sides = new double[2];
        
        public Rectangle(double a, double b)
        {
            if ((a<0)||(b<0))
            {
                throw new ArgumentException("Invalid Output");
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
        public override void SetArea()
        {
            Area = sides[0]*sides[1];
        }

        public override void SetPerimeter()
        {
            Perimeter = sides[0]*2+sides[1]*2;
        }
    }
}