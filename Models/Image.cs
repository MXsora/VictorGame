﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace VictorGame.Models
{
    public class Image
    {
        public float Alpha;
        public string Text, FontName;
        public string Path;
        public bool IsActive;
        public Vector2 Position, Scale;
        public Rectangle SourceRect;
        public Texture2D Texture;
        Vector2 origin;
        ContentManager content;
        RenderTarget2D renderTarget;
        SpriteFont font;
        Dictionary<string, ImageEffect> effectList;
        public string Effects;

        public FadeEffect FadeEffect;

        public Image()
        {
            Path = Text = Effects = String.Empty;
            FontName = "Sprites/pixelmix";
            Position = Vector2.Zero;
            Scale = Vector2.One;
            Alpha = 1.0f;
            SourceRect = Rectangle.Empty;
            effectList = new Dictionary<string, ImageEffect>();
        }

        public Image(string path)
        {
            Path = path;
            Text = Effects = string.Empty;
            FontName = "Sprites/pixelmix";
            Position = Vector2.Zero;
            Scale = Vector2.One;
            Alpha = 1.0f;
            SourceRect = Rectangle.Empty;
            effectList = new Dictionary<string, ImageEffect>();
        }

        void SetEffect<T>(ref T effect)
        {
            if(effect == null)
            {
                effect = (T)Activator.CreateInstance(typeof(T));
            } else
            {
                (effect as ImageEffect).IsActive = true;
                var obj = this;
                (effect as ImageEffect).LoadContent(ref obj);
            }

            effectList.Add(effect.GetType().ToString().Replace("VictorGame.Models.", ""), (effect as ImageEffect));

        }

        public void ActivateEffect(string effect)
        {
            if(effectList.ContainsKey(effect))
            {
                effectList[effect].IsActive = true;
                var obj = this;
                effectList[effect].LoadContent(ref obj);
            }
        }

        public void DeactivateEffect(string effect)
        {
            if (effectList.ContainsKey(effect))
            {
                effectList[effect].IsActive = false;
                effectList[effect].UnloadContent();
            }
        }

        public void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.content.ServiceProvider, "Content");
            if (Path != String.Empty)
            {
                Texture = content.Load<Texture2D>(Path);
            }

            font = content.Load<SpriteFont>(FontName);
            Vector2 dimensions = Vector2.Zero;

            if (Texture != null)
            {
                dimensions.X += Texture.Width;
                dimensions.Y = Math.Max(Texture.Height, font.MeasureString(Text).Y);
            }
            else
            {
                dimensions.X += font.MeasureString(Text).X;
                dimensions.Y = font.MeasureString(Text).Y;
            }

            if (SourceRect == Rectangle.Empty)
            {
                SourceRect = new Rectangle(0, 0, (int)dimensions.X, (int)dimensions.Y);
            }

            renderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice, (int)dimensions.X, (int)dimensions.Y);
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(renderTarget);
            ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);
            ScreenManager.Instance.SpriteBatch.Begin();
            if (Texture != null)
            {
                ScreenManager.Instance.SpriteBatch.Draw(Texture, Vector2.Zero, Color.White);
            }
            ScreenManager.Instance.SpriteBatch.DrawString(font, Text, Vector2.Zero, Color.White);
            ScreenManager.Instance.SpriteBatch.End();

            Texture = renderTarget;

            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(null);

            SetEffect<FadeEffect>(ref FadeEffect);

            if(Effects != String.Empty)
            {
                string[] split = Effects.Split(':');
                foreach(string item in split)
                {
                    ActivateEffect(item);
                }
            }
        }

        public void UnloadContent()
        {
            content.Unload();
            foreach (var effect in effectList)
            {
                DeactivateEffect(effect.Key);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var effect in effectList)
            {
                if (effect.Value.IsActive)
                {
                    effect.Value.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            origin = new Vector2(SourceRect.Width / 2, SourceRect.Height / 2);
            spriteBatch.Draw(Texture, Position, SourceRect, Color.White * Alpha, 0.0f, origin, Scale, SpriteEffects.None, 0.0f);
        }
    }
}
