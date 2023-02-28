namespace ConsoleApp.Models
{
    public class Circle : Figure
    {
        public int Radius { get; set; }
        public override double Square=>Math.PI*Radius*Radius;
        public override double Perimeter => 2*Math.PI*Radius;

        public Circle(int radius)
        {
            Radius = Math.Abs(radius);
            if (!Check()) throw new Exception("You entered incorrect parameters");
            Type = "Circle";
            SidesNumber=-1;
        }
    }
}