using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class BigCoin : Entity
    {
        public BigCoin()
        {
            ch = Constants.BigCoin;
            Background = ConsoleColor.Black;
        }

        public override void Print()
        {
            Console.BackgroundColor = Background;
            Console.Write(ch + "  ");
        }
    }
}
