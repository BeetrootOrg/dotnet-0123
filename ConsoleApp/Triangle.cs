namespace ConsoleApp
{
    class Triangle : Figure
    {
        public double FirstSide { get; init; }
        public double SecondSide { get; init; }
        public double ThirdSide { get; init; }

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            if ((firstSide + secondSide) < thirdSide || firstSide < 0 || secondSide < 0 || thirdSide < 0)
            {
                throw new ArgumentException("The triangle can't exist.");
            }

            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;

            Type = "Triangle";
            SidesNumber = 3;
            Perimeter = firstSide + secondSide + thirdSide;

            // Calculate the semiperimeter
            double semi = (firstSide + secondSide + thirdSide) / 2;
            // Calculate the area using Heron's formula
            Area = Math.Sqrt(semi * (semi - firstSide) * (semi - secondSide) * (semi - thirdSide));
        }

        public override bool Equals(object? obj)
        {
            return obj is Triangle triangle
                   && base.Equals(obj)
                   && FirstSide == triangle.FirstSide
                   && SecondSide == triangle.SecondSide
                   && ThirdSide == triangle.ThirdSide;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstSide, SecondSide, ThirdSide);
        }
    }
}