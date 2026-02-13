using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Controller
{
    internal class Game_Controller
    {
        public enum GameState
        {
            InGame,
            Paused,
            Loading,
            StartScreen
        }

        private static GameState _state;
        public static GameState State 
        { 
            get 
            { 
                return _state;
            }
            set 
            {
                _state = value;
            }
        }
    }
}
