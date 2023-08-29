using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;

namespace Snake.Entities 
{
    class EntityManager : IGameEntity
    {
        public SnakeManager snake;

        private Vector2 screen;

        private ScoreManager scoreManager = new ScoreManager();

        private Apple apple;

        private DeathScreen  deathScreen;

        private readonly SoundManager soundManager = new SoundManager();

        private Texture2D playerTexture;

        private Texture2D deathScreenTexture;

        private Texture2D headTexture;

        private Texture2D appleTexture;

        private TimeSpan lastTimeMoved;

        private readonly List<IGameEntity> entities = new List<IGameEntity>();

        public EntityManager(int width, int height)
        {
            screen = new Vector2(width, height);
        }
        public void LoadContent(ContentManager Content)
        {

            LoadTextures(Content);

            scoreManager.LoadContent(Content);

            soundManager.LoadContent(Content);

            Initialize();
        }

        public void Initialize()
        {
            snake = new SnakeManager(playerTexture, headTexture, soundManager,(int)screen.X, (int)screen.Y);
            apple = new Apple(appleTexture);

            snake.Initialize();

            AddEntitiy(apple);
            AddEntitiy(snake);

        }

        public void Update(GameTime gameTime)
        {
            snake.CheckInput();

            if (EnoughTimeHasPassed(gameTime))
                FixedUpdate(gameTime);

           
           
        }

        public void FixedUpdate(GameTime gameTime)
        {
            if (snake.player.STATE == Playerstate.IsAlive)
            {
                lastTimeMoved = gameTime.TotalGameTime;

                foreach (IGameEntity entity in entities)
                {
                    entity.Update(gameTime);
                }

                

                if (snake.player.STATE == Playerstate.Dead)
                {
                    soundManager.PlayDead(0.2f);
                }

                
                   
                if (apple.apples.Count == 0)
                        apple.GeneratePosition(snake.snake);
                

                if (apple.CollisionBox.Intersects(snake.player.CollisionBox))
                {
                    snake.CreateTail();
                    apple.RemoveApple();
                    soundManager.PlayEat(0.2f);
                    scoreManager.AddScore(10);
                }

            }



            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    Respawn();
            }

        }

        public bool EnoughTimeHasPassed(GameTime gameTime)
        {
            scoreManager.Update(gameTime);

            if (gameTime.TotalGameTime - lastTimeMoved > new TimeSpan(0, 0, 0, 0, 200))
            {
                return true;
            }

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            foreach (IGameEntity entity in entities)
            {
                entity.Draw(spriteBatch);
            }

            scoreManager.Draw(spriteBatch);

            if (snake.player.STATE == Playerstate.Dead || snake.player.STATE == Playerstate.Idle)
            {
                Die(spriteBatch);
                snake.player.STATE = Playerstate.Idle;
            }
        }

        public void AddEntitiy(IGameEntity entity)
        {
            entities.Add(entity);
        }

        public void RemoveEntitiy(IGameEntity entity)
        {
            entities.Remove(entity);
        }

        public void Die(SpriteBatch spriteBatch)
        {
            deathScreen = new DeathScreen(deathScreenTexture);
            deathScreen.Draw(spriteBatch);
            apple.Clear();
            snake.Clear();
            entities.Clear();
            scoreManager.Reset();
        }

        public void Respawn()
        {
            Initialize();
        }

        public void LoadTextures(ContentManager Content)
        {
            appleTexture = Content.Load<Texture2D>("Apple");
            playerTexture = Content.Load<Texture2D>("Snake");
            headTexture = Content.Load<Texture2D>("Snakehead");
            deathScreenTexture = Content.Load<Texture2D>("Death Screen");
        }
    }
}
