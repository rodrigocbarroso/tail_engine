
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tail_engine.Helpers
{
    class Sprite
    {

        protected Vector2 size;
        protected Vector2 position;
        protected Texture2D texture;
        
        public Sprite(string arg_texture, Vector2 arg_size, Vector2 arg_position)
        {
            texture = Game1._content.Load<Texture2D>(arg_texture);
            position = arg_position;
            size = arg_size;
        }

        public void Update(Vector2 deltaTranslate, Vector2 deltaScale)
        {
            position += deltaTranslate;
            size += deltaScale;
        }


        
    }
}
