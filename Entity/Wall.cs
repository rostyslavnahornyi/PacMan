using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Wall : Entity
    {
        public Wall()
        {
            ch = Constants.Wall;
            Background = ConsoleColor.DarkBlue;
        }

        public override void Print()
        {
            Console.BackgroundColor = Background;
            Console.Write(ch);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
        }

        public void PrintInField(char rightChar)
        {
            if (rightChar == Constants.Wall)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(ch + "  ");
            }
            else
            {
                Print();
            }
        }
    }
}
