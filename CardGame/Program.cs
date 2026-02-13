using CardGame.Classes_UI;
using CardGame.Controller;
using Raylib_cs;
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

//TODO//
/*
 * Default UI elemek
 * Resize 3 méretre - fullscreen talán
 */

namespace CardGame
{
    public class Program
    {
        private static void Initialize()
        {
            Window_Controller.SetUpWindow();
            Game_Controller.State = Game_Controller.GameState.StartScreen;
        }

        private static Texture2D backgroundImage;
        private static void Load()
        {
            backgroundImage = Raylib.LoadTexture("../../../Assets/Background/paper.jpg");

            //Fonts:
            FontController.SetFont(Raylib.LoadFontEx("../../../Assets/Fonts/PlayfairDisplay-VariableFont_wght.ttf", 18, null, 0), FontSize.Small);
            FontController.SetFont(Raylib.LoadFontEx("../../../Assets/Fonts/PlayfairDisplay-VariableFont_wght.ttf", 32, null, 0), FontSize.Medium);
            FontController.SetFont(Raylib.LoadFontEx("../../../Assets/Fonts/PlayfairDisplay-VariableFont_wght.ttf", 72, null, 0), FontSize.Large);

        }

        private static Button btn = new Button(35,35);
        private static Button btn2 = new Button();
        private static void Update()
        {
            backgroundImage.Width = Window_Controller.ScreenWidth;
            backgroundImage.Height = Window_Controller.ScreenHeight;
            Raylib.DrawTexture(backgroundImage, 0, 0, Color.White);

            btn.StickToSidePosition(OrientationAnchor.RightTop, OrientationAnchor.RightTop);
            btn.TextOrientation = OrientationAnchor.CenterTop;
            btn.BorderVisible = true;
            btn.Visible = true;


            string t = "TestText";
            btn2.Text = t;
            btn2.TextSize = FontSize.Medium;
           

            btn2.Width = (int)t.MeasureText(btn2.TextSize).X;
            btn2.Height = (int)t.MeasureText(btn2.TextSize).Y;








            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                // addig fut amíg le van nyomva
                FontController.Write("'A' down", Color.White, FontSize.Large, new Vector2(50, 50));
            }

            if (Raylib.IsKeyPressed(KeyboardKey.S))
            {
                // egyszer fut le lenyomáskor
                FontController.Write("'S' pressed", Color.White, FontSize.Medium, new Vector2(50, 50));
            }

            if (Raylib.IsKeyReleased(KeyboardKey.D))
            {
                // akkor fut, amikor elengeded
                FontController.Write("'D' released", Color.Black, FontSize.Small, new Vector2(150, 150));
            }


            Raylib.DrawLineEx(new Vector2(0, 0), new Vector2(Window_Controller.ScreenWidth, 0), 10, Color.Black);

            Raylib.DrawLineEx(new Vector2(0, 0), new Vector2(0, Window_Controller.ScreenHeight), 10, Color.Black);

            Raylib.DrawLineEx(new Vector2(Window_Controller.ScreenWidth, 0), new Vector2(Window_Controller.ScreenWidth, Window_Controller.ScreenHeight), 10, Color.Black);

            Raylib.DrawLineEx(new Vector2(0, Window_Controller.ScreenHeight), new Vector2(Window_Controller.ScreenWidth, Window_Controller.ScreenHeight), 10, Color.Black);
            
            Raylib.DrawLineEx(new Vector2(Window_Controller.ScreenWidth / 2, 0), new Vector2(Window_Controller.ScreenWidth / 2, Window_Controller.ScreenHeight), 10, Color.Red);

            Raylib.DrawLineEx(new Vector2(0, Window_Controller.ScreenHeight / 2), new Vector2(Window_Controller.ScreenWidth, Window_Controller.ScreenHeight / 2), 10, Color.Red);
            
            Raylib.DrawLineEx(new Vector2(333, 0), new Vector2(333, 748), 10, Color.White);

            Raylib.DrawLineEx(new Vector2(666, 0), new Vector2(666, 748), 10, Color.White);

            Raylib.DrawLineEx(new Vector2(0, 249), new Vector2(1000, 249), 10, Color.White);

            Raylib.DrawLineEx(new Vector2(0, 498), new Vector2(1000, 498), 10, Color.White);


            FontController.Write("[0 : 0]", Color.White, FontSize.Medium, new Vector2(0, 0));
            FontController.Write($"[0 : H{Window_Controller.ScreenHeight}]", Color.White, FontSize.Medium, new Vector2(0, Window_Controller.ScreenHeight - 50));
            FontController.Write($"[W{Window_Controller.ScreenWidth} : 0]", Color.White, FontSize.Medium, new Vector2(Window_Controller.ScreenWidth - 150, 0));
            FontController.Write($"[W{Window_Controller.ScreenWidth} : H{Window_Controller.ScreenHeight}]", Color.White, FontSize.Medium, new Vector2(Window_Controller.ScreenWidth - 200, Window_Controller.ScreenHeight - 50));




            switch (Game_Controller.State)
            {
                case Game_Controller.GameState.InGame:
                    break;
                case Game_Controller.GameState.Paused:
                    break;
                case Game_Controller.GameState.Loading:
                    break;
                case Game_Controller.GameState.StartScreen:
                    FontController.Write("StartScreen", Color.Red);
                    break;
                default:
                    break;
            }
        }

        private static void Draw()
        {
            Raylib.BeginDrawing();
            //Raylib.ClearBackground(Color.DarkGray);

            //Window_Controller.Write("text", Color.Red);
            //Raylib.DrawTexture(backgroundImage, 0, 0, Color.White);

            UIElement.DrawUIElements();


            Raylib.EndDrawing();
        }

        public static void Main(string[] args)
        {
            Initialize();
            Load();
            while (!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }

            Raylib.UnloadTexture(backgroundImage);
            Raylib.CloseWindow();
        }
    }
}