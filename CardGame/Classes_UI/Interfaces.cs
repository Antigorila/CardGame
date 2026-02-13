using CardGame.Controller;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Classes_UI
{
    public interface IClick
    {
        object ButtonId { get; set; }
        void OnClick();
    }

    public interface IHoover
    {
        void HooverEffect();
    }
    public interface IHaveBackground
    {
        Texture2D BackgroundTexture { get; set; }
        void ShowBackground();
        void HideBackground();
    }

    public interface IShowText
    {
        string Text { get; set; }
        FontSize TextSize { get; set; }
        Color TextColor { get; set; }
        OrientationAnchor TextOrientation { get; set; }
        void ShowText();
        void HideText();
    }
}
