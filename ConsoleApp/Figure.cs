namespace ConsoleApp
{
    public class Figure
    {
        protected string Type {get;set;}
        protected double Area {get;set;}
        protected int SidesNumber {get;set;}
        protected double Perimeter {get;set;}

        public virtual void SetArea()
        {
            Area = -1;
        }
        public virtual void SetPerimeter()
        {
            Perimeter = -1;
        }
        public Figure()
        {
            Type = "unknown";
            SetArea();
            SetPerimeter();
            SidesNumber = -1;
        }

        public Figure(string type, int sidesNumber)
        {
            Type = type;
            SetArea();
            SetPerimeter();
            SidesNumber = sidesNumber;
        }

        public override string ToString()
        {
            return $"Type: {Type}, Area: {Area}, Perimeter: {Perimeter}, SidesNumber: {SidesNumber}";
        }
    }
}