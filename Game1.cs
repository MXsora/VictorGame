using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using VictorGame.Models;

namespace VictorGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //private List<Sprite> _sprites;

        public Vector2 Position;
        public Texture2D _texture;

        public static int screenWidth;
        public static int screenHeight;

        Texture2D playerTexture;
        Rectangle playerBox;

        int posX;
        int posY;

        KeyboardState prevKeyBrdState;
        KeyboardState curKeyBrdState;

        public void makePlayer()
        {
            playerBox = new Rectangle(posX, posY, 16, 16);
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;

            posX = screenWidth / 2;
            posY = screenHeight / 2;

        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            _graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ScreenManager.Instance.GraphicsDevice = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = _spriteBatch;
            ScreenManager.Instance.LoadContent(Content);
            playerTexture = Content.Load<Texture2D>("BasicSquare");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ScreenManager.Instance.Update(gameTime);

            /*curKeyBrdState = Keyboard.GetState();

            if (prevKeyBrdState.IsKeyUp(Keys.Up) && curKeyBrdState.IsKeyDown(Keys.Up))
            {
                posY -= 60;
            }

            if (prevKeyBrdState.IsKeyUp(Keys.Down) && curKeyBrdState.IsKeyDown(Keys.Down))
            {
                posY += 60;
            }

            if (prevKeyBrdState.IsKeyUp(Keys.Left) && curKeyBrdState.IsKeyDown(Keys.Left))
            {
                posX -= 60;
            }

            if (prevKeyBrdState.IsKeyUp(Keys.Right) && curKeyBrdState.IsKeyDown(Keys.Right))
            {
                posX += 60;
            }

            prevKeyBrdState = curKeyBrdState;

            makePlayer();*/

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            ScreenManager.Instance.Draw(_spriteBatch);
            //_spriteBatch.Draw(playerTexture, playerBox, Color.White);
            //foreach (var sprite in _sprites)
            //{
            //    sprite.Draw(_spriteBatch);
            //}
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
