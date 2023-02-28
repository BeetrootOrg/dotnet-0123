namespace ConsoleApp.Models
{
    public class Rectangle : Figure
    {
        public int SideA { get; set; }
        public int SideB { get; set; }
        public override double Square=>SideA*SideB;
        public override double Perimeter => 2*(SideA + SideB);

        public Rectangle(int sideA, int sideB)
        {
            SideA = Math.Abs(sideA);
            SideB = Math.Abs(sideB);
            if (!Check()) throw new Exception("You entered incorrect parameters");
            Type = "Rectangle";
            SidesNumber=4;
        }

        public override bool Equals(object? obj)
        {
           if (!base.Equals(obj)) return false;
           var r=(Rectangle)obj;
           return SideA==r.SideA && SideB==r.SideB; 
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode, SideA, SideB);
        }

        public override string? ToString()
        {
            return $"{Type}, SideA={SideA} SideA={SideB}";
        }
    }
}