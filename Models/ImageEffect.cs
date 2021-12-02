using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace VictorGame.Models
{
    public class ImageEffect
    {
        protected Image image;
        protected float Alpha;
        public bool IsActive;

        public ImageEffect()
        {
            Alpha = 0f;
            IsActive = false;
        }

        public virtual void LoadContent(ref Image Image)
        {
            this.image = Image;
            this.Alpha = Image.Alpha;
            this.IsActive = Image.IsActive;
        }

        public virtual void UnloadContent()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
