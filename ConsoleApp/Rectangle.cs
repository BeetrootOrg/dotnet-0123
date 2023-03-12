namespace ConsoleApp
{
    class Rectangle : Figure
    {
        public double FirstSide { get; init; }
        public double SecondSide { get; init; }

        public Rectangle(double firstSide, double secondSide)
        {
            if (firstSide < 0 || secondSide < 0)
            {
                throw new ArgumentException("The rectangle can't exist.");
            }

            FirstSide = firstSide;
            SecondSide = secondSide;

            Type = "Rectangle";
            SidesNumber = 4;
            Perimeter = 2 * (firstSide + secondSide);
            Area = firstSide * secondSide;
        }

        public override bool Equals(object? obj)
        {
            return obj is Rectangle rectangle
                   && base.Equals(obj)
                   && FirstSide == rectangle.FirstSide
                   && SecondSide == rectangle.SecondSide;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstSide, SecondSide, base.GetHashCode());
        }
    }
}