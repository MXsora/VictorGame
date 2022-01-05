using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace VictorGame.Models
{
    public class MenuManager
    {
        public Menu menu;
        bool isTransitioning;
        
        public MenuManager()
        {
            menu = new Menu();
            menu.OnMenuChange += menu_OnMenuChange;
        }

        void Transition(GameTime gameTime)
        {
            if (isTransitioning)
            {
                float first = menu.items[0].image.Alpha;
                float last = menu.items[menu.items.Count - 1].image.Alpha;
                for (int i = 0; i < menu.items.Count; i++)
                {
                    menu.items[i].image.Update(gameTime);
                }
            }
        }

        void menu_OnMenuChange(object sender, EventArgs e)
        {
            menu.UnloadContent();
            //new menu
            //transition
            menu.LoadContent();
        }
        
        public void LoadContent()
        {
            menu.LoadContent();
        }

        public void UnloadContent()
        {
            menu.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            menu.Update(gameTime);
            if (InputManager.Instance.KeyPressed(Keys.Enter) && !isTransitioning)
            {
                if(menu.items[menu.getItemNumber()].linkType == "screen")
                {
                    ScreenManager.Instance.ChangeScreen(menu.items[menu.getItemNumber()].linkID);
                }
                else
                {
                    isTransitioning = true;
                    menu.Transition(1f);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }
    }
}
