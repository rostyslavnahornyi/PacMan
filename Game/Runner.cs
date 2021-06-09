using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Runner
    {

        public void Run()
        {
            Console.SetWindowSize(100, 25);
            IntroScenes.Start();

        }

        public static void StartGame()
        {
            DisplayInfo info = new DisplayInfo();
            Threads threads = new Threads();
            Scores scores = new Scores();
            Field field = new Field();

            Console.SetWindowSize(100, 16);

            field.Fill();
            field.Print();
            scores.FindAllCoins();
            info.Score();
            info.Coordinates();
            threads.ON();
        }
    }
}
