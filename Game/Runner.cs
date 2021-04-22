using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Runner
    {
        public void Run()
        {
            new Field().BuildField();
            new CustomConsole();
        }
        
    }
}
