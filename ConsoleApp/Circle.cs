namespace ConsoleApp
{
    public class Circle : Figure
    {
        double radius;
        
        public Circle(double a)
        {
            if ((a<0))
            {
                throw new ArgumentException("incorrect input");
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
        protected override void SetArea()
        {
            Area = Math.PI*radius*radius;
        }

        protected override void SetPerimeter()
        {
            Perimeter = Math.PI*2*radius;
        }

        public override bool Equals(object? obj)
        {
            return obj is Circle circle && 
                base.Equals(circle);
        }
    }
}