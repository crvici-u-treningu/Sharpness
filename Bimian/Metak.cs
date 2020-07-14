
using Sharpness;

namespace Bimian
{
    public class Metak : IGameObject
    {
        public int x, y;
        public int speed = 3;
        public string name;
        public Circle collision = new Circle(0, 0, 10);
        public Metak (int x, int y)
        {
            this.x = x;
            this.y = y;
            name = "bullet5";
        }

        public void Config(ref Config config) { }
        public virtual void Draw(Canvas canvas)
        {
            canvas.DrawSprite(name, x, y);
        }

        public virtual void Update(Input input)
        {
            y -= speed;
            collision.Position.X = x;
            collision.Position.Y = y;
        }
    }
}
