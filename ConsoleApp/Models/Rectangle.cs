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
    }
}