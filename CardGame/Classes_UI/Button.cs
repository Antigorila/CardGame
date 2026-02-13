using CardGame.Controller;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace CardGame.Classes_UI
{
    internal class Button : UIElement, IHoover, IShowText, IClick
    {
        [AllowNull]
        private object _buttonId;
        public object ButtonId 
        {
            get
            {
                if (_buttonId == null)
                {
                    throw new NoButtonIdException();
                }

                return _buttonId;
            }
            set
            {
                _buttonId = value;
            }
        }

        [AllowNull]
        public string Text { get; set; }
        public FontSize TextSize { get; set; }
        public Color TextColor { get; set; }
        public OrientationAnchor TextOrientation { get; set; }

        public Button() : this(150, 25) { }

        public Button(int width, int height) : this(width, height, Color.Gray) { }

        public Button(int width, int height, Color color) : this(width, height, color, Window_Controller.Center) { }

        public Button(int width, int height, Color color, Vector2 position)
        {
            this.Visible = true;
            this.Width = width;
            this.Height = height;
            this.Color = color;
            this.Position = position;

            this.BorderVisible = false;
            this.BorderColor = Color.Black;
            this.Color = Color.Gray;

            this.Text = string.Empty;
            this.TextColor = Color.Black;
            this.TextSize = FontSize.Medium;
            this.TextOrientation = OrientationAnchor.CenterMiddle;
        }

        public void OnClick()
        {
            throw new NotImplementedException();
        }

        public void HooverEffect()
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

        public override void Draw()
        {
            base.Draw();
            FontController.Write(Text, TextColor, TextSize, GetTextPosition());
        }

        private Vector2 GetTextPosition()
        {

            float x = this.Position.X;
            float y = this.Position.Y;

            switch (TextOrientation)
            {
                case OrientationAnchor.CenterTop:
                    x += this.Width / 3f;
                    break;
                case OrientationAnchor.RightTop:
                    x += (this.Width / 3f) * 2f;
                    break;
                case OrientationAnchor.LeftMiddle:
                    break;
                case OrientationAnchor.CenterMiddle:
                    break;
                case OrientationAnchor.RightMiddle:
                    break;
                case OrientationAnchor.LeftBottom:
                    break;
                case OrientationAnchor.CenterBottom:
                    break;
                case OrientationAnchor.RightBottom:
                    break;
            }

            return new Vector2(x, y);
        }
    }
}
