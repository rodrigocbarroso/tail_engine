﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using tail_engine.Helpers;

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
            Helpers.WindowManager.ToggleFullScreen(_graphics);

            ballposition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ballTexture = _content.Load<Texture2D>("ball");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Helpers.InputWrapper.Buttons.Back == ButtonState.Pressed) Exit();
            /* if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit(); */
            if (Helpers.InputWrapper.Buttons.A == ButtonState.Pressed) Helpers.WindowManager.ToggleFullScreen(_graphics);
            ballposition += Helpers.InputWrapper.Sticks.LeftStick;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(ballTexture, ballposition , Color.White);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
