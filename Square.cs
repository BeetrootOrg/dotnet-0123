namespace ConsoleApp
{
    public class Square : Figures
    {
        public double Side {get; set;}

        public Square()
        {
            FigureType = "Square";
            NumOfSides = 4;
        }

        public double Area()
        {

            return Side*Side;

        }

        public double Perimeter()
        {
            return Side*4;
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