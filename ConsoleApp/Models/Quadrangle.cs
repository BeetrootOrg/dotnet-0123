namespace ConsoleApp.Models
{
    public class Quadrangle : Figure
    {
        public int SideA { get; set; }
        public int SideB { get; set; }
        public int SideC { get; set; }
        public int SideD { get; set; }
        public override double Square
        {
            get
            {
                double p = Perimeter / 2;
                return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            }
        }
        public override double Perimeter => SideA + SideB + SideC;

        public Quadrangle(int sideA, int sideB, int sideC, int sideD)
        {
            SideA = Math.Abs(sideA);
            SideB = Math.Abs(sideB);
            SideC = Math.Abs(sideC);
            SideD = Math.Abs(sideD);
            if (!Check()) throw new Exception("You entered incorrect parameters");
            Type = "Triangle";
            SidesNumber = 3;
        }
        public override bool Check()
        {
            return (SideA + SideB + SideC) > SideD && (SideD + SideB + SideC) > SideA && (SideA + SideD + SideC) > SideB && (SideA + SideB + SideD) > SideC;
        }

        public override bool Equals(object? obj)
        {
            if (!base.Equals(obj)) return false;
            var r = (Quadrangle)obj;
            return SideA == r.SideA && SideB == r.SideB && SideC == r.SideC && SideD == r.SideD;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode, SideA, SideB, SideC, SideD);
        }

        public override string? ToString()
        {
            return $"{Type}, SideA={SideA} SideB={SideB} SideC={SideC} SideD={SideD}";
        }
    }
}