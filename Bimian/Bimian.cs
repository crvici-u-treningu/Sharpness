using Sharpness;
using System;
using System.Collections.Generic;

namespace Bimian
{
    public class Bimian : Game
    {
        
        private void LoadImages()
        {
            Library.LoadAnimation("explosion", "Images/Explosion.png", 11);

            Library.LoadImage("ships", "Images/Player.png");
            Library.CutSprite("ship1", "ships", 50, 56, 19, 27);
            Library.CutSprite("ship2", "ships", 50, 84, 19, 28);
            Library.CutSprite("ship3", "ships", 49, 113, 22, 25);
            Library.CutSprite("ship4", "ships", 49, 140, 21, 27);
            Library.CutSprite("ship5", "ships", 51, 170, 18, 25);

            Library.LoadImage("bullets", "Images/Bullets1.png");
            Library.CutSprite("bullet1", "bullets", 4, 42, 4, 11);
            Library.CutSprite("bullet2", "bullets", 13, 42, 10, 11);
            Library.CutSprite("bullet3", "bullets", 24, 42, 11, 14);
            Library.CutSprite("bullet4", "bullets", 48, 42, 11, 14);
            Library.CutSprite("bullet5", "bullets", 73, 41, 10, 12);

            Library.LoadImage("enemies", "Images/Enemies.png");
            Library.CutSprite("enemy1", "enemies", 75, 59, 20, 19);
            Library.CutSprite("enemy2", "enemies", 98, 59, 21, 19);
            Library.CutSprite("enemy3", "enemies", 74, 35, 22, 15);
            Library.CutSprite("enemy4", "enemies", 97, 34, 23, 13);
            Library.CutSprite("enemy5", "enemies", 72, 1, 24, 25);
            Library.CutSprite("upgrade1", "enemies", 74, 115, 20, 21);

            Library.LoadImage("collect", "Images/Collect.png");
            Library.CutSprite("powerup", "collect", 77, 30, 13, 23);

            Library.LoadImage("stones", "Images/Stones.png");
            Library.CutSprite("rock1", "stones", 2, 4, 42, 46);
            Library.CutSprite("rock2", "stones", 50, 1, 22, 20);
            Library.CutSprite("rock3", "stones", 48, 29, 21, 23);
            Library.CutSprite("rock4", "stones", 121, 4, 71, 76);
        }

        
        private void DrawGalleryView(Canvas canvas)
        {
            canvas.DrawSprite("enemy1", 100, 50);
            canvas.DrawSprite("enemy2", 200, 50);
            canvas.DrawSprite("enemy3", 300, 50);
            canvas.DrawSprite("enemy4", 400, 50);
            canvas.DrawSprite("enemy5", 500, 50);

            canvas.DrawSprite("bullet1", 100, 150);
            canvas.DrawSprite("bullet2", 200, 150);
            canvas.DrawSprite("bullet3", 300, 150);
            canvas.DrawSprite("bullet4", 400, 150);
            canvas.DrawSprite("bullet5", 500, 150);

            canvas.DrawSprite("ship1", 100, 250);
            canvas.DrawSprite("ship2", 200, 250);
            canvas.DrawSprite("ship3", 300, 250);
            canvas.DrawSprite("ship4", 400, 250);
            canvas.DrawSprite("ship5", 500, 250);

            canvas.DrawSprite("powerup", 100, 400);
            canvas.DrawSprite("rock1", 200, 400);
            canvas.DrawSprite("rock2", 300, 400);
            canvas.DrawSprite("rock3", 400, 400);
            canvas.DrawSprite("rock4", 500, 400);
        }

        List<Ship> ships = new List<Ship>();
        Friend igrac = null;
        public override void Config(ref Config config)
        {
            LoadImages();
            ships.Add(igrac = new Friend());
            for(int i = 0; i<10; i++)
                ships.Add(new Enemy());
            foreach (var x in ships)
                x.Config(ref config);
        }

        public bool shouldExplode = false;

        public override void Draw(Canvas canvas)
        {
            canvas.Fill(Color.Black);
            // DrawGalleryView(canvas);
            // 
            foreach (var x in ships)
                x.Draw(canvas);
        }

        public override void Update(Input input)
        {
            if (input.IsKeyDown(Keys.Escape))
                this.Quit();

#if DEBUG
            if (input.IsKeyPressed(Keys.E))
                shouldExplode = true;
#endif

            foreach (var x in ships)
                x.Update(input);

            //proci kroz sve brodove
            //koji su neprijatej
            //ako se sudaraju sa igračem, igrač je mrtav
            foreach (var x in ships)
            {
                if (x is Enemy && x.Dead == false)
                {
                    if (Collision.Between(x.collision, igrac.collision)) igrac.Dead = true;
                    foreach (var m in igrac.meci)
                        if (Collision.Between(x.collision, m.collision)) x.Dead = true;
                }
            }
        }
    }
}
