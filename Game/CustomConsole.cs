using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class CustomConsole
    {
        public CustomConsole(int x, int y)
        {
            Console.SetWindowSize(x, y);
            Console.CursorVisible = Settings.CursorVisible;
        }
    }
}
