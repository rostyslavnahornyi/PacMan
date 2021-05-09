using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Runner
    {
        public static Cell Cell = new Cell();
        public void Run()
        {
            new CustomConsole(100, 25);
            new Start();
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                StartGame();
            }

        }

        public void StartGame()
        {
            Settings.MovingGhosts = true;

            new CustomConsole(100, 16);

            Field Field = new Field();
            Field.Fill();
            Field.Print();

            new Scores();

            new DisplayInfo().displayScore();

            new Threads();
        }
    }
}
