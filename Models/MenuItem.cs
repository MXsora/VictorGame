using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VictorGame.Models
{
    public class MenuItem
    {
        public string linkType, linkID;
        public Image image;
               
        public MenuItem()
        {
            image = new Image();
        }

        public void LoadContent()
        {
            image.LoadContent();
        }

        public void UnloadContent()
        {
            image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            image.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            image.Draw(spriteBatch);
        }
    }
}
