using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System;

namespace Snake.Entities
{
    class SnakeManager : IGameEntity
    {
        private Texture2D texture;

        private int SCREEN_HEIGHT;

        private int SCREEN_WIDTH;

        public Playerstate STATE = Playerstate.IsAlive;

        private readonly int SIZE = 40;

        public Snake player;

        public List<Snake> snake = new List<Snake>();

        private SoundManager _soundManager;

        public SnakeManager(Texture2D Texture, Texture2D HeadTexture, SoundManager SoundManager, int ScreenWidth, int ScreenHeight)
        {
            CreateHead(HeadTexture);

            _soundManager = SoundManager;

            SCREEN_HEIGHT = ScreenHeight;

            SCREEN_WIDTH = ScreenWidth;

            texture = Texture;
        }

        public void Initialize()
        {
            CreateTail();
            CreateTail();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < snake.Count; i++)
            {
                snake[i].Draw(spriteBatch);
            }

        }

        public void Update(GameTime gameTime)
        {
            RotateHead();
            Move();
            CheckBoundaries();

            for (int i = snake.Count - 1; i > 3; i--)
            {
                if (player.CollisionBox.Contains(snake[i].CollisionBox))
                {
                    player.STATE = Playerstate.Dead;
                }
            }

        }
        #region ManageEntities
        public void CreateHead(Texture2D HeadTexture) 
        {
            player = new Snake(HeadTexture)
            {
                position = new Vector2(400, 320),

                direction = Direction.RIGHT
            };

            snake.Add(player);
        }

        public void CreateTail()
        {
            int count = snake.Count;
            Snake tail = new Snake(texture);

            switch (snake[count - 1].direction)
            {
                case Direction.DOWN:
                    tail.position = snake[count - 1].position - new Vector2(0, 40);
                    break;
                case Direction.UP:
                    tail.position = snake[count - 1].position + new Vector2(0, 40);
                    break;
                case Direction.LEFT:
                    tail.position = snake[count - 1].position - new Vector2(40, 0);
                    break;
                case Direction.RIGHT:
                    tail.position = snake[count - 1].position + new Vector2(40, 0);
                    break;

            }

            snake.Add(tail);
        }

        public void Clear()
        {
            snake.Clear();
        }
        #endregion

        #region PlayerMovement
        public void CheckInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.S) && player.direction != Direction.UP && !(Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.A)))
                player.direction = Direction.DOWN;
            if (Keyboard.GetState().IsKeyDown(Keys.W) && player.direction != Direction.DOWN && !(Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.A)))
                player.direction = Direction.UP;
            if (Keyboard.GetState().IsKeyDown(Keys.A) && player.direction != Direction.RIGHT)
                player.direction = Direction.LEFT;
            if (Keyboard.GetState().IsKeyDown(Keys.D) && player.direction != Direction.LEFT)
                player.direction = Direction.RIGHT;

        }

        public void Move()
        {
            for (int i = snake.Count - 1; i > 0; i--)
            {
                snake[i].position = snake[i - 1].position;
                snake[i].direction = snake[i - 1].direction;
            }

            switch (player.direction)
            {
                case Direction.DOWN:
                    player.position.Y += SIZE;
                    break;
                case Direction.UP:
                    player.position.Y -= SIZE;
                    break;
                case Direction.LEFT:
                    player.position.X -= SIZE;
                    break;
                case Direction.RIGHT:
                    player.position.X += SIZE;
                    break;

            }

            _soundManager.PlayMove(0.2f);

        }

        public void RotateHead()
        {
            switch (player.direction)
            {
                case Direction.LEFT:
                    player.rotation = -90;
                    player.origin = new Vector2(40, 0);
                    break;

                case Direction.RIGHT:
                    player.rotation = 90;
                    player.origin = new Vector2(0, 40);
                    break;

                case Direction.UP:
                    player.rotation = 0;
                    player.origin = new Vector2(0, 0);
                    break;

                case Direction.DOWN:
                    player.rotation = 180;
                    player.origin = new Vector2(40, 40);
                    break;
            }
        }

        public void CheckBoundaries()
        {
            if (player.position.Y < 0 || player.position.Y > 480 || player.position.X < 0 || player.position.X > 800)
            {
                player.STATE = Playerstate.Dead;
            }
        }
        #endregion

    }
}
