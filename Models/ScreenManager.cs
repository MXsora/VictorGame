using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using VictorGame.Models;

namespace VictorGame.Models
{
    class ScreenManager
    {
        private static ScreenManager instance;
        public Vector2 Dimensions { private set; get; }
        public ContentManager content { private set; get; }

        GameScreen currentScreen, newScreen;
        public GraphicsDevice GraphicsDevice;
        public SpriteBatch SpriteBatch;

        public Image image; 

        public bool IsTransitioning { private set; get; }

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
            Dimensions = new Vector2(1920, 1080);
            currentScreen = new SplashScreen();
            image = new Image("Images/FadeImage");
            image.Alpha = 0.0f;
            image.Effects = "FadeEffect";
            //needs to change depending on resolution
            //image.Position = new Vector2(960, 540);
            image.Scale = new Vector2(2000, 1100);
        }

        public void ChangeScreen(string screenName)
        {
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("VictorGame.Models." + screenName));
            image.FadeEffect.increase = true;
            image.Alpha = 0.01f;
            image.IsActive = true;
            image.FadeEffect.IsActive = true;
            IsTransitioning = true;
        }

        private void Transition(GameTime gameTime)
        {
            if (IsTransitioning)
            {
                image.Update(gameTime);
                if(image.Alpha >= 1.0f)
                {
                    currentScreen.UnloadContent();
                    currentScreen = newScreen;
                    currentScreen.LoadContent();
                }
                else if (image.Alpha <= 0.0f)
                {
                    image.IsActive = false;
                    IsTransitioning = false;
                }
            }
        }

        public void LoadContent(ContentManager Content)
        {
            this.content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent();
            image.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
            image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
            Transition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
            if (IsTransitioning)
            {
                image.Draw(spriteBatch);
            }
        }
    }
}
