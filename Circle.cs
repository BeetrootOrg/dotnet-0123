namespace ConsoleApp
{
    public class Circle : Figures
    {
        public double Radius {get; set;}


        public Circle()
        {
            FigureType = "Circle";
            NumOfSides = -1;
        }

        public double Area()
        {

            return Math.PI*Radius*Radius;

        }

        public double Perimeter()
        {
            return 2*Radius*Math.PI;
        }
        public new string Type()
        {
            return FigureType;
        }
        public new int SidesNumber()
        {
            return NumOfSides;
        }
    }
}