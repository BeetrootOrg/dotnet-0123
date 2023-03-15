namespace ConsoleApp
{
    public readonly record struct Point3D
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point3D operator +(Point3D p1, Point3D p2)
        {
            return new Point3D(
                p1.X + p2.X,
                p1.Y + p2.Y,
                p1.Z + p2.Z
            );
        }

        public static Point3D operator -(Point3D p1, Point3D p2)
        {
            return new Point3D(
                p1.X - p2.X,
                p1.Y - p2.Y,
                p1.Z - p2.Z
            );
        }

        public static Point3D operator *(Point3D p, double n)
        {
            return new Point3D(
                p.X * n,
                p.Y * n,
                p.Z * n
            );
        }

        public static explicit operator double(Point3D p)
        {
            return Math.Sqrt((p.X * p.X) + (p.Y * p.Y) + (p.Z * p.Z));
        }
    }
}