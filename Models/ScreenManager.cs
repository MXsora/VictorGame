using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace VictorGame.Models
{
    class ScreenManager
    {
        private static ScreenManager instance;
        public Vector2 Dimensions { private set; get; }
        public ContentManager content { private set; get; }

        GameScreen currentScreen;
        public GraphicsDevice GraphicsDevice;
        public SpriteBatch SpriteBatch;

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
        }

        public ScreenManager()
        {
            Dimensions = new Vector2(1280, 720);
            currentScreen = new SplashScreen("Images/DeveloperScreen");
        }

        public void LoadContent(ContentManager Content)
        {
            this.content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}
