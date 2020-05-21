
using Sharpness;

namespace Pong
{
    class Pong : Game
    {
        double ballX, ballY;
        bool drawingFPS = false;
        double speedX, speedY;
        Player player1, player2;

        public override void Config(ref Config config)
        {
            ballX = 70;
            ballY = 100;
            speedX = 5;
            speedY = 5;
            player1 = new Player();
            player2 = new Player();
            player1.Pad = new Rect(40, 240, 10, 120);
            player2.Pad = new Rect(600, 240, 10, 120);
            player1.Upkey = Keys.W;
            player2.Upkey = Keys.Up;
            player1.Downkey = Keys.S;
            player2.Downkey = Keys.Down;
            player1.Score = 0;
            player2.Score = 0;
        }

        //ekran 640x480
        public override void Draw(Canvas canvas)
        {
            canvas.Fill(Color.White);

            canvas.DrawRectangle(Color.Black, 10, 10, 620, 460);

            canvas.DrawRectangle(Color.White, 315, 0, 10, 480);

            canvas.DrawCircle(Color.Magenta, ballX, ballY, 10);

            canvas.DrawRectangle(Color.Green, player1.Pad);

            canvas.DrawRectangle(Color.Yellow, player2.Pad);

            canvas.DrawString(Color.White, 200, 100, $"{player1.Score}");

            canvas.DrawString(Color.White, 440, 100, $"{player2.Score}");


            if (drawingFPS)
                canvas.DrawFPS(Color.White);
        }

        public override void Update(Input input)
        {
            if (input.IsKeyDown(Keys.Escape)) Quit();
            if (input.IsKeyPressed(Keys.Tab)) drawingFPS = !drawingFPS;

            if (input.IsKeyDown(Keys.Space))
            {
                ballX = 320;
                ballY = 240;
            }

            ballX += speedX;
            ballY += speedY;

            if ((ballY > 455) || (ballY <= 15))
                speedY = -speedY;

            if ((ballX > 615) || (ballX <= 15))
            {
                if (ballX > 615)
                    player1.Score++;
                else player2.Score++;
                Canvas.Shake();
                ballX = 320;
                ballY = 240;
            }

            if ((ballX == 50) && (ballY > player1.Pad.Position.Y - 60 && ballY < player1.Pad.Position.Y + 60))
                speedX = -speedX;

            if((ballX == 590) && (ballY > player2.Pad.Position.Y - 60 && ballY < player2.Pad.Position.Y + 60))
                speedX = -speedX;

            CheckPlayerKeys(input, player1);
            CheckPlayerKeys(input, player2);
        }

        public class Player
        {
            public Keys Upkey;
            public Keys Downkey;
            public Rect Pad;
            public int Score;
        }
        void CheckPlayerKeys(Input input, Player p)
        {
            if (input.IsKeyDown(p.Upkey))
            {
                p.Pad.Position.Y -= 10;
            }
            else if (input.IsKeyDown(p.Downkey))
            {
                p.Pad.Position.Y += 10;
            }
        }
    }
}
