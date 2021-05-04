using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PacMan
{
    class Field
    {
        private static string[] lines = File.ReadAllLines("../../../Resources/map1.txt");
        public static char[,] arr = new char[lines[0].Length, lines.Length];



        public void Fill()
        {
            for (int i = 0; i < lines[0].Length; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    arr[i, j] = lines[j][i];
                }
            }
        }

        public void Print()
        {
            Console.ResetColor();
            Console.Clear();
            string space = "  ";

            for (int y = 0; y < arr.GetUpperBound(1) + 1; y++)
            {
                for (int x = 0; x < arr.GetUpperBound(0) + 1; x++)
                {
                    if (arr[x, y] == Constants.Coin)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(Constants.Coin);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(space);
                    }
                    else if (arr[x, y] == Constants.PacMan)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Write(Constants.PacMan);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(space);
                    }
                    else if (arr[x, y] == Constants.Ghost)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Constants.Ghost);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(space);
                    }
                    else if (arr[x, y] != Constants.Wall)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(arr[x, y] + space);
                    }

                    if (x != arr.GetUpperBound(0))
                    {
                        if (arr[x, y] == Constants.Wall && arr[x + 1, y] == Constants.Wall)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(Constants.Wall + space);
                        }
                        else if (arr[x, y] == Constants.Wall)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(Constants.Wall);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(space);
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(Constants.Wall);
                        break;
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
    }
}
