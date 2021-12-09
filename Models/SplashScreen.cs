using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace VictorGame.Models
{
    public class SplashScreen : GameScreen
    {
        public Image image = new Image();

        public SplashScreen()
        {
            image.Path = "Images/SplashScreen";
            image.Effects = "FadeEffect";
            //needs to change depending on resolution
            image.Position = new Vector2(960,540);
            image.Scale = new Vector2(2, 2);
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

            if (InputManager.Instance.KeyPressed(Keys.Enter, Keys.Space))
            {
                ScreenManager.Instance.ChangeScreen("TitleScreen");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            image.Draw(spriteBatch);
        }
    }
}
