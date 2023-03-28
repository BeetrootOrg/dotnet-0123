namespace ConsoleApp;

using System;

public struct Point3D
{
    public double X;
    public double Y;
    public double Z;

    public Point3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Point3D operator +(Point3D a, Point3D b)
    {
        return new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Point3D operator -(Point3D a, Point3D b)
    {
        return new Point3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Point3D operator *(Point3D a, double n)
    {
        return new Point3D(a.X * n, a.Y * n, a.Z * n);
    }

    public static Point3D operator *(double n, Point3D a)
    {
        return a * n;
    }

    public static bool operator ==(Point3D a, Point3D b)
    {
        return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
    }

    public static bool operator !=(Point3D a, Point3D b)
    {
        return !(a == b);
    }

    public static implicit operator double(Point3D a)
    {
        return Math.Sqrt(a.X * a.X + a.Y * a.Y + a.Z * a.Z);
    }
}
