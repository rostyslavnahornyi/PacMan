using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Renderer
    {
        public static void UpdateCell(int x, int y, char ch, ConsoleColor color)
        {
            DisplayInfo info = new DisplayInfo();
            lock (Util.locker)
            {
                Console.BackgroundColor = color;
                Console.SetCursorPosition(x * 3, y);
                Console.Write(ch);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("  ");
                Console.SetCursorPosition(x * 3, y);
                Console.ResetColor();

                info.Score();
                info.Coordinates();
            }
        }
    }
}
