using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class PacMan : Entity
    {       
        public static int x;
        public static int y;

        public PacMan(int x, int y)
        {
            ch = Constants.PacMan;
            Background = ConsoleColor.DarkRed;

            PacMan.x = x;
            PacMan.y = y;
        }

        public override void Print()
        {
            Console.BackgroundColor = Background;
            Console.Write(ch);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
        }

        private void MovingTo(int X, int Y)
        {
            Entity temp;
            if (Field.entities[x + X, y + Y].ch == Constants.Wall)
            {
                Renderer.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
            }
            else if (Field.entities[x + X, y + Y].ch == Constants.Ghost)
            {
                Settings.MovingGhosts = false;
                IntroScenes.End();
            }
            else if (Field.entities[x + X, y + Y].ch == Constants.Coin)
            {
                temp = Field.entities[x, y];
                Field.entities[x, y] = new Space();
                Renderer.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                x += X;
                y += Y;
                Field.entities[x, y] = temp;
                Renderer.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                Scores.coins++;
                new Sound().ON_GettedCoins();
                if (Scores.coins == Scores.MaxCoins)
                {
                    Settings.MovingGhosts = false; // в функциональность классов
                    IntroScenes.Win();
                }
            }
            else if (Field.entities[x + X, y + Y].ch == Constants.BigCoin)
            {
                temp = Field.entities[x, y];
                Field.entities[x, y] = new Space();
                Renderer.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                x += X;
                y += Y;
                Field.entities[x, y] = temp;
                Renderer.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                Scores.coins += 3;
                new Sound().ON_GettedCoins();
                if (Scores.coins == Scores.MaxCoins)
                {
                    Settings.MovingGhosts = false;
                    IntroScenes.Win();
                }
            }
            else if (Field.entities[x + X, y + Y].ch == Constants.Space)
            {
                temp = Field.entities[x, y];
                Field.entities[x, y] = new Space();
                Renderer.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                x += X;
                y += Y;
                Field.entities[x, y] = temp;
                Renderer.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
            }
            else if (Field.entities[x + X, y + Y].ch == Constants.RandomTeleport)
            {
                temp = Field.entities[x, y];
                Field.entities[x, y] = new Space();
                Renderer.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                x += X;
                y += Y;
                Field.entities[x, y] = temp;
                Renderer.UpdateCell(x, y, RandomTeleport.tempCell, ConsoleColor.Black);
                new RandomTeleport().Loop();
                x = RandomTeleport.randomX;
                y = RandomTeleport.randomY;
                if (Field.entities[x, y].ch == Constants.Coin)
                {
                    Scores.coins++;
                }
                else if (Field.entities[x, y].ch == Constants.BigCoin)
                {
                    Scores.coins += 3;
                }
                Field.entities[x, y].ch = Constants.PacMan;
                Renderer.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
            }
        }

        public override void Loop()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        MovingTo(-1, 0);
                    }

                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        MovingTo(1, 0);
                    }

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        MovingTo(0, -1);
                    }

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        MovingTo(0, 1);
                    }
                }
            }
        }
    }
}
