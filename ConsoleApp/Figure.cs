namespace Geometric
{
    public abstract class Figure
    {
        public string Type { get; protected init; }
        public double Area { get; protected init;}
        public double Perimeter { get; protected init; }
        public double SidesNumber {get; protected init; } 

        public override string ToString()
        {
            return $"Figure type: {Type}. \nArea: {Area}. \nPerimeter: {Perimeter}. \nNumber of sides: {SidesNumber}";
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}