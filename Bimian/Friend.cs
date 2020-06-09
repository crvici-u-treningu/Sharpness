using Sharpness;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bimian
{
    public class Friend : IGameObject
    {
        int x, y;
        int speed = 6;
        public void Config(ref Config config)
        {
            x = (int) config.DisplaySize.X / 2;
            y = (int)config.DisplaySize.Y * 5 / 6;

        }

        public void Draw(Canvas canvas)
        {
            canvas.DrawSprite("ship2", x, y);
#if DEBUG
            canvas.DrawString(Color.White, 50, 50, speed.ToString());
#endif

        }

        public void Update(Input input)
        {
            if (input.IsKeyDown(Keys.Left)) x -= speed;
            else if(input.IsKeyDown(Keys.Right)) x += speed;

            if (input.IsKeyDown(Keys.Up)) y -= speed;
            else if (input.IsKeyDown(Keys.Down)) y += speed;
#if DEBUG
            if (input.IsKeyPressed(Keys.A)) speed--;
            else if (input.IsKeyPressed(Keys.D)) speed++;


#endif
        }
    }
}
