namespace ConsoleApp
{
    public class Circle : Figure
    {
        double radius;
        
        public Circle(double a)
        {
            if ((a<0))
            {
                throw new ArgumentException("Invalid Output");
            }
            radius = a;
            Type = "Circle";
            SidesNumber = -1;
            SetArea();
            SetPerimeter();
        }
        public Circle()
        {
            Type = "Circle";
            SidesNumber = -1;
            base.SetArea();
            base.SetPerimeter();
        }
        public override void SetArea()
        {
            Area = Math.PI*radius*radius;
        }

        public override void SetPerimeter()
        {
            Perimeter = Math.PI*2*radius;
        }
    }
}