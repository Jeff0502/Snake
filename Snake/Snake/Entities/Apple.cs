using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace Snake.Entities
{
    class Apple : IGameEntity
    {
        private Texture2D texture;

        private Vector2 position;

        private Random random = new Random();

        public List<Apple> apples = new List<Apple>(1);

        private readonly int size = 40;

        public Apple(Texture2D Texture)
        {
            texture = Texture;
        }

        public Apple()
        { }

        public Rectangle CollisionBox
        {
            get
            {
                Rectangle box = new Rectangle((int)apples[0].position.X, (int)apples[0].position.Y, size, size);
                return box;
            }
        }

        public void Update(GameTime gameTime)
        { 

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Apple apple in apples)
            {
                spriteBatch.Draw(texture, apple.position, Color.White);
            }
           
        }

        public void RemoveApple()
        {
            apples.Remove(apples[0]);
        }

        public void GeneratePosition(List<Snake> snake)
        {
            Vector2 randomPos;
            Rectangle hitbox;

            randomPos.X = size * random.Next(1, 19);
            randomPos.Y = size * random.Next(1, 9);

            hitbox = new Rectangle((int)randomPos.X, (int)randomPos.Y, 40, 40);

            foreach(Snake body in snake)
            {
                while(hitbox.Contains(body.CollisionBox))
                {
                    randomPos.X = size * random.Next(1, 19);
                    randomPos.Y = size * random.Next(1, 9);

                    hitbox = new Rectangle((int)randomPos.X, (int)randomPos.Y, 40, 40);
                }
            }

            GenerateApple(randomPos);
        }

        public void GenerateApple(Vector2 position)
        {
            Apple apple = new Apple();

            apple.position = position;

            apples.Add(apple);
        }


        public void Clear()
        {
            apples.Clear();
        }
    }
}
