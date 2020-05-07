using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpness
{
    public enum Keys
    {

        Left = System.Windows.Forms.Keys.Left,
        Right = System.Windows.Forms.Keys.Right,
        Up = System.Windows.Forms.Keys.Up,
        Down = System.Windows.Forms.Keys.Down,

        A = System.Windows.Forms.Keys.A,
        B = System.Windows.Forms.Keys.B,
        C = System.Windows.Forms.Keys.C,
        D = System.Windows.Forms.Keys.D,
        E = System.Windows.Forms.Keys.E,
        F = System.Windows.Forms.Keys.F,
        G = System.Windows.Forms.Keys.G,
        H = System.Windows.Forms.Keys.H,
        I = System.Windows.Forms.Keys.I,
        J = System.Windows.Forms.Keys.J,
        K = System.Windows.Forms.Keys.K,
        L = System.Windows.Forms.Keys.L,
        M = System.Windows.Forms.Keys.M,
        N = System.Windows.Forms.Keys.N,
        O = System.Windows.Forms.Keys.O,
        P = System.Windows.Forms.Keys.P,
        Q = System.Windows.Forms.Keys.Q,
        R = System.Windows.Forms.Keys.R,
        S = System.Windows.Forms.Keys.S,
        T = System.Windows.Forms.Keys.T,
        U = System.Windows.Forms.Keys.U,
        V = System.Windows.Forms.Keys.V,
        W = System.Windows.Forms.Keys.W,
        X = System.Windows.Forms.Keys.X,
        Y = System.Windows.Forms.Keys.Y,
        Z = System.Windows.Forms.Keys.Z,

        D0 = System.Windows.Forms.Keys.D0,
        D1 = System.Windows.Forms.Keys.D1,
        D2 = System.Windows.Forms.Keys.D2,
        D3 = System.Windows.Forms.Keys.D3,
        D4 = System.Windows.Forms.Keys.D4,
        D5 = System.Windows.Forms.Keys.D5,
        D6 = System.Windows.Forms.Keys.D6,
        D7 = System.Windows.Forms.Keys.D7,
        D8 = System.Windows.Forms.Keys.D8,
        D9 = System.Windows.Forms.Keys.D9,

        Space = System.Windows.Forms.Keys.Space,
        Escape = System.Windows.Forms.Keys.Escape,
        Enter = System.Windows.Forms.Keys.Enter,
        Return = System.Windows.Forms.Keys.Return,
        Tab = System.Windows.Forms.Keys.Tab,
    }

    public enum Color
    {
        White, Black, Red,
        Green, Blue, Cyan,
        Magenta, Yellow,
        Purple, Pink
    }

    public class Config
    {
        public string WindowTitle { get; set; } = "Game";
        public Vec2 DisplaySize { get; set; } = new Vec2(640, 480);
    }

    public class Input
    {
        internal readonly Dictionary<System.Windows.Forms.Keys, int> Keystate = new Dictionary<System.Windows.Forms.Keys, int>();

        public Input()
        {
            foreach (var key in Enum.GetValues(typeof(System.Windows.Forms.Keys)))
            {
                this.Keystate[(System.Windows.Forms.Keys)key] = -1;
            }
        }

        public int Get(Keys key)
        {
            return Keystate[(System.Windows.Forms.Keys)key];
        }

        public bool IsKeyReleased(Keys key)
        {
            return this.Keystate[(System.Windows.Forms.Keys)key] == 0;
        }

        public bool IsKeyPressed(Keys key)
        {
            return this.Keystate[(System.Windows.Forms.Keys)key] == 1;
        }

        public bool IsKeyDown(Keys key)
        {
            return Keystate[(System.Windows.Forms.Keys)key] > 0;
        }

        public bool IsKeyUp(Keys key)
        {
            return Keystate[(System.Windows.Forms.Keys)key] < 1;
        }

        public void Update()
        {
            foreach (var key in Enum.GetValues(typeof(System.Windows.Forms.Keys)))
            {
                switch (Keystate[(System.Windows.Forms.Keys)key])
                {
                    case 1:
                        Keystate[(System.Windows.Forms.Keys)key] = 2;
                        break;
                    case 0:
                        Keystate[(System.Windows.Forms.Keys)key] = -1;
                        break;
                }
            }
        }
    }

    public class Canvas
    {
        private int fps;
        private Graphics graphics;
        public Vec2 DisplaySize { get; set; }
        private PrivateFontCollection fonts = new PrivateFontCollection();
        private readonly Dictionary<Color, SolidBrush> Brushes = new Dictionary<Color, SolidBrush>();
        private readonly Font font = new Font("Consolas", 16, FontStyle.Regular, GraphicsUnit.Pixel);
        private Stack<Color> currentColor = new Stack<Color>();
        private Brush currentBrush = null;

        public Canvas()
        {
            fonts.AddFontFile("REDENSEK.TTF");
            font = new Font(fonts.Families[0], 20, FontStyle.Regular);
            this.Brushes[Color.White] = new SolidBrush(System.Drawing.Color.White);
            this.Brushes[Color.Black] = new SolidBrush(System.Drawing.Color.Black);
            this.Brushes[Color.Red] = new SolidBrush(System.Drawing.Color.Red);
            this.Brushes[Color.Blue] = new SolidBrush(System.Drawing.Color.Blue);
            this.Brushes[Color.Green] = new SolidBrush(System.Drawing.Color.Green);
            this.Brushes[Color.Cyan] = new SolidBrush(System.Drawing.Color.Cyan);
            this.Brushes[Color.Magenta] = new SolidBrush(System.Drawing.Color.Magenta);
            this.Brushes[Color.Purple] = new SolidBrush(System.Drawing.Color.Purple);
            this.Brushes[Color.Pink] = new SolidBrush(System.Drawing.Color.Pink);
        }

        public void Invalidate(Graphics graphics, int fps)
        {
            this.fps = fps;
            this.graphics = graphics;
        }

        public void SetColor(Color c)
        {
            currentColor.Clear();
            currentColor.Push(c);
            currentBrush = Brushes[c];
        }

        public void PushColor(Color c)
        {
            currentColor.Push(c);
            currentBrush = Brushes[c];
        }

        public void PopColor()
        {
            currentColor.Pop();
            currentBrush = Brushes[currentColor.Peek()];
        }

        public void DrawRectangle(Color color, Rect r)
        {
            Vec2 half = r.Size / 2;
            this.graphics.FillRectangle(Brushes[color], 
                (float)(r.Position.X - half.X), 
                (float)(r.Position.Y - half.Y), 
                (float)r.Size.X, (float)r.Size.Y);
        }

        public void DrawRectangle(Color color, int x, int y, int width, int height)
        {
            this.graphics.FillRectangle(Brushes[color], x, y, width, height);
        }

        public void DrawPixel(int x, int y)
        {
            this.graphics.FillRectangle(currentBrush, x, y, 1, 1);
        }

        public void DrawCircle(Color color, int x, int y, int radius)
        {
            this.graphics.FillEllipse(Brushes[color], 
                x - radius, y - radius, 
                radius * 2, radius * 2);
        }

        public void DrawCircle(Color color, Circle circle)
        {
            this.graphics.FillEllipse(Brushes[color], 
                (float)(circle.Position.X - circle.Radius), 
                (float)(circle.Position.Y - circle.Radius), 
                (float)circle.Radius * 2, (float)circle.Radius * 2);
        }

        public void DrawCircle(Color color, double x, double y, double radius)
        {
            var doubleRadius = (int)radius * 2;
            this.graphics.FillEllipse(Brushes[color], (int)(x - radius), (int)(y - radius), doubleRadius, doubleRadius);
        }

        public void DrawString(Color color, int x, int y, string text)
        {
            this.graphics.DrawString(text, font, Brushes[color], x, y);
        }

        public void DrawFPS(Color color)
        {
            this.graphics.DrawString($"FPS: {fps}", font, Brushes[color], (float)DisplaySize.X - 110, (float)DisplaySize.Y - 70);
        }

        public void Fill(Color color)
        {
            this.graphics.FillRectangle(Brushes[color], 0, 0, (float)DisplaySize.X, (float)DisplaySize.Y);
        }
    }

    public partial class SharpnessWindow : Form
    {
        private readonly System.Timers.Timer frameTimer;
        private readonly System.Timers.Timer secondTimer;
        private int framesPerSecond, lastFPS;

        private readonly Game gameImpl;
        private readonly Canvas canvas = new Canvas();
        private readonly Input input = new Input();
        private readonly Config config = new Config();

        public SharpnessWindow()
        { 
            InitializeComponent();

            this.gameImpl = GameFinder.GetImplementation();
            if (this.gameImpl != null)
            {
                this.gameImpl.Config(ref this.config);

                this.Text = this.config.WindowTitle;
                this.framesPerSecond = 0;

                this.SetStyle(
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint |
                    ControlStyles.DoubleBuffer |
                    ControlStyles.OptimizedDoubleBuffer, true);

                this.FormBorderStyle = FormBorderStyle.None;
                this.Width = (int)this.config.DisplaySize.X;
                this.Height = (int)this.config.DisplaySize.Y;
                
                this.canvas.DisplaySize = new Vec2(this.Width, this.Height);

                this.Paint += SharpnessWindow_Paint;

                this.KeyDown += SharpnessWindow_KeyDown;
                this.KeyUp += SharpnessWindow_KeyUp;

                this.frameTimer = new System.Timers.Timer(16);
                this.frameTimer.Elapsed += FrameTimer_Elapsed;
                this.frameTimer.AutoReset = true;
                this.frameTimer.Start();

                this.secondTimer = new System.Timers.Timer(1000.0);
                this.secondTimer.Elapsed += SecondTimer_Elapsed;
                this.secondTimer.AutoReset = true;
                this.secondTimer.Start();
            }
        }

        private void SharpnessWindow_KeyUp(object sender, KeyEventArgs e)
        {
            var k = this.input.Keystate[e.KeyCode];
            if (k > 0)
                this.input.Keystate[e.KeyCode] = 0;
            else if (k == 0)
                this.input.Keystate[e.KeyCode] = -1;
        }

        private void SharpnessWindow_KeyDown(object sender, KeyEventArgs e)
        {
            var k = this.input.Keystate[e.KeyCode];
            if (k < 1)
                this.input.Keystate[e.KeyCode] = 1;
            else if (k == 1)
                this.input.Keystate[e.KeyCode] = 2;
        }

        private void SharpnessWindow_Paint(object sender, PaintEventArgs e)
        {
            canvas.Invalidate(e.Graphics, lastFPS);
            this.gameImpl.Update(input);
            input.Update();
            this.gameImpl.Draw(canvas);
        }

        private void FrameTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invalidate();
            this.framesPerSecond++;
        }

        private void SecondTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lastFPS = framesPerSecond;
            framesPerSecond = 0;
        }
    }
}
