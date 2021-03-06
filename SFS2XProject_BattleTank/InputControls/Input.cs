﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SFS2XProject_BattleTank.OffSets;

namespace SFS2XProject_BattleTank.InputControls
{
    public static class Input
    {
        private static KeyboardState _key;
        private static MouseState _mouse;

        private static MouseState _preMouse;
        private static KeyboardState _preKey;
        static Input()
        {
            _preMouse = new MouseState();
            _preKey = new KeyboardState();
            _key = Keyboard.GetState();
            _mouse = Mouse.GetState();
            Mouse.SetPosition(Constants.VIEWPORT_WIDTH / 2, Constants.VIEWPORT_HEIGHT / 2);
        }

        public static void Update()
        {
            _preKey = _key;
            _preMouse = _mouse;

            _key = Keyboard.GetState();
            _mouse = Mouse.GetState();
        }

        // mouse control
        public static Vector2 GetMousePosition()
        {
            return new Vector2(_mouse.Position.X, _mouse.Position.Y);
        }
        public static bool Pressing(byte button = 1)
        {
            if (button == Constants.MOUSEBUTTON_LEFT)
                if (_mouse.LeftButton == ButtonState.Pressed && _preMouse.LeftButton == ButtonState.Pressed)
                    return true;
            if (button == Constants.MOUSEBUTTON_RIGHT)
                if (_mouse.RightButton == ButtonState.Pressed && _preMouse.RightButton == ButtonState.Pressed)
                    return true;
            if (button == Constants.MOUSEBUTTON_MIDDLE)
                if (_mouse.MiddleButton == ButtonState.Pressed && _preMouse.MiddleButton == ButtonState.Pressed)
                    return true;
            return false;
        }

        internal static bool Clicked(object constant)
        {
            throw new NotImplementedException();
        }

        public static bool Clicked(byte button = 1)
        {
            if (button == Constants.MOUSEBUTTON_LEFT)
                if (_mouse.LeftButton == ButtonState.Pressed && _preMouse.LeftButton == ButtonState.Released)
                    return true;
            if (button == Constants.MOUSEBUTTON_RIGHT)
                if (_mouse.RightButton == ButtonState.Pressed && _preMouse.RightButton == ButtonState.Released)
                    return true;
            if (button == Constants.MOUSEBUTTON_MIDDLE)
                if (_mouse.MiddleButton == ButtonState.Pressed && _preMouse.MiddleButton == ButtonState.Released)
                    return true;
            return false;
        }
        public static int GetScrollValue()
        {
            return _mouse.ScrollWheelValue;
        }

        // keyboard control
        public static bool IsKeyPressing(Keys key)
        {
            return (_key.IsKeyDown(key) && _preKey.IsKeyDown(key));
        }
        public static bool IsKeyDown(Keys key)
        {
            return (_key.IsKeyDown(key) && !_preKey.IsKeyDown(key));
        }
        public static Keys[] GetKeyDowns()
        {
            return _key.GetPressedKeys();
        }
    }
}
