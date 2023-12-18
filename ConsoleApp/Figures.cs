namespace Geometry
{
    public class Figures
    {
        public string Type {get; init;}
        public int SidesNumber {get; init;}
        public virtual double Area() 
        {
            return 0;
        }
        public virtual double Perimeter()
        {
            return 0;
        }

        public void PrintInfo()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Type: {Type}, Area: {Area()}, Perimeter: {Perimeter()}, Sides:{SidesNumber}";
        }

        public override bool Equals(object obj)
        {
            return obj is Figures figures &&
            Type == figures.Type &&
            SidesNumber == figures.SidesNumber &&
            Perimeter() == figures.Perimeter() &&
            Area() == figures.Area();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, SidesNumber, Perimeter(), Area());
        }
    }
}