using Sharpness;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bimian
{
    public class Enemy : IGameObject
    {
        int x, y;
        int speed = 6;
        public void Config(ref Config config)
        {
            x = (int)config.DisplaySize.X / 2;
            y = (int)config.DisplaySize.Y * 1 / 6;

        }

        public void Draw(Canvas canvas)
        {
            canvas.DrawSprite("enemy2", x, y);



        }

        public void Update(Input input)
        {
            
        }
    }
}
