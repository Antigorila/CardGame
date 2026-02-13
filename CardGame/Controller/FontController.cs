using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CardGame.Controller
{
    public enum FontSize
    {
        Small,
        Medium,
        Large
    }
    public static class FontController
    {
        private static Font font_small;
        private static Font font_medium;
        private static Font font_large;

        public static Font GetFont(FontSize size)
        {
            switch (size)
            {
                case FontSize.Small:
                    return font_small;
                case FontSize.Medium:
                    return font_medium;
                case FontSize.Large:
                    return font_large;
                default:
                    return font_small;
            }
        }

        public static int GetFontSize(FontSize size)
        {
            switch (size)
            {
                case FontSize.Small:
                    return 18;
                case FontSize.Medium:
                    return 32;
                case FontSize.Large:
                    return 72;
                default:
                    return 0;
            }
        }

        public static void SetFont(Font new_font, FontSize size)
        {
            switch (size)
            {
                case FontSize.Small:
                    font_small = new_font;
                    break;
                case FontSize.Medium:
                    font_medium = new_font;
                    break;
                case FontSize.Large:
                    font_large = new_font;
                    break;
            }
        }

        public static void Write(string text, Color color, FontSize size, Vector2 position)
        {
            //Raylib.DrawText(text, (int)position.X, (int)position.Y, fontSize, color);
            Raylib.DrawTextEx(GetFont(size), text, position, GetFontSize(size), 2, color);
        }
        public static void Write(string text, Color color, FontSize size)
        {
            Write(text, color, size, new Vector2(20, 20));
        }
        public static void Write(string text, Color color)
        {
            Write(text, color, FontSize.Medium);
        }
        public static void Write(string text)
        {
            Write(text, Color.White);
        }

        public static Vector2 MeasureText(this string text, FontSize fontSize)
        {
            Vector2 res = Raylib.MeasureTextEx(
                GetFont(fontSize),
                text,
                GetFontSize(fontSize), //in px
                2.0f //spacing
            );

            //X: width, Y: height
            return res;
        }
    }
}
