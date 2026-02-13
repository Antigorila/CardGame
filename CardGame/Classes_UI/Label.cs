using CardGame.Controller;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CardGame.Classes_UI
{
    internal class Label : UIElement, IShowText, IHaveBackground, IHoover
    {
        public string Text { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public FontSize TextSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Color TextColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Texture2D BackgroundTexture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public OrientationAnchor TextOrientation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ShowBackground()
        {
            throw new NotImplementedException();
        }

        public void HideBackground()
        {
            throw new NotImplementedException();
        }

        public void ShowText()
        {
            throw new NotImplementedException();
        }

        public void HideText()
        {
            throw new NotImplementedException();
        }

        public void HooverEffect()
        {
            throw new NotImplementedException();
        }

        public void WrapAroundText() //TODO: teszt
        {
            Vector2 size = Raylib.MeasureTextEx(
                Font_Controller.GetFont(this.TextSize),
                this.Text,
                Font_Controller.GetFontSize(this.TextSize),
                2.0f
            );

            this.Width = (int)size.X;
            this.Height = (int)size.Y;

            //x - text width 1:1
            //y - text height 1:1
        }
    }
}
