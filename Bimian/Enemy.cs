using Sharpness;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bimian
{
    public class Enemy : IGameObject
    {
        int x, y;
        int speed = 3;
        int screeny;
        int screenx;
        float t;
        int pocx;
        public void Config(ref Config config)
        {
            y = -500;
            screeny = (int)config.DisplaySize.Y;
            screenx = (int)config.DisplaySize.X;
            pocx = Randomize.Between(30, screenx - 30);
            t = 0;
            
        }

        public void Draw(Canvas canvas)
        {
            canvas.DrawSprite("enemy2", x, y);



        }

        public void Update(Input input)
        {
            y += speed;
            if (y > screeny + 30) 
            {
                y = -30;
                pocx = Randomize.Between(30, screenx-30);
            }
            t += 0.1f;
            x = (int)(pocx + 100*Math.Sin(t));
        }
    }
}
