using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan 
{
    class Coin : Entity
    {
        public Coin()
        {
            ch = Constants.Coin;
            Background = ConsoleColor.Black;
        }
        public override void Print()
        {
            Console.BackgroundColor = Background;
            Console.Write(ch + "  ");
        }
    }
}
