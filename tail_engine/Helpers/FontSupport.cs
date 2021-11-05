using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace tail_engine.Helpers
{
    class FontSupport
    {
        static private SpriteFont defaultFont = null;
        static private Color defaultDrawColor = Color.White;
        static private Vector2 debugLocation = new Vector2(5f, 5f);

        static private void LoadFont()
        {
            //loads Arial
            if (defaultFont == null)
            {
                defaultFont = Game1._content.Load<SpriteFont>("Arial");
            }
        }

        static private Color ColorToUse(Nullable<Color> color)
        {
            return (color == null) ? (defaultDrawColor) : (Color)color;
        }

        static public void PrintStatus(string msg, Nullable<Color> color)
        {
            LoadFont();
            Color selectedColor = ColorToUse(color);

            //
            Game1._spriteBatch.DrawString(defaultFont, msg, debugLocation, selectedColor);
        }

        static public void PrintStatus(string msg, Nullable<Color> color, Vector2 position)
        {
            LoadFont();
            Color selectedColor = ColorToUse(color);

            //
            Game1._spriteBatch.DrawString(defaultFont, msg, position, selectedColor);
        }

        static public void PrintStatus(string msg)
        {
            LoadFont();

            //
            Game1._spriteBatch.DrawString(defaultFont, msg, debugLocation, ColorToUse(null));
        }
        
    }
}
