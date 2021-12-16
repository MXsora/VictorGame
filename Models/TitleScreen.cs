using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace VictorGame.Models
{
    public class TitleScreen : GameScreen
    {
        MenuManager menuManager;
        MenuItem newGame;
        MenuItem options;
        MenuItem exit;
        readonly Image bg;

        public TitleScreen()
        {
            menuManager = new MenuManager();
            newGame = new MenuItem();
            options = new MenuItem();
            exit = new MenuItem();
            newGame.image.Text = "New Game";
            options.image.Text = "Options";
            exit.image.Text = "Exit";
            options.image.Effects = newGame.image.Effects = exit.image.Effects = "FadeEffect";
            menuManager.menu.items.Add(newGame);
            menuManager.menu.items.Add(options);
            menuManager.menu.items.Add(exit);
            bg = new Image("Images/TitleScreen");
            //this needs to change based on resolution
            bg.Position = new Vector2(960, 540);
            bg.Scale = new Vector2(2, 2);
        }

        public override void LoadContent()
        {
            base.LoadContent();
            bg.LoadContent();
            menuManager.LoadContent();
            options.image.FadeEffect.fadeSpeed = newGame.image.FadeEffect.fadeSpeed = exit.image.FadeEffect.fadeSpeed = 2f;
            MusicManager.Instance.PlaySong("Music/TitleScreenMusic");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            bg.UnloadContent();
            menuManager.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            bg.Update(gameTime);
            menuManager.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            bg.Draw(spriteBatch);
            menuManager.Draw(spriteBatch);
        }
    }
}
