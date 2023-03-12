namespace ConsoleApp
{
    class Square : Figure
    {
        public double Side { get; init; }

        public Square(double side)
        {
            if (side < 0)
            {
                throw new ArgumentException("The square can't exist.");
            }

            Side = side;

            Type = "Square";
            SidesNumber = 4;
            Perimeter = 4 * side;
            Area = side * side;
        }

        public override bool Equals(object? obj)
        {
            return obj is Square square
                   && base.Equals(obj)
                   && Side == square.Side;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Side, base.GetHashCode());
        }
    }
}