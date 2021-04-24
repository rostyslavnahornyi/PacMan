using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class CustomConsole
    {
        public CustomConsole()
        {
            Main();
        }

        private void Main()
        {
            Console.SetWindowSize(93, 27);
            Console.CursorVisible = Settings.CursorVisible;
        }

    }
}
