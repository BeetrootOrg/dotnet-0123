namespace ConsoleApp
{
    public class Figure
    {
        protected string Type {get;set;}
        protected double Area {get;set;}
        protected int SidesNumber {get;set;}
        protected double Perimeter {get;set;}

        protected virtual void SetArea()
        {
            Area = 0;
        }
        protected virtual void SetPerimeter()
        {
            Perimeter = 0;
        }

        public Figure()
        {
            Type = "unknown";
            SetArea();
            SetPerimeter();
            SidesNumber = 0;
        }

        public Figure(string type, int sidesNumber, double area, double perimeter)
        {
            if (!((sidesNumber>=0)&&(area>=0)&&(perimeter>=0)))
            {
                throw new ArgumentException("incorrect input");
            }
            Type = type;
            Area = area;
            Perimeter = Perimeter;
            SidesNumber = sidesNumber;
        }

        public override string ToString()
        {
            return $"Type: {Type}, Area: {Area}, Perimeter: {Perimeter}, SidesNumber: {SidesNumber}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Figure figure &&
                    Type == figure.Type &&
                    SidesNumber == figure.SidesNumber &&
                    Perimeter == figure.Perimeter &&
                    Area == figure.Area;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Area, SidesNumber, Perimeter);
        }
    }
}