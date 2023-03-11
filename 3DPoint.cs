namespace ConsoleApp 
{

    public struct Point
    {
        public double X {get; set; }
        public double Y {get; set; }
        public double Z {get; set; }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }
        public static Point operator +(Point p1, Point p2)
        {
            return new Point (p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point (p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }
        public static Point operator *(Point p1, double n)
        {
            return new Point (p1.X * n, p1.Y * n, p1.Z * n);
        }
        public static bool operator ==(Point p1, Point p2)
        {
            if (p1.X == p2.X & p1.Y == p2.Y & p1.Z == p2.Z )
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Point p1, Point p2)
        {
            if (p1.X != p2.X & p1.Y != p2.Y & p1.Z != p2.Z )
            {
                return true;
            }
            return false;
        }
        public static double Cast(Point p1)
        {
            return Math.Sqrt(p1.X*p1.X + p1.Y*p1.Y + p1.Z*p1.Z);
        }

    }
}