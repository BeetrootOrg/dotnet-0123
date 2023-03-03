namespace ConsoleApp
{
    public class Triangle : Figure
    {
        double[] sides = new double[3];

        public Triangle(int a, int b, int c)
        {
            if (((a + b) < c) || ((b + c) < a) || ((a + c) < b) || (a < 0) || (b < 0) || (c < 0))
            {
                throw new ArgumentException("Invalid Output");
            }
            sides[0] = a;
            sides[1] = b;
            sides[2] = c;
            Type = "Triangle";
            SidesNumber = 3;
            SetArea();
            SetPerimeter();
        }
        public Triangle()
        {
            Type = "Triangle";
            SidesNumber = 3;
            base.SetArea();
            base.SetPerimeter();
        }
        public override void SetArea()
        {
            // p is half perimeter
            double p = (sides[0] + sides[1] + sides[2]) / 2;
            Area = Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
        }

        public override void SetPerimeter()
        {
            Perimeter = sides[0] + sides[1] + sides[2];
        }
    }
}