using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Wall : FieldBuilder
    {
        private char ch = Constants.Wall;
        private ConsoleColor BG = ConsoleColor.DarkBlue;

        public override void Display()
        {
            Console.BackgroundColor = BG;
            Console.Write(ch);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(space);
        }

        public void DisplayFullColor()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(ch + space);
        }
    }
}
