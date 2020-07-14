using Sharpness;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bimian
{
    public abstract class Ship : IGameObject
    {
        public bool Dead;
        public bool FreshlyDead;
        public int x, y;
        public int speed = 3;
        public string name;
        public Circle collision = new Circle(0, 0, 10);

        public virtual void Config(ref Config config)
        {
        Dead = false;
        FreshlyDead = false;
        }

        public virtual void Draw(Canvas canvas)
        {
            if (!Dead)
            {
                canvas.DrawSprite(name, x, y);
#if DEBUG
                canvas.DrawString(Color.White, 50, 50, speed.ToString());
                canvas.DrawCircle(Color.Red, collision);
#endif
            }
            if (!FreshlyDead)
            {
                FreshlyDead = true;
                canvas.EmitAnimation("explosion", x, y, Randomize.Between(2, 5));
            }
        }
            
        

        public virtual void Update(Input input)
        {
            collision.Position.X = x;
            collision.Position.Y = y;
        }
    }
}
