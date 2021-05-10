﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class BigCoin : FieldBuilder
    {
        private char ch = Constants.BigCoin;
        private ConsoleColor BG = ConsoleColor.Black;

        public override void Display()
        {
            Console.BackgroundColor = BG;
            Console.Write(ch + space);
        }
    }
}