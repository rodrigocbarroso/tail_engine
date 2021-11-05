using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace tail_engine.Helpers
{
    static public class Camera
    {
        static private Vector2 origin = Vector2.Zero; //World Origin
        static private float worldWidth = 100f; //world width
        static private float cameraPixelRatio = -1f; //ratio between camera and pixel space
        static private float worldHeight = -1f; //i don't get this



        static private float cameraWindowToPixelRatio()
        {
            if (cameraPixelRatio < 0f)
            {
                cameraPixelRatio = (float)Game1._graphics.PreferredBackBufferWidth / worldWidth;
            }
            return cameraPixelRatio;
        }

        static public void SetCameraWindow(Vector2 arg_origin, float arg_width)
        {
            origin = arg_origin;
            worldWidth = arg_width;
        }

        static public void ComputePixelPosition(Vector2 cameraPosition, out int x, out int y)
        {
            float ratio = cameraWindowToPixelRatio();

            //convert camera postion to pixel space
            int v = (int)(((cameraPosition.X - origin.X) * ratio) + 0.5f);
            x = v;
            int z = (int)(((cameraPosition.Y - origin.Y) * ratio) + 0.5f);
            y = z;

            y = Game1._graphics.PreferredBackBufferHeight - y; //flip?
        }

        static public Rectangle ComputePixelRectangle(Vector2 position,Vector2 size)
        {
            float ratio = cameraWindowToPixelRatio();

            // Convert size from camera window space to pixel space.
            int width = (int)((size.X * ratio) + 0.5f);
            int height = (int)((size.Y * ratio) + 0.5f);
            // Convert the position to pixel space
            int x, y;
            ComputePixelPosition(position, out x, out y);
            // Reference position is the center
            y -= height / 2;
            x -= width / 2;

            return new Rectangle(x, y, width, height);
        }

        static public Vector2 CameraWindowLowerLeftPosition { get { return origin; } }
        static public Vector2 CameraWindowUpperRightPosition { get { return origin + new Vector2(worldWidth, (worldWidth * cameraWindowToPixelRatio())); } }
    }
}
