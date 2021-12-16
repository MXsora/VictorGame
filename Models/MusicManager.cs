using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace VictorGame.Models
{
    public class MusicManager
    {
        private static MusicManager instance;
        private Song song;
        private float maxVolume;

        public ContentManager content { private set; get; }

        public static MusicManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MusicManager();
                }
                return instance;
            }
        }

        public MusicManager()
        {
            MediaPlayer.IsMuted = false;
            MediaPlayer.IsRepeating = true;
        }

        public void PlaySong(string path)
        {
            song = content.Load<Song>(path);
            MediaPlayer.Play(song);
        }

        public void Fade(GameTime gameTime)
        {
            if(MediaPlayer.Volume > 0f)
            {
                MediaPlayer.Volume -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void LoadContent(ContentManager Content)
        {
            this.content = new ContentManager(Content.ServiceProvider, "Content");
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
