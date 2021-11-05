using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using tail_engine.Helpers;
using System.Collections.Generic;

namespace tail_engine
{
    public class Game1 : Game
    {
        static public ContentManager _content;
        static public GraphicsDeviceManager _graphics;
        static public SpriteBatch _spriteBatch;
        Texture2D ballTexture;
        Vector2 ballposition;

        //testing the sprite object
        int numSprites = 4;
        List<Sprite> listOfSprite;
        Sprite[] spriteObjects; //An array of Sprite objects
        int currentIndex = 0;

        //testing camera movement
        float camX = 0f;
        float camY = 0f;
        
      

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _content = Content;
            _content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Helpers.WindowManager.SetWindowSize(640, 480, _graphics);
            //Helpers.WindowManager.ToggleFullScreen(_graphics);

            ballposition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = _content.Load<Texture2D>("ball");


            //Define Camera Window Bounds
            Camera.SetCameraWindow(new Vector2(0f, 0f), 640f);



            //spriteObjects = new Sprite[numSprites];
            listOfSprite = new List<Sprite>();
            listOfSprite.Add(new Sprite("tile_0004", new Vector2(32, 32), new Vector2(0, 0)));
            listOfSprite.Add(new Sprite("tile_0005", new Vector2(32, 32), new Vector2(100, 100)));
            listOfSprite.Add(new Sprite("tile_0006", new Vector2(32, 32), new Vector2(200, 200)));
            listOfSprite.Add(new Sprite("tile_0007", new Vector2(32, 32), new Vector2(400, 400)));


        }

        protected override void Update(GameTime gameTime)
        {
            if (Helpers.InputWrapper.Buttons.Back == ButtonState.Pressed) Exit();
            /* if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit(); */
            if (Helpers.InputWrapper.Buttons.A == ButtonState.Pressed) Helpers.WindowManager.ToggleFullScreen(_graphics);

            //alternates sprite selection
            if (InputWrapper.Buttons.B == ButtonState.Pressed)
            {
                currentIndex = (currentIndex + 1) % listOfSprite.Count;
            }
            //moves and scales selected sprite
            listOfSprite[currentIndex].Update(InputWrapper.Sticks.LeftStick,InputWrapper.Sticks.RightStick);

        


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.NonPremultiplied,SamplerState.PointClamp);
            
            _spriteBatch.Draw(ballTexture, 
                                Camera.ComputePixelRectangle(ballposition,
                                                             new Vector2((float)ballTexture.Width,
                                                             (float)ballTexture.Height)),
                                Color.White);

           

            // TODO: Add your drawing code here
            foreach (Sprite x in listOfSprite)
            {
                x.Draw();
                
            }
            FontSupport.PrintStatus(Camera.CameraWindowLowerLeftPosition.ToString() + Camera.CameraWindowUpperRightPosition.ToString());
            FontSupport.PrintStatus(listOfSprite[currentIndex].position.ToString(),
                                    Color.White,
                                    new Vector2(20f,20f)

                                    );

            _spriteBatch.End();

           
            base.Draw(gameTime);
        }
    }
}
