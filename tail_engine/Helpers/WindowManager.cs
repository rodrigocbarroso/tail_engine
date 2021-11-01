using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace tail_engine.Helpers
{
   

    public static class WindowManager
    {  
        
        public static void  SetWindowSize(int width, int height, GraphicsDeviceManager _graphics)
        {
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();
            
            

        }

        public static void ToggleFullScreen(GraphicsDeviceManager _graphics)
        {
            _graphics.ToggleFullScreen();
            _graphics.ApplyChanges();
            
        }


    }
}
