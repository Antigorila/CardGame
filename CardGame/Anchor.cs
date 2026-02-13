using CardGame.Classes_UI;
using CardGame.Controller;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CardGame
{
    public enum OrientationAnchor
    {
        LeftTop,
        CenterTop,
        RightTop,
        LeftMiddle,
        CenterMiddle,
        RightMiddle,
        LeftBottom,
        CenterBottom,
        RightBottom
    }

    public enum ChainOrientation
    {
        Above,
        Right,
        Below,
        Left
    }

    public static class Anchor
    {
        public static void StickToSidePosition(this UIElement uIElement, OrientationAnchor outterAnchor, OrientationAnchor innerAnchor)
        {
            float x = 0;
            float y = 0;

            switch (outterAnchor)
            {
                case OrientationAnchor.CenterTop:
                    x = Window_Controller.ScreenWidth / 3f;
                    break;
                case OrientationAnchor.RightTop:
                    x = (Window_Controller.ScreenWidth / 3f) * 2;
                    break;
                case OrientationAnchor.LeftMiddle:
                    y = Window_Controller.ScreenHeight / 3f;
                    break;
                case OrientationAnchor.CenterMiddle:
                    x = Window_Controller.ScreenWidth / 3f;
                    y = Window_Controller.ScreenHeight / 3f;
                    break;
                case OrientationAnchor.RightMiddle:
                    x = (Window_Controller.ScreenWidth / 3f) * 2;
                    y = Window_Controller.ScreenHeight / 3f;
                    break;
                case OrientationAnchor.LeftBottom:
                    y = (Window_Controller.ScreenHeight / 3) * 2;
                    break;
                case OrientationAnchor.CenterBottom:
                    x = Window_Controller.ScreenWidth / 3f;
                    y = (Window_Controller.ScreenHeight / 3) * 2;
                    break;
                case OrientationAnchor.RightBottom:
                    x = (Window_Controller.ScreenWidth / 3f) * 2;
                    y = (Window_Controller.ScreenHeight / 3) * 2;
                    break;
            }

            switch (innerAnchor)
            {
                case OrientationAnchor.CenterTop:
                    x += ((Window_Controller.ScreenWidth / 3f) / 2f) - uIElement.Width / 2f;
                    break;
                case OrientationAnchor.RightTop:
                    x = (x + Window_Controller.ScreenWidth / 3f) - uIElement.Width;
                    break;
                case OrientationAnchor.LeftMiddle:
                    y += ((Window_Controller.ScreenHeight / 3f) / 2f) - uIElement.Height / 2f;
                    break;
                case OrientationAnchor.CenterMiddle:
                    x += ((Window_Controller.ScreenWidth / 3f) / 2f) - uIElement.Width / 2f;
                    y += ((Window_Controller.ScreenHeight / 3f) / 2f) - uIElement.Height / 2f;
                    break;
                case OrientationAnchor.RightMiddle:
                    x = (x + Window_Controller.ScreenWidth / 3f) - uIElement.Width;
                    y += ((Window_Controller.ScreenHeight / 3f) / 2f) - uIElement.Height / 2f;
                    break;
                case OrientationAnchor.LeftBottom:
                    y += (((Window_Controller.ScreenHeight / 3f) * 2f) / 2f) - uIElement.Height;
                    break;
                case OrientationAnchor.CenterBottom:
                    x += ((Window_Controller.ScreenWidth / 3f) / 2f) - uIElement.Width / 2f;
                    y += (((Window_Controller.ScreenHeight / 3f) * 2f) / 2f) - uIElement.Height;
                    break;
                case OrientationAnchor.RightBottom:
                    x = (x + Window_Controller.ScreenWidth / 3f) - uIElement.Width;
                    y += (((Window_Controller.ScreenHeight / 3f) * 2f) / 2f) - uIElement.Height;
                    break;
            }

            uIElement.Position = new Vector2(x, y);
        }

        public static void StickToSide(this UIElement uIElement, OrientationAnchor orientation)
        {
            //hibát fog dobni ha konstruktorban hívod meg mert akkor még nem tudja elérni a uIElement tulajdonságait

            float x = 0;
            float y = 0;

            switch (orientation)
            {
                case OrientationAnchor.CenterTop:
                    x = (Window_Controller.ScreenWidth / 2f) - uIElement.Width / 2f;
                    break;
                case OrientationAnchor.RightTop:
                    x = Window_Controller.ScreenWidth - uIElement.Width;
                    break;
                case OrientationAnchor.LeftMiddle:
                    y = (Window_Controller.ScreenHeight / 2f) - uIElement.Height / 2f;
                    break;
                case OrientationAnchor.CenterMiddle:
                    x = (Window_Controller.ScreenWidth / 2f) - uIElement.Width / 2f;
                    y = (Window_Controller.ScreenHeight / 2f) - uIElement.Height / 2f;
                    break;
                case OrientationAnchor.RightMiddle:
                    x = Window_Controller.ScreenWidth - uIElement.Width;
                    y = (Window_Controller.ScreenHeight / 2f) - uIElement.Height / 2f;
                    break;
                case OrientationAnchor.LeftBottom:
                    y = Window_Controller.ScreenHeight - uIElement.Height;
                    break;
                case OrientationAnchor.CenterBottom:
                    x = (Window_Controller.ScreenWidth / 2f) - uIElement.Width / 2f;
                    y = Window_Controller.ScreenHeight - uIElement.Height;
                    break;
                case OrientationAnchor.RightBottom:
                    x = Window_Controller.ScreenWidth - uIElement.Width;
                    y = Window_Controller.ScreenHeight - uIElement.Height;
                    break;
            }

            uIElement.Position = new Vector2(x, y);
        }

        public static void Chain(UIElement first, UIElement second, ChainOrientation orientation)
        {
            switch (orientation)
            {
                case ChainOrientation.Above:
                    second.Position = new Vector2(first.Position.X, first.Position.Y - second.Height);
                    break;
                case ChainOrientation.Right:
                    second.Position = new Vector2(first.Position.X + second.Width, first.Position.Y);
                    break;
                case ChainOrientation.Below:
                    second.Position = new Vector2(first.Position.X, first.Position.Y + second.Height);
                    break;
                case ChainOrientation.Left:
                    second.Position = new Vector2(first.Position.X - second.Width, first.Position.Y);
                    break;
            }
        }
    }
}
