using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class DisplayInfo
    {
        public void displayScore()
        {
            Console.SetCursorPosition(64, 1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Score: " + Scores.coins);
        }
    }
}
