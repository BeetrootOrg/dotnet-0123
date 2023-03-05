namespace ConsoleApp
{
    public class Rectangle : Figures
    {
        public double FirstSide {get; set;}
        public double SecondSide {get; set;}

        public Rectangle()
        {
            FigureType = "Rectangle";
            NumOfSides = 4;
        }

        public double Area()
        {

            return FirstSide*SecondSide;

        }

        public double Perimeter()
        {
            return FirstSide*2 + SecondSide*2;
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