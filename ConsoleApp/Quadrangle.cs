namespace ConsoleApp
{
    class Quadrangle : Figure
    {
        public double FirstSide { get; init; }
        public double SecondSide { get; init; }
        public double ThirdSide { get; init; }
        public double FourthSide { get; init; }
        // Angle between the first and the second sides. 
        public double FirstAngle { get; init; }
        // Angle between the second and the third sides. 
        public double SecondAngle { get; init; }
        // Angle between the third and the fourth sides. 
        public double ThirdAngle { get; init; }
        // Angle between the fourth and the first sides. 
        public double FourthAngle { get; init; }
        public Quadrangle(double firstSide, double secondSide, double thirdSide, double fourthSide,
                          double firstAngle, double secondAngle, double thirdAngle, double fourthAngle)
        {
            if (firstAngle < 0 || secondSide < 0 || thirdSide < 0 || fourthSide < 0
                || firstAngle < 0 || secondAngle < 0 || thirdAngle < 0 || fourthAngle < 0
                || firstSide >= (secondSide + thirdSide + fourthSide)
                || (firstAngle + secondAngle + thirdAngle + fourthAngle) != 360)
            {
                throw new ArgumentException("The quadrangle can't exist.");
            }

            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
            FourthSide = fourthSide;
            FirstAngle = firstAngle;
            SecondAngle = secondAngle;
            ThirdAngle = thirdAngle;
            FourthAngle = fourthAngle;

            Type = "Quadrangle";
            SidesNumber = 4;
            Perimeter = firstSide + secondSide + thirdSide + fourthSide;
            Area = 0.5 * FirstSide * SecondSide * Math.Sin(SecondAngle * Math.PI / 180) + 0.5 * ThirdSide * FourthSide * Math.Sin(FourthAngle * Math.PI / 180);
        }

        public override bool Equals(object? obj)
        {
            return obj is Quadrangle quadrangle
                   && base.Equals(obj)
                   && FirstSide == quadrangle.FirstSide
                   && SecondSide == quadrangle.SecondSide
                   && ThirdSide == quadrangle.ThirdSide
                   && FourthSide == quadrangle.FourthSide
                   && FirstAngle == quadrangle.FirstAngle
                   && SecondAngle == quadrangle.SecondAngle
                   && ThirdAngle == quadrangle.ThirdAngle
                   && FourthAngle == quadrangle.FourthAngle;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                FirstSide,
                SecondSide,
                ThirdSide,
                FourthSide,
                FirstAngle,
                SecondAngle,
                ThirdAngle,
                FourthAngle);
        }
    }
}