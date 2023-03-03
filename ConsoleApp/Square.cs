namespace ConsoleApp
{
    public class Square : Figure
    {
        double side;
        
        public Square(double a)
        {
            if (a < 0)
            {
                throw new ArgumentException("Invalid Output");
            }
            side = a;
            Type = "Square";
            SidesNumber = 4;
            SetArea();
            SetPerimeter();
        }
        public Square()
        {
            Type = "Square";
            SidesNumber = 4;
            base.SetArea();
            base.SetPerimeter();
        }
        public override void SetArea()
        {
            Area = side*side;
        }

        public override void SetPerimeter()
        {
            Perimeter = side*4;
        }
    }
}