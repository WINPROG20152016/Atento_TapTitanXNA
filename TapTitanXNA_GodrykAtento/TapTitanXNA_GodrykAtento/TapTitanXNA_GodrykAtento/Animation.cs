using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TapTitanXNA_GodrykAtento
{
    public class Animation
    {
        public Texture2D texture;

        public bool isLooping;
        public float frameTime;
        

        public int FrameCount;
        private Texture2D texture2D;

        public int FrameWidth { get { return texture.Width / FrameCount; } }
        public int FrameHeight { get { return texture.Height; } }

        public Animation(Texture2D texture, float frameTime, bool isLooping, int FrameCount)
        {
            this.texture = texture;
            this.frameTime = frameTime;
            this.isLooping = isLooping;
            this.FrameCount = FrameCount;
        }

        public Animation(Texture2D texture2D)
        {
            // TODO: Complete member initialization
            this.texture2D = texture2D;
        }
    }
}
