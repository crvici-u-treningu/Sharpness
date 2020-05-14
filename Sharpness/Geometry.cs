using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness
{
    public struct Vec2
    {
        public Vec2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public static double Distance(Vec2 a, Vec2 b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static Vec2 operator +(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X + b.X, a.Y + b.Y);
        }

        public static Vec2 operator -(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X - b.X, a.Y - b.Y);
        }

        public static Vec2 operator *(Vec2 a, double d)
        {
            return new Vec2(a.X * d, a.Y * d);
        }

        public static Vec2 operator /(Vec2 a, double d)
        {
            return new Vec2(a.X / d, a.Y / d);
        }

        public double X;
        public double Y;

        public double Length() => Math.Sqrt(X * X + Y * Y);
        public Vec2 Normalized() => new Vec2(this.X / this.Length(), this.Y / this.Length());

        public double Angle
        {
            get 
            {
                return Math.Atan2(Y, X);
            }
        }
    }

    public enum Side { Up, Down, Left, Right }

    public static class Collision
    {
        public static bool Between(Circle a, Circle b)
        {
            return Vec2.Distance(a.Position, b.Position) < Math.Max(a.Radius, b.Radius);
        }

        public static bool Between(Circle c, Rect r)
        {
            double cx = c.Position.X;
            double cy = c.Position.Y;
            double radius = c.Radius;

            double rx = r.Position.X - r.Size.X / 2;
            double ry = r.Position.Y - r.Size.Y / 2;
            double rw = r.Size.X;
            double rh = r.Size.Y;

            double testX = cx;
            double testY = cy;

            if (cx < rx) testX = rx;      // left edge
            else if (cx > rx + rw) 
                testX = rx + rw;   // right edge
            if (cy < ry) 
                testY = ry;      // top edge
            else if (cy > ry + rh) 
                testY = ry + rh;   // bottom edge

            double distX = cx - testX;
            double distY = cy - testY;
            double distance = Math.Sqrt((distX * distX) + (distY * distY));

            return distance <= radius;
        }

        public static bool Between(Rect r, Circle c) => Between(c, r);

        public static bool Between(Rect a, Rect b)
        {
            return (Math.Abs(a.Position.X - b.Position.X) * 2 < (a.Size.X + b.Size.X)) &&
                    (Math.Abs(a.Position.Y - b.Position.Y) * 2 < (a.Size.Y + b.Size.Y));
        }
    }

    public class Rect
    {
        public Vec2 Position;
        public Vec2 Size;

        public Rect(int x, int y, int width, int height)
        {
            this.Position = new Vec2(x, y);
            this.Size = new Vec2(width, height);
        }
    }

    public class Circle
    {
        public Vec2 Position;
        public double Radius;

        public Circle(int x, int y, int rad)
        {
            this.Position = new Vec2(x, y);
            this.Radius = rad;
        }
    }
}
