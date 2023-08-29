using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System;

namespace Snake.Entities
{
    class Snake
    {
        private Texture2D texture;

        public Vector2 position;

        public Playerstate STATE;

        private int SIZE;

        public int direction;

        public float rotation;

        public Vector2 origin;


        public Snake(Texture2D Texture)
        {
            texture = Texture;

            SIZE = texture.Width;
        }

        public Rectangle CollisionBox
        {
            get
            {
                Rectangle box = new Rectangle((int)position.X, (int)position.Y, SIZE, SIZE);
                return box;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, SIZE, SIZE), null, Color.White, MathHelper.ToRadians(rotation), origin, SpriteEffects.None, 0);
        }
    }
}
