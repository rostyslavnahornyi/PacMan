using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class PacMan : FieldBuilder
    {
        private char ch = Constants.PacMan;
        private ConsoleColor BG = ConsoleColor.DarkRed;
       
        private static int x;
        private static int y;

        public PacMan()
        {
            FindPacMan();
        }

        public override void Display()
        {
            Console.BackgroundColor = BG;
            Console.Write(ch);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(space);
        }

        private void FindPacMan()
        {
            for (int i = 0; i < Field.arr.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < Field.arr.GetUpperBound(0) + 1; j++)
                {
                    if (Field.arr[j, i] == Constants.PacMan)
                    {
                        x = j;
                        y = i;
                    }
                }
            }
        }

        public void Moving()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        if (Field.arr[x - 1, y] == Constants.Wall)
                        {
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                        else if (Field.arr[x - 1, y] == Constants.Coin)
                        {
                            Field.arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            x--;
                            Field.arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins++;
                            new Sound().ON_GettedCoins();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (Field.arr[x - 1, y] == Constants.BigCoin)
                        {
                            Field.arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            x--;
                            Field.arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins += 3;
                            new Sound().ON_GettedCoins();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (Field.arr[x - 1, y] == Constants.Ghost)
                        {
                            Settings.MovingGhosts = false;
                            new End();
                        }
                        else if (Field.arr[x - 1, y] == Constants.Space)
                        {
                            Field.arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            x--;
                            Field.arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                    }

                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        if (Field.arr[x + 1, y] == Constants.Wall)
                        {
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                        else if (Field.arr[x + 1, y] == Constants.Coin)
                        {
                            Field.arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            x++;
                            Field.arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins++;
                            new Sound().ON_GettedCoins();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (Field.arr[x + 1, y] == Constants.BigCoin)
                        {
                            Field.arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            x++;
                            Field.arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins += 3;
                            new Sound().ON_GettedCoins();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (Field.arr[x + 1, y] == Constants.Ghost)
                        {
                            Settings.MovingGhosts = false;
                            new End();
                        }
                        else if (Field.arr[x + 1, y] == Constants.Space)
                        {
                            Field.arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            x++;
                            Field.arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                    }

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (Field.arr[x, y - 1] == Constants.Wall)
                        {
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                        else if (Field.arr[x, y - 1] == Constants.Coin)
                        {
                            Field.arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            y--;
                            Field.arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins++;
                            new Sound().ON_GettedCoins();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (Field.arr[x, y - 1] == Constants.BigCoin)
                        {
                            Field.arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            y--;
                            Field.arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins += 3;
                            new Sound().ON_GettedCoins();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (Field.arr[x, y - 1] == Constants.Ghost)
                        {
                            Settings.MovingGhosts = false;
                            new End();
                        }
                        else if (Field.arr[x, y - 1] == Constants.Space)
                        {
                            Field.arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            y--;
                            Field.arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                    }

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (Field.arr[x, y + 1] == Constants.Wall)
                        {
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                        else if (Field.arr[x, y + 1] == Constants.Coin)
                        {
                            Field.arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            y++;
                            Field.arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins++;
                            new Sound().ON_GettedCoins();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (Field.arr[x, y + 1] == Constants.BigCoin)
                        {
                            Field.arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            y++;
                            Field.arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins += 3;
                            new Sound().ON_GettedCoins();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (Field.arr[x, y + 1] == Constants.Ghost)
                        {
                            Settings.MovingGhosts = false;
                            new End();
                        }
                        else if (Field.arr[x, y + 1] == Constants.Space)
                        {
                            Field.arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            y++;
                            Field.arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                    }
                }
            }
        }
    }
}
