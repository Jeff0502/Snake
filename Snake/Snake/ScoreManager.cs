using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System;

namespace Snake
{
    class ScoreManager
    {
        public int score = 0;

        private SpriteFont font;

        private string sScore;

        private Vector2 position = new Vector2(400, 0);

        public void LoadContent(ContentManager Content)
        {

            font = Content.Load<SpriteFont>("ArcadeClassic");

        }

        public void Update(GameTime gameTime)
        {
            sScore = score.ToString();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < sScore.Length; i++)
            {
                spriteBatch.DrawString(font, sScore, position, Color.White);
            }
        }

        public void AddScore(int Value)
        {
            score += Value;
        }

        public void Reset()
        {
            score = 0;
        }

    }
}
