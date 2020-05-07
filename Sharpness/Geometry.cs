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
