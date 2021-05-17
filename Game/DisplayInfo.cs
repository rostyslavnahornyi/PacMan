using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class DisplayInfo
    {
        public void Score()
        {
            Console.ResetColor();
            Console.SetCursorPosition(64, 1);
            Console.Write("Score: " + Scores.coins);
        }

        public void Coordinates()
        {
            Console.ResetColor();
            Console.SetCursorPosition(0, 15);
            if (PacMan.x < 10)
            {
                Console.Write($"X: 0{PacMan.x}");
            } else
            {
                Console.Write($"X: {PacMan.x}");
            }
            Console.SetCursorPosition(7, 15);
            if (PacMan.y < 10)
            {
                Console.Write($"Y: 0{PacMan.y}"); 
            } else
            {
                Console.Write($"Y: {PacMan.y}");
            }
        }
    }
}
