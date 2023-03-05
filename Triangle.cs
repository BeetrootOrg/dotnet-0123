namespace ConsoleApp
{
    public class Triangle : Figures
    {
        public double FirstSide {get; set;}
        public double SecondSide {get; set;}
        public double ThirdSide {get; set;}

        public Triangle()
        {
            FigureType = "Triangle";
            NumOfSides = 3;
        }

        public double Area()
        {
            if (FirstSide + SecondSide > ThirdSide & FirstSide + ThirdSide > SecondSide & SecondSide + ThirdSide > FirstSide)
            {
                return Math.Sqrt((Perimeter()/2)*((Perimeter()/2)-FirstSide)*((Perimeter()/2)-SecondSide)*((Perimeter()/2)-ThirdSide));
            }
            return -1;
        }

        public double Perimeter()
        {
            if (FirstSide + SecondSide > ThirdSide & FirstSide + ThirdSide > SecondSide & SecondSide + ThirdSide > FirstSide)
            {
                return FirstSide + SecondSide + ThirdSide;
            }
            return -1;
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