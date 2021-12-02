using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace VictorGame.Models
{
    public class SplashScreen : GameScreen
    {
        public Image image = new Image();

        public SplashScreen(string path)
        {
            image.Path = path;
        }
        public override void LoadContent()
        {
            base.LoadContent();
            image.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            image.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            image.Draw(spriteBatch);
        }
    }
}
