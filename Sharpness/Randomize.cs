using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness
{
    public static class Randomize
    {
        private static readonly Random engine = new Random();

        public static int Between(int a, int b)
        {
            return a + engine.Next(b - a);
        }

        public static double Between(double a, double b)
        {
            return a + engine.NextDouble() * (b - a);
        }

        public static Vec2 Angle()
        {
            var angle = Between(0, 360);
            var rads = Math.PI * angle / 180.0;
            return new Vec2(Math.Sin(rads), Math.Cos(rads));
        }
    }
}
