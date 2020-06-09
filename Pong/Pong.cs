
using Sharpness;

namespace Pong
{


    

    
    class Pong : Game
    {
        
        bool drawingFPS = false;
        Ball b; 
        Pad player1, player2;


        public override void Config(ref Config config)
        {
            b = new Ball();
            b.Config(ref config);
            player1 = new Pad(Keys.W, Keys.S, new Vec2(40, 240));
            player2 = new Pad(Keys.Up, Keys.Down, new Vec2(600, 240));


        }

        //ekran 640x480
        public override void Draw(Canvas canvas)
        {
            canvas.Fill(Color.White);

            canvas.DrawRectangle(Color.Black, 10, 10, 620, 460);

            canvas.DrawRectangle(Color.White, 315, 0, 10, 480);

            b.Draw(canvas);

            player1.Draw(canvas);
            player2.Draw(canvas);


            if (drawingFPS)
                canvas.DrawFPS(Color.White);
        }

        public override void Update(Input input)
        {
            if (input.IsKeyDown(Keys.Escape)) Quit();
            if (input.IsKeyPressed(Keys.Tab)) drawingFPS = !drawingFPS;

            b.Update(input);

            //if ((ballX > 615) || (ballX <= 15))
            //{
            //    if (ballX > 615)
            //        player1.Score++;
            //    else player2.Score++;
            //    Canvas.Shake();
            //    ballX = 320;
            //    ballY = 240;
            //}

            //if ((ballX == 50) && (ballY > player1.Pad.Position.Y - 60 && ballY < player1.Pad.Position.Y + 60))
            //    speedX = -speedX;

            //if((ballX == 590) && (ballY > player2.Pad.Position.Y - 60 && ballY < player2.Pad.Position.Y + 60))
            //    speedX = -speedX;

            player1.Update(input);
            player2.Update(input);
        }

       
       
        
    }
}
