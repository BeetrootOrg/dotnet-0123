namespace Geometry
{
    public class Figures
    {
        protected string Type {get; init;}
        public virtual double Area{get; set;}
        public virtual double Perimeter{get; init;}
        protected int SidesNumber{get; init;}

        public void PrintInfo()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Type: {Type}  Area: {Area}  Perimeter: {Perimeter}  SidesNumber: {SidesNumber}";
        }
    }
}