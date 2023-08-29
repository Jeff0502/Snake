using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Snake.Entities
{
    interface IGameEntity
    {
        void Draw(SpriteBatch spriteBatch);

        void Update(GameTime gameTime);
    }
}
