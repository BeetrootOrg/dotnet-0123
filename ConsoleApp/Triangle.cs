namespace Geometric
{
    public class Triangle : Figure
    {       
        public double Side1 {get; set;}
        public double Side2 {get; set;}
        public double Side3 {get; set;}
        public Triangle( double a, double b, double c)
        {
            Type = "Triangle";
            Side1 = a;
            Side2 = b;
            Side3 = c;
            Perimeter = SetPerimeter(a, b, c);
            Area = SetArea(a,b,c);
            SidesNumber = 3;
        }
        private double SetArea(double a, double b, double c)
        {
            if((a+b) < c || (b+c) < a || (a+c) < b || a<=0 || b<=0 || c<=0)
            {
                throw new ArgumentException ("Invalid data");
            }
            return Math.Sqrt(((a+b+c)/2)*(((a+b+c)/2)-a)*(((a+b+c)/2)-b)*(((a+b+c)/2)-c));
        }
        private double SetPerimeter (double a, double b, double c)
        {
            if((a+b) < c || (b+c) < a || (a+c) < b || a<=0 || b<=0 || c<=0)
            {
                throw new ArgumentException ("Invalid data");
            }
            return a+b+c;
        }
        
        public override bool Equals(object? obj)
        {
            return obj is Triangle newobj &&
            Side1 == newobj.Side1&&
            Side2 == newobj.Side2&&
            Side3 == newobj.Side3;
        }
    }
} 
