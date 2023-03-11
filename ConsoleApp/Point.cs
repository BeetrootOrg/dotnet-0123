namespace Coordinate
{
    public struct Point3d 
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3d ( double x, double y, double z)
        {
            X=x;
            Y=y;
            Z=z;
        }            

        public override string ToString()
        {
            return $"Point with coordinates ({X}, {Y}, {Z}).";
        }
        
        public static Point3d operator+ (Point3d obj1, Point3d obj2)
        {
            return new Point3d(obj1.X+obj2.X, obj1.Y+obj2.Y, obj1.Z+obj2.Z);
        }

        public static Point3d operator-(Point3d obj1, Point3d obj2)
        {
            return new Point3d(obj1.X-obj2.X, obj1.Y-obj2.Y, obj1.Z-obj2.Z);
        }

        public static Point3d operator*(Point3d obj, double n)
        {
            return new Point3d(obj.X*n, obj.Y*n, obj.Z*n);
        }

        public static bool operator==(Point3d obj1, Point3d obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator!=(Point3d obj1, Point3d obj2)
        {
            return !obj1.Equals(obj2);
        }

        public int ToCastPoint()
        {
            return (int)Math.Sqrt(X*X+Y*Y+Z*Z);
        }
        public int ToCalculteDistance(Point3d obj1, Point3d obj2)
        {
            return (int)Math.Sqrt(Math.Pow(obj2.X-obj1.X, 2)+Math.Pow(obj2.Y-obj1.Y, 2)+Math.Pow(obj2.Z-obj1.Z, 2));
        }

    }
}