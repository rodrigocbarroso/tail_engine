
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tail_engine.Helpers
{
    public class Sprite
    {

        protected Vector2 size;
        protected Vector2 position;
        protected Texture2D texture;
        
        public Sprite(string arg_texture, Vector2 arg_size, Vector2 arg_position)
        {
            texture = Game1._content.Load<Texture2D>(arg_texture);
<<<<<<< HEAD
            position = arg_position;
            size = arg_size;
        }

        public void Update(Vector2 deltaTranslate, Vector2 deltaScale)
        {
            position += deltaTranslate;
            size += deltaScale;
        }


=======
            size = arg_size;
            position = arg_position;
            
        }

        public void Update(Vector2 deltaPosition, Vector2  deltaSize)
        {
            position += deltaPosition;
            size += deltaSize;

        }

        public void Draw()
        {
            Rectangle destRect = new Rectangle((int)position.X,(int)position.Y,(int)size.X,(int)size.Y);
            Game1._spriteBatch.Draw(texture, position, null, Color.White);
        }
>>>>>>> ee478f2dda1afe2103763f3e6fe5f1aba668e327
        
    }
}
