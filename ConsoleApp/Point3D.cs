using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp
{
    public struct Point3D : IEquatable<Point3D>
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool Equals(Point3D other)
        {
            return other.X == X
                && other.Y == Y
                && other.Z == Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public override string? ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        public static Point3D operator +(Point3D point1, Point3D point2)
        {
            return new Point3D(point1.X + point2.X, point1.Y + point2.Y, point1.Z + point2.Z);
        }
        public static Point3D operator -(Point3D point1, Point3D point2)
        {
            return new Point3D(point1.X - point2.X, point1.Y - point2.Y, point1.Z - point2.Z);
        }
        public static Point3D operator *(Point3D point, double number)
        {
            return new Point3D(point.X * number, point.Y * number, point.Z * number);
        }
        public static Point3D operator *(double number, Point3D point)
        {
            return new Point3D(point.X * number, point.Y * number, point.Z * number);
        }
        public static bool operator ==(Point3D point1, Point3D point2)
        {
            return point1.Equals(point2);
        }
        public static bool operator !=(Point3D point1, Point3D point2)
        {
            return !point1.Equals(point2);
        }
        public static explicit operator double(Point3D point)
        {
            return Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2) + Math.Pow(point.Z, 2));
        }
    }
}