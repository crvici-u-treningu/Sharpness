using System;
using System.Collections.Generic;
using System.Text;
using Sharpness;

namespace Pong
{
    class Pad : IGameObject
    {
        public Keys Upkey;
        public Keys Downkey;
        public Rect Rec;
        public int Score;
        public Pad (Keys up, Keys down, Vec2 xy)
        {
            this.Upkey = up;
            this.Downkey = down;
            this.Rec = new Rect((int)xy.X, (int)xy.Y, 10, 120);
            this.Score = 0;
        }
        public void Config(ref Config config)
        {
        }

        public void Draw(Canvas canvas)
        {
            canvas.DrawRectangle(Color.Green, this.Rec);

            canvas.DrawString(Color.White, 200, 100, $"{this.Score}");

        }

        public void Update(Input input)
        {
            if (input.IsKeyDown(this.Upkey))
            {
                this.Rec.Position.Y -= 10;
            }
            else if (input.IsKeyDown(this.Downkey))
            {
                this.Rec.Position.Y += 10;
            }
        }

    }
}
//TO DO: nema skora drugog igrača
//oba pada su iste boje