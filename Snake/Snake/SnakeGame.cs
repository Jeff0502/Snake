using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Snake.Entities;

namespace Snake
{
    public class SnakeGame : Game
    {
        private int scaleX = 1, scaleY = 1;

        private int screenWidth = 800;

        private int screenHeight = 600;

        private RenderTarget2D renderTarget;

        private Rectangle screenRect;

        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        private readonly EntityManager entityManager;

        public SnakeGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            screenWidth *= scaleX;
            screenHeight *= scaleY;

            screenRect = new Rectangle(0, 0, screenWidth, screenHeight); 

            entityManager = new EntityManager(screenWidth, screenHeight);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            renderTarget = new RenderTarget2D(GraphicsDevice, screenWidth, screenHeight, false, GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);

            entityManager.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
           

            entityManager.Update(gameTime);
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.DarkCyan);

            _spriteBatch.Begin();
            entityManager.Draw(_spriteBatch);
            
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);

            base.Draw(gameTime);


        }
    }
}
