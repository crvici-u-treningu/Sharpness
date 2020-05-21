using System;
using System.Collections.Generic;
using System.Text;
using Sharpness;

namespace Pong
{
    class Ball : IGameObject
    {
        double ballX, ballY;
        double speedX, speedY;
        public void Config(ref Config config)
        {
            ballX = 320;
            ballY = 240;
            speedX = 5;
            speedY = 5;
        }

        public void Draw(Canvas canvas)
        {
            canvas.DrawCircle(Color.Magenta, ballX, ballY, 10);
        }

        public void Update(Input input)
        {
            if (input.IsKeyDown(Keys.Space))
            {
                ballX = 320;
                ballY = 240;
            }

            ballX += speedX;
            ballY += speedY;

            if ((ballY > 455) || (ballY <= 15))
                speedY = -speedY;
        }
    }
}


