using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System;

namespace Snake.Entities 
{
    class DeathScreen
    {
        private Texture2D texture;

        private Vector2 position = Vector2.Zero;

        public DeathScreen(Texture2D Texture)
        {
            texture = Texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
