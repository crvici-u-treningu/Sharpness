﻿using Sharpness;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bimian
{
    public class Friend : Ship
    {
        

        public override void Config(ref Config config)
        {
            x = (int) config.DisplaySize.X / 2;
            y = (int)config.DisplaySize.Y * 5 / 6;
            speed = 6;
            name = "ship2";
            
        }

        public List<Metak> meci = new List<Metak>();

        public override void Update(Input input)
        {
            base.Update(input);
            if (input.IsKeyDown(Keys.Left)) x -= speed;
            else if(input.IsKeyDown(Keys.Right)) x += speed;

            if (input.IsKeyDown(Keys.Up)) y -= speed;
            else if (input.IsKeyDown(Keys.Down)) y += speed;
#if DEBUG
            if (input.IsKeyPressed(Keys.A)) speed--;
            else if (input.IsKeyPressed(Keys.D)) speed++;
#endif      
            if (input.IsKeyPressed(Keys.Space))
            {
                meci.Add(new Metak(x, y));
            }
            foreach (var x in meci)
                x.Update(input);
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            foreach (var x in meci)
                x.Draw(canvas);

        }
    }
}
