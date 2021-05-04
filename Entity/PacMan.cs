using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class PacMan : Field
    {
        private static int x;
        private static int y;

        public PacMan()
        {
            FindPacMan();
        }

        private void FindPacMan()
        {
            for (int i = 0; i < arr.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < arr.GetUpperBound(0) + 1; j++)
                {
                    if (arr[j, i] == Constants.PacMan)
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
                        if (arr[x - 1, y] == Constants.Wall)
                        {
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                        else if (arr[x - 1, y] == Constants.Coin)
                        {
                            arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            x--;
                            arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins++;
                            new DisplayInfo().displayScore();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (arr[x - 1, y] == Constants.BigCoin)
                        {
                            arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            x--;
                            arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins += 3;
                            new DisplayInfo().displayScore();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (arr[x - 1, y] == Constants.Ghost)
                        {
                            // todo
                        }
                        else if (arr[x - 1, y] == Constants.Space)
                        {
                            arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            x--;
                            arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                    }

                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        if (arr[x + 1, y] == Constants.Wall)
                        {
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                        else if (arr[x + 1, y] == Constants.Coin)
                        {
                            arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            x++;
                            arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins++;
                            new DisplayInfo().displayScore();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (arr[x + 1, y] == Constants.BigCoin)
                        {
                            arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            x++;
                            arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins += 3;
                            new DisplayInfo().displayScore();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (arr[x + 1, y] == Constants.Ghost)
                        {
                            // todo
                        }
                        else if (arr[x + 1, y] == Constants.Space)
                        {
                            arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            x++;
                            arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                    }

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (arr[x, y - 1] == Constants.Wall)
                        {
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                        else if (arr[x, y - 1] == Constants.Coin)
                        {
                            arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            y--;
                            arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins++;
                            new DisplayInfo().displayScore();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (arr[x, y - 1] == Constants.BigCoin)
                        {
                            arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            y--;
                            arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins += 3;
                            new DisplayInfo().displayScore();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (arr[x, y - 1] == Constants.Ghost)
                        {
                            // todo
                        }
                        else if (arr[x, y - 1] == Constants.Space)
                        {
                            arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            y--;
                            arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                    }

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (arr[x, y + 1] == Constants.Wall)
                        {
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                        else if (arr[x, y + 1] == Constants.Coin)
                        {
                            arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            y++;
                            arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins++;
                            new DisplayInfo().displayScore();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (arr[x, y + 1] == Constants.BigCoin)
                        {
                            arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            y++;
                            arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                            Scores.coins += 3;
                            new DisplayInfo().displayScore();
                            if (Scores.coins == Scores.MaxCoins)
                            {
                                Settings.MovingGhosts = false;
                                new Win();
                            }
                        }
                        else if (arr[x, y + 1] == Constants.Ghost)
                        {
                            // todo
                        }
                        else if (arr[x, y + 1] == Constants.Space)
                        {
                            arr[x, y] = Constants.Space;
                            Runner.Cell.UpdateCell(x, y, Constants.Space, ConsoleColor.Black);
                            y++;
                            arr[x, y] = Constants.PacMan;
                            Runner.Cell.UpdateCell(x, y, Constants.PacMan, ConsoleColor.DarkRed);
                        }
                    }
                }
            }
        }
    }
}
