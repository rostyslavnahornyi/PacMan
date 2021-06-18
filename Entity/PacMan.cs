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
            if (Field.entities[x + X, y + Y].ch == Constants.Wall)
            {
                Renderer.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
            }
            else if (Field.entities[x + X, y + Y].ch == Constants.Ghost)
            {               
                IntroScenes.End();
            }
            else if (Field.entities[x + X, y + Y].ch == Constants.Coin)
            {
                Field.entities[x, y] = new Space();
                Renderer.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                x += X;
                y += Y;
                Field.entities[x, y] = this;
                Renderer.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                Scores.coins++;
                new Sound().ON_GettedCoins();
                if (Scores.coins == Scores.MaxCoins)
                {
                    IntroScenes.Win();
                }
            }
            else if (Field.entities[x + X, y + Y].ch == Constants.BigCoin)
            {
                Field.entities[x, y] = new Space();
                Renderer.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                x += X;
                y += Y;
                Field.entities[x, y] = this;
                Renderer.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                Scores.coins += 3;
                new Sound().ON_GettedCoins();
                if (Scores.coins == Scores.MaxCoins)
                {
                    IntroScenes.Win();
                }
            }
            else if (Field.entities[x + X, y + Y].ch == Constants.Space)
            {
                Field.entities[x, y] = new Space();
                Renderer.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                x += X;
                y += Y;
                Field.entities[x, y] = new PacMan(x, y);
                Renderer.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
            }
            else if (Field.entities[x + X, y + Y].ch == Constants.RandomTeleport)
            {
                Field.entities[x, y] = new Space();
                Renderer.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                x += X;
                y += Y;
                Field.entities[x, y] = this;
                Renderer.UpdateCell(x, y, RandomTeleport.cellUnderTeleport, ConsoleColor.Black);
                new RandomTeleport().Loop();
                x = RandomTeleport.randomX;
                y = RandomTeleport.randomY;                
                Field.entities[x, y].ch = Constants.PacMan;
                Renderer.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                if (Field.entities[x, y].ch == Constants.Coin)
                {
                    Scores.coins++;
                }
                else if (Field.entities[x, y].ch == Constants.BigCoin)
                {
                    Scores.coins += 3;
                }
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
