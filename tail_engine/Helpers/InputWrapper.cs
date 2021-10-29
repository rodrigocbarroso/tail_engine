using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace tail_engine.Helpers
{

    internal struct AllInputButtons
    {
        private const Keys a_Btn = Keys.U;
        private const Keys b_Btn = Keys.I;
        private const Keys x_Btn = Keys.O;
        private const Keys y_Btn = Keys.P;
        private const Keys back_Btn = Keys.Escape;
        private const Keys start_Btn = Keys.Enter;
        private const Keys rb_Btn = Keys.K;
        private const Keys lb_Btn = Keys.J;
        private const Keys rt_Btn = Keys.H;
        private const Keys lt_Btn = Keys.G;


        /// <summary>
        ///  Return ButtonState (pressed or released) of buttons. 
        /// </summary>
        /// <param name="GamepadButton">Gamepad</param>
        /// <param name="key">Keyboard</param>
        /// <returns></returns>
        private ButtonState GetState(Buttons GamepadButton, Keys key)
        {
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(GamepadButton) || Keyboard.GetState().IsKeyDown(key))
            {
                return ButtonState.Pressed;
            }
            else
            {
                return ButtonState.Released;
            }
        }

        public ButtonState A { get { return GetState(Buttons.A, a_Btn); } }
        public ButtonState B { get { return GetState(Buttons.B, b_Btn); } }
        public ButtonState X { get { return GetState(Buttons.X, x_Btn); } }
        public ButtonState Y { get { return GetState(Buttons.Y, y_Btn); } }
        public ButtonState Back { get { return GetState(Buttons.Back, back_Btn); } }
        public ButtonState Start { get { return GetState(Buttons.Start, start_Btn); } }
        public ButtonState LB { get { return GetState(Buttons.LeftShoulder, lb_Btn); } }
        public ButtonState RB { get { return GetState(Buttons.RightShoulder, rb_Btn); } }

   
    }


    /// <summary>
    /// Returns 
    /// </summary>
    internal struct AllInputSticks
    {
        private const Keys upStickL = Keys.Up;
        private const Keys downStickL = Keys.Down;
        private const Keys leftStickL = Keys.Left;
        private const Keys rightStickL = Keys.Right;
        private const float _stickValue = 0.75f;
        

        private Vector2 GetStickState(Vector2 padstickvalue, Keys up, Keys down, Keys left, Keys right)
        {
            Vector2 result = new Vector2(0f, 0f);

            if(GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                result = padstickvalue;
            }

            if(Keyboard.GetState().IsKeyDown(up)) {
                result.Y -= _stickValue;
            }
            if(Keyboard.GetState().IsKeyDown(down))
            {
                result.Y += _stickValue;
            }
            if (Keyboard.GetState().IsKeyDown(left)) result.X -= _stickValue;
            if (Keyboard.GetState().IsKeyDown(right)) result.X += _stickValue;

            return result;
        }

        public Vector2 LeftStick { get { return GetStickState(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left, upStickL, downStickL, leftStickL, rightStickL); } }
        public Vector2 RightStick { get { return GetStickState(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right, upStickL, downStickL, leftStickL, rightStickL); } }

    }

    static class InputWrapper
    {
        
        static public AllInputButtons Buttons = new AllInputButtons();
        static public AllInputSticks Sticks = new AllInputSticks();

    }

}
