using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VictorGame.Models
{
    public class Menu
    {
        public event EventHandler OnMenuChange;

        public string axis, effects;
        public List<MenuItem> items;
        int itemNumber;
        string id;

        public Menu()
        {
            id = effects = string.Empty;
            itemNumber = 0;
            axis = "Y";
            items = new List<MenuItem>();
        }

        public int getItemNumber()
        {
            return itemNumber;
        }

        public void Transition(float alpha)
        {
            foreach(MenuItem item in items)
            {
                item.image.IsActive = true;
                item.image.Alpha = alpha;
                if (alpha <= 0.0f)
                {
                    item.image.FadeEffect.increase = true;
                }
                else
                {
                    item.image.FadeEffect.increase = false;
                }
            }
        }

        void AlignMenuItems()
        {
            Vector2 dimensions = Vector2.Zero;
            foreach(MenuItem item in items)
            {
                dimensions += new Vector2(item.image.SourceRect.Width, item.image.SourceRect.Height);
            }
            dimensions = new Vector2((ScreenManager.Instance.Dimensions.X - dimensions.X) / 2, (ScreenManager.Instance.Dimensions.Y - dimensions.Y) / 2);
            foreach (MenuItem item in items)
            {
                if(axis == "X")
                {
                    item.image.Position = new Vector2(dimensions.X, (ScreenManager.Instance.Dimensions.Y - item.image.SourceRect.Height) / 2);
                }
                else if(axis == "Y")
                {
                    item.image.Position = new Vector2((ScreenManager.Instance.Dimensions.X - item.image.SourceRect.Width) / 2, dimensions.Y);
                }
                dimensions += new Vector2(item.image.SourceRect.Width, item.image.SourceRect.Height);
            }
        }

        public string ID
        {
            get { return id; }
            set
            {
                id = value;
                OnMenuChange(this, null);
            }
        }

        public void LoadContent()
        {
            string[] split = effects.Split(':');
            foreach(MenuItem item in items)
            {
                item.image.LoadContent();
                foreach(string s in split)
                {
                    item.image.ActivateEffect(s);
                }
            }
            AlignMenuItems();
        }

        public void UnloadContent()
        {
            foreach (MenuItem item in items)
            {
                item.image.UnloadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            if(axis == "X")
            {
                if (InputManager.Instance.KeyPressed(Keys.Right))
                {
                    itemNumber++;
                }
                else if (InputManager.Instance.KeyPressed(Keys.Left))
                {
                    itemNumber--;
                }
            }
            else if(axis == "Y")
            {
                if (InputManager.Instance.KeyPressed(Keys.Down))
                {
                    itemNumber++;
                }
                else if (InputManager.Instance.KeyPressed(Keys.Up))
                {
                    itemNumber--;
                }
            }
            if(itemNumber < 0)
            {
                itemNumber = 0;
            }
            else if(itemNumber > items.Count - 1)
            {
                itemNumber = items.Count - 1;
            }
            for (int i = 0; i < items.Count; i++)
            {
                if(i == itemNumber)
                {
                    items[i].image.IsActive = true;
                }
                else
                {
                    items[i].image.IsActive = false;
                }
                items[i].image.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(MenuItem item in items)
            {
                item.image.Draw(spriteBatch);
            }
        }
    }
}
