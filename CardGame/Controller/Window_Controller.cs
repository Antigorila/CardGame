using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CardGame.Controller
{
    class Window_Controller
    {
        private static int _screenWidth = 1000;
        private static int _screenHeight = 748;
        
        public static Vector2 ScreenSize => new Vector2(_screenWidth, _screenHeight);
        public static Vector2 Center => new Vector2(_screenWidth / 2, ScreenHeight / 2);

        public static int ScreenWidth
        {
            get { return _screenWidth;  }
            set { _screenWidth = value; }
        }

        public static int ScreenHeight
        {
            get { return _screenHeight; }
            set { _screenHeight = value; }
        }    
        
        public static void SetUpWindow()
        {
            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Card Game");
            Raylib.SetTargetFPS(60);
        }
    }
}
