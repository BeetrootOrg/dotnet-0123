using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp
{
    public struct Point : IEquatable <Point>
    {
        public double X {get; set;} 
        public double Y {get; set;}
        public double Z {get; set;}

        public Point(double x) : this(x, 0, 0) 
        {   
        }
        public Point(double x, double y) : this(x, y, 0) 
        {   
        }
        public Point (double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // public override bool Equals(object obj)
        // {
        //     return obj is Point point &&
        //     X == point.X &&
        //     Y == point.Y &&
        //     Z == point.Z;
        // }

        // public override int GetHashCode()
        // {
        //     return HashCode.Combine(X, Y, Z);
        // }

        public bool Equals(Point other)
        {
            return X == other.X &&
            Y == other.Y &&
            Z == other.Z;
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }
        public static Point operator -(Point p)
        {
            return new Point( -p.X, -p.Y, -p.Z);
        }
        public static Point operator -(Point p1, Point p2)
        {
            return p1 + (-p2);
        }
        public static Point operator *(double n, Point p)
        {
            return p * n;
        }
        public static Point operator *(Point p, double n)
        {
            return new Point(p.X * n, p.Y * n, p.Z * n);
        }
        public static double Const(Point p1)
        {
             return Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y + p1.Z * p1.Z);
        }

        // public static bool operator ==(Point p1, Point p2)
        // {
        //     return p1.Equals(p2);
        // }
        // public static bool operator !=(Point p1, Point p2)
        // {
        //     return !p1.Equals(p2);
        // }

        public override string ToString()
        {
            return $"({X}) ({Y}) ({Z})";
        }
    }
}