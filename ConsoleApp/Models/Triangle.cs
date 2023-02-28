namespace ConsoleApp.Models
{
    public class Triangle : Figure
    {
        public int SideA { get; set; }
        public int SideB { get; set; }
        public int SideC { get; set; }
        public override double Square
        {
            get
            {
                double p = Perimeter / 2;
                return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            }
        }
        public override double Perimeter => SideA + SideB + SideC;

        public Triangle(int sideA, int sideB, int sideC)
        {
            SideA = Math.Abs(sideA);
            SideB = Math.Abs(sideB);
            SideC = Math.Abs(sideC);
            if (!Check()) throw new Exception("You entered incorrect parameters");
            Type = "Triangle";
            SidesNumber=3;
        }
        public override bool Check()
        {
            return (SideA + SideB) > SideC && (SideC + SideB) > SideA && (SideA + SideC) > SideB;
        }
    }
}