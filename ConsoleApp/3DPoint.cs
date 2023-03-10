namespace ConsoleApp
{
    public struct Point3D
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

        public static Point3D operator +(Point3D point1, Point3D point2)
        {
            return new Point3D(point1.X + point2.X, point1.Y + point2.Y, point1.Z + point2.Z);
        }
        public static Point3D operator -(Point3D point)
        {
            return new Point3D(-point.X, -point.Y, -point.Z);
        }
        public static Point3D operator -(Point3D point1, Point3D point2)
        {
            return point1 + (-point2);
        }
        public static Point3D operator *(Point3D point, double n)
        {
            return new Point3D(n * point.X, n * point.Y, n * point.Z);
        }
        public static bool operator ==(Point3D point1, Point3D point2)
        {
            return (point1.X == point2.X) && (point1.Y == point2.Y) && (point1.Z == point2.Z);
        }
        public static bool operator !=(Point3D point1, Point3D point2)
        {
            return !(point1 == point2);
        }
        
        public static implicit operator double(Point3D point)
        {
            return Math.Sqrt(point.X * point.X + point.Y * point.Y + point.Z * point.Z);
        }
        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}";
        }
    }
}