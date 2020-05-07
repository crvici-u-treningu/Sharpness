
using Sharpness;

namespace Pong
{
    class Pong : Game
    {
        double ballX, ballY;
        bool drawingFPS = false;
        double speedX, speedY;
        
        public override void Config(ref Config config)
        {
            ballX = 70;
            ballY = 100;
            speedX = 5;
            speedY = 5;
        }

        //ekran 640x480
        public override void Draw(Canvas canvas)
        {
            canvas.Fill(Color.Black);

            canvas.DrawRectangle(Color.White, 315, 0, 10, 480);

            canvas.DrawCircle(Color.Magenta, ballX, ballY, 10);

            if(drawingFPS)
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

            if ((ballY > 480) || (ballY <= 0))
                speedY = -speedY;

            if ((ballX > 640) || (ballX <= 0))
                speedX = -speedX;
        }
    }
}
