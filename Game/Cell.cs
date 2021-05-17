using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Cell
    {
        static object locker = new object();
        private DisplayInfo Info = new DisplayInfo();

        public void UpdateCell(int x, int y, char ch, ConsoleColor color)
        {
            lock (locker)
            {
                Console.BackgroundColor = color;
                Console.SetCursorPosition(x * 3, y);
                Console.Write(ch);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("  ");
                Console.SetCursorPosition(x * 3, y);
                Console.ResetColor();
                Info.Score();
                Info.Coordinates();
            }
        }
    }
}
