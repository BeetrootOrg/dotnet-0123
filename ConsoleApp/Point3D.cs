namespace Geometry
{
    public struct Point3D
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Point3D(double x) : this (x, 0, 0) {}
        public Point3D(double x, double y) : this (x, y, 0) {}
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

        public static Point3D operator *(double n, Point3D point)
        {
            return  new Point3D(point.X * n, point.Y * n, point.Z * n); 
        } 

        public static Point3D operator *(Point3D point, double n)
        {
            return  n * point; 
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
            double powX = Math.Pow(point.X, 2); 
            double powY = Math.Pow(point.Y, 2); 
            double powZ = Math.Pow(point.Z, 2); 
            
            return  Math.Pow(powX + powY + powZ, 0.5);
        }

        public override string ToString()
        {
            return $"X: {X}; Y: {Y}; Z: {Z}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Point3D point && point.X == X && point.Y == Y && point.Z == Z;
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    } 
}