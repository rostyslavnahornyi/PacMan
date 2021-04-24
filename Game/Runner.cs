using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Runner
    {
        public void Run()
        {
            new CustomConsole();
            new Start();

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                new Field().BuildField();
            }

            new Threads();
        }
        
    }
}
