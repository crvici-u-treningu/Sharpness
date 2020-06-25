using Sharpness;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bimian
{
    public abstract class Ship : IGameObject
    {
        public int x, y;
        public int speed = 3;
        public string name;
        public Circle collision = new Circle(0, 0, 10);

        public abstract void Config(ref Config config);

        public void Draw(Canvas canvas)
        {
            canvas.DrawSprite(name, x, y);
#if DEBUG
            canvas.DrawString(Color.White, 50, 50, speed.ToString());
            canvas.DrawCircle(Color.Red, collision);
#endif
        }

        public virtual void Update(Input input)
        {
            collision.Position.X = x;
            collision.Position.Y = y;
        }
    }
}
