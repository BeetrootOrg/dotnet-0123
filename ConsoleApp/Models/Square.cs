namespace ConsoleApp.Models
{
    public class SquarE : Figure
    {
        public int SideA { get; set; }
        public override double Square=>SideA*SideA;
        public override double Perimeter => 4*SideA;

        public SquarE(int sideA)
        {
            SideA = Math.Abs(sideA);
            if (!Check()) throw new Exception("You entered incorrect parameters");
            Type = "Square";
            SidesNumber=4;
        }
    }
}