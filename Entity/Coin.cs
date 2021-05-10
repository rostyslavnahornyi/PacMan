using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan 
{
    class Coin : FieldBuilder
    {
        private char ch = Constants.Coin;
        private ConsoleColor BG = ConsoleColor.Black;

        public override void Display()
        {
            Console.BackgroundColor = BG;
            Console.Write(ch);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(space);
        }
    }
}
