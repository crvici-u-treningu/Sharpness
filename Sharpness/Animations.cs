
using System.Collections.Generic;
using System.Xml.Schema;

namespace Sharpness
{
    // A definition of an animation. This class just keeps the information on what
    // frames constitute an animation, it doesn't PLAY the animation. To do that,
    // use the RunningAnimation class below.
    public class AnimationDefinition
    {
    public string AnimationName;
    public List<string> SpriteNames = new List<string>();

    public static Dictionary<string, AnimationDefinition> ByName = new Dictionary<string, AnimationDefinition>();

        /*
    
            Animations are a bit special, because we cut up an image by width:
            
            sprite width = 
     image width / number of sprites =
        (example: 600 / 6 = 100)
                  |
            0     |                        image width (example: 600)
            |     |                             |
            v     v                             v
            /-----------------------------------/
            |  1  |  2  |  3  |  4  |  5  |  6  |
            /-----------------------------------/
            0  ^ 100   200   300   400   500   600 pixels
               |
               |
           frame #n start on height 0, end on whatever the height of the image is,
           but go from n * 100 to (n + 1) * 100 horizontally

            example: if frame n = 4, then it goes from 400 to 500 pixels

        */

        public AnimationDefinition(string name, string filePath, int frameCount)
        {
            AnimationName = name;

            // we need a name that won't be used by non-animation sprites (like ship1, ship2 etc.)
            // so we add "_animation_frames" to the end (example: explosion_animation_frames)
            Library.LoadImage(name + "_animation_frames", filePath);

            var singleFrameWidth = Library.Images[name + "_animation_frames"].Width / frameCount;
            var singleFrameHeight = Library.Images[name + "_animation_frames"].Height;

            for(int i = 0; i < frameCount; i++)
            {
                // if our animation is called "explosion"...
                //        frame name: explosion_frame_1       
                //                  |
                //                  |            from image: explosion_animation_frames
                //                  |                               |
                //                  v                               v
                Library.CutSprite(name + "_frame_" + i, name + "_animation_frames", 
                    i * singleFrameWidth, 0, singleFrameWidth, singleFrameHeight);

                SpriteNames.Add(name + "_frame_" + i);
            }
        }
    }

    // An instance of an animation when it plays on the screen
    // This class takes care of moving the frames forward.
    public class RunningAnimation : IGameObject
    {
        AnimationDefinition animation;
        int x;
        int y;

        // the frame which we are drawing on the screen
        int currentFrame;
        // how many `Update` calls goes by before we advance the animation
        int currentTickInFrame;

        public int FrameLength;
        public bool IsPlaying;

        public RunningAnimation(string name, int x, int y, int length = 0)
        {
            this.animation = AnimationDefinition.ByName[name];
            this.x = x;
            this.y = y;
            this.currentFrame = 0;
            this.FrameLength = length;
            this.IsPlaying = true;
        }

        public void Config(ref Config config) {}

        public void Draw(Canvas canvas)
        {
            if (this.IsPlaying)
                canvas.DrawSprite(animation.SpriteNames[this.currentFrame], x, y);
        }

        public void Update(Input input)
        {
            if (this.IsPlaying)
            {
                currentTickInFrame++;
                if (currentTickInFrame >= FrameLength)
                {
                    currentTickInFrame = 0;
                    this.currentFrame++;

                    if (this.currentFrame >= this.animation.SpriteNames.Count)
                        this.IsPlaying = false;
                }
            }
        }
    }
}
