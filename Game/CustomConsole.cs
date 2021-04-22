using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class CustomConsole : Field
    {
        public CustomConsole()
        {
            Main();
        }

        private void Main()
        {
           int width = arr.GetUpperBound(0) + 1;
           int height = arr.GetUpperBound(1) + 1;

            Console.SetWindowSize(width * 3 + 1, height * 2 + 1);
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = Settings.CursorVisible;
        }

    }
}
