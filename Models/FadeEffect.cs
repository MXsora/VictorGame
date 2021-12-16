using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace VictorGame.Models
{
    public class FadeEffect : ImageEffect
    {
        public float fadeSpeed;
        public bool increase;

        public FadeEffect()
        {
            fadeSpeed = 0.5f;
            increase = false;
        }

        public override void LoadContent(ref Image image)
        {
            base.LoadContent(ref image);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (image.IsActive)
            {
                if(!increase)
                {
                    image.Alpha -= fadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    image.Alpha += fadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if(image.Alpha < 0.0f)
                {
                    increase = true;
                    image.Alpha = 0.0f;
                }
                else if(image.Alpha > 1.0f)
                {
                    increase = false;
                    image.Alpha = 1.0f;
                }
            }
            else
            {
                image.Alpha = this.Alpha;
            }
        }
    }
}
