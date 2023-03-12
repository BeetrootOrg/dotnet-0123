namespace ConsoleApp
{
    public class Figure
    {
        public virtual string Type { get; init; }
        public virtual double Area { get; init; }
        public virtual double Perimeter { get; init; }
        public virtual int SidesNumber { get; init; }

        public Figure()
        {
            Type = "Figure";
            Area = 0;
            Perimeter = 0;
            SidesNumber = 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Figure figure)
            {
                return Type == figure.Type
                    && Area == figure.Area
                    && Perimeter == figure.Perimeter
                    && SidesNumber == figure.SidesNumber;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Area, Perimeter, SidesNumber);
        }

        public override string? ToString()
        {
            return $"It's a {Type}, that has {SidesNumber} sides, {Perimeter} perimeter, {Area} area";
        }
    }
}