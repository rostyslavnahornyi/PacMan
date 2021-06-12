using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Space : Entity
    {
        public Space()
        {
            ch = Constants.Space;
            Background = ConsoleColor.Black;
        }
        public override void Print()
        {
            Console.BackgroundColor = Background;
            Console.Write(ch + "  ");
        }
    }
}
