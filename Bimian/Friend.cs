using Sharpness;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bimian
{
    public class Friend : Ship
    {
        public bool Dead;
        public bool FreshlyDead;

        public override void Config(ref Config config)
        {
            x = (int) config.DisplaySize.X / 2;
            y = (int)config.DisplaySize.Y * 5 / 6;
            speed = 6;
            name = "ship2";
            Dead = false;
            FreshlyDead = false;
        }


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
        }

        public override void Draw(Canvas canvas)
        {
            if (!Dead) base.Draw(canvas);
            else
            {
                if (!FreshlyDead)
                {
                    FreshlyDead = true;
                    canvas.EmitAnimation("explosion", x, y, Randomize.Between(2, 5));
                }
            }
        }
    }
}
