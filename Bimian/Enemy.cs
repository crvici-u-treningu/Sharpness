using Sharpness;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bimian
{
    public class Enemy : Ship
    {
       
        int screeny;
        int screenx;
        float t;
        int pocx;
        public override void Config(ref Config config)
        {
            y = -500 + Randomize.Between(-100, 100);
            screeny = (int)config.DisplaySize.Y;
            screenx = (int)config.DisplaySize.X;
            pocx = Randomize.Between(30, screenx - 30);
            t = Randomize.Between(-10,10);
            name = "enemy2";
            
        }

       

        public override void Update(Input input)
        {
            base.Update(input);
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
