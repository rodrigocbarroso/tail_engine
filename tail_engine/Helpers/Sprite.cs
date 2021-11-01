
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tail_engine.Helpers
{
    class Sprite
    {

        protected int size;
        protected Vector2 position;
        protected Texture2D texture;
        
        public Sprite(string arg_texture, int arg_size, Vector2 arg_position)
        {
            texture = Game1._content.Load<Texture2D>(arg_texture);


        }
        
    }
}
