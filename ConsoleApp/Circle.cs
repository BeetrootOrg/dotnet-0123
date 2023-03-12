namespace ConsoleApp
{
    class Circle : Figure
    {
        public double Radius { get; init; }

        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("The circle can't exist.");
            }

            Radius = radius;

            Type = "Circle";
            SidesNumber = -1;
            Perimeter = 2 * Math.PI * radius;
            Area = Math.PI * radius * radius;
        }

        public override bool Equals(object? obj)
        {
            return obj is Circle circle
                   && base.Equals(obj)
                   && Radius == circle.Radius;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Radius, base.GetHashCode());
        }
    }
}