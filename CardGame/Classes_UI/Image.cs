using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Classes_UI
{
    internal class Image : UIElement, IHoover, IHaveBackground
    {
        public Texture2D BackgroundTexture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ShowBackground()
        {
            throw new NotImplementedException();
        }

        public void HideBackground()
        {
            throw new NotImplementedException();
        }

        public void HooverEffect()
        {
            throw new NotImplementedException();
        }
    }
}
