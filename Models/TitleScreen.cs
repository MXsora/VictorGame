using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VictorGame.Models
{
    public class TitleScreen : GameScreen
    {
        MenuManager menuManager;
        MenuItem newGame = new MenuItem();
        MenuItem options = new MenuItem();
        readonly Image bg;

        public TitleScreen()
        {
            menuManager = new MenuManager();
            newGame.image.Text = "New Game";
            options.image.Text = "Options";
            menuManager.menu.items.Add(newGame);
            menuManager.menu.items.Add(options);
            bg = new Image("Images/TitleScreen");
            //this needs to change based on resolution
            bg.Position = new Vector2(960, 540);
            bg.Scale = new Vector2(2, 2);
        }

        public override void LoadContent()
        {
            base.LoadContent();
            menuManager.LoadContent();
            bg.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            menuManager.UnloadContent();
            bg.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            menuManager.Update(gameTime);
            bg.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            menuManager.Draw(spriteBatch);
            bg.Draw(spriteBatch);
        }
    }
}
