using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CardGame.Classes_UI
{
    public abstract class UIElement
    {
        private static LinkedList<UIElement> uIElements = new LinkedList<UIElement>();

        public Rectangle Rect => new Rectangle(Position.X + (LeftPadding - RightPadding), Position.Y + (TopPadding - BottomPadding), Width, Height);
        public bool Visible;

        public int Width { get; set; }
        public int Height { get; set; }
        public Color Color { get; set; }
        public Vector2 Position { get; set; }


        #region Border
        public bool BorderVisible { get; set; }
        public Color BorderColor { get; set; }

        private int _topBorder = 5;
        private int _rightBorder = 5;
        private int _bottomBorder = 5;
        private int _leftBorder = 5;

        public int TopBorder { get => _topBorder; set => _topBorder = Math.Max(0, value); }
        public int RightBorder { get => _rightBorder; set => _rightBorder = Math.Max(0, value); }
        public int BottomBorder { get => _bottomBorder; set => _bottomBorder = Math.Max(0, value); }
        public int LeftBorder { get => _leftBorder; set => _leftBorder = Math.Max(0, value); }
        #endregion
        #region Padding
        private int _topPadding, _rightPadding, _bottomPadding, _leftPadding;

        public int TopPadding { get => _topPadding; set => _topPadding = Math.Max(0, value); }
        public int RightPadding { get => _rightPadding; set => _rightPadding = Math.Max(0, value); }
        public int BottomPadding { get => _bottomPadding; set => _bottomPadding = Math.Max(0, value); }
        public int LeftPadding { get => _leftPadding; set => _leftPadding = Math.Max(0, value); }

        #endregion

        protected UIElement()
        {
            uIElements.AddLast(this);
        }

        public void Dispose()
        {
            uIElements.Remove(this);
        }

        public void BringForwarByOne()
        {
            var node = uIElements.Find(this);
            if (node == null || node.Next == null) return;

            uIElements.Remove(node);
            uIElements.AddAfter(node.Next, node);
        }

        public void BringBackwardsByOne()
        {
            var node = uIElements.Find(this);
            if (node == null || node.Previous == null) return;

            uIElements.Remove(node);
            uIElements.AddBefore(node.Previous, node);
        }

        public void BringFront()
        {
            var node = uIElements.Find(this);
            if (node == null || node == uIElements.Last) return;

            uIElements.Remove(node);
            uIElements.AddLast(node);
        }

        public void BringBack()
        {
            var node = uIElements.Find(this);
            if (node == null || node == uIElements.First) return;

            uIElements.Remove(node);
            uIElements.AddFirst(node);
        }

        public virtual void Draw()
        {
            if (!Visible)
            {
                return;
            }

            if (this.BorderVisible)
            {
                Raylib.DrawLineEx(
                    new Vector2(this.Rect.Position.X - this.RightBorder, this.Rect.Position.Y - TopBorder / 2f),
                    new Vector2(this.Rect.Position.X + this.Width + this.RightBorder, this.Rect.Position.Y - TopBorder / 2f),
                    TopBorder,
                    BorderColor
                );

                Raylib.DrawLineEx(
                    new Vector2(this.Rect.Position.X + this.Width + this.LeftBorder / 2f, this.Rect.Position.Y - TopBorder),
                    new Vector2(this.Rect.Position.X + this.Width + LeftBorder / 2f, this.Rect.Position.Y + this.Height + BottomBorder),
                    RightBorder,
                    BorderColor
                );

                Raylib.DrawLineEx(
                    new Vector2(this.Rect.Position.X + this.Width + LeftBorder, this.Rect.Position.Y + this.Height + BottomBorder / 2f),
                    new Vector2(this.Rect.Position.X - this.RightBorder, this.Rect.Position.Y + this.Height + BottomBorder / 2f),
                    BottomBorder,
                    BorderColor
                );

                Raylib.DrawLineEx(
                    new Vector2(this.Rect.Position.X - this.RightBorder / 2f, this.Rect.Position.Y + this.Height + BottomBorder),
                    new Vector2(this.Rect.Position.X - this.RightBorder / 2f, this.Rect.Position.Y - TopBorder),
                    LeftBorder,
                    BorderColor
                );
            }

            Raylib.DrawRectangleRec(Rect, Color);
        }
        public virtual void SetBodersThickness(int BorderThickness)
        {
            TopBorder = BorderThickness;
            RightBorder = BorderThickness;
            BottomBorder = BorderThickness;
            LeftBorder = BorderThickness;
        }

        public static void DrawUIElements()
        {
            foreach (UIElement uIElement in uIElements)
            {
                uIElement.Draw();
            }
        }
    }
}
