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

        public override void Display()
        {
            Console.BackgroundColor = Background;
            Console.Write(ch);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
        }

        public void Display(int x, int y, Entity[,] arr)
        {
            if (x != arr.GetUpperBound(0))
            {
                if (arr[x, y].ch == Constants.Wall && arr[x + 1, y].ch == Constants.Wall)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(ch + "  ");
                }
                else if (arr[x, y].ch == Constants.Wall)
                {
                    Display();
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(ch);
            }
        }
    }
}
