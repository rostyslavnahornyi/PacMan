using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PacMan
{
    class Field
    {
        private ConsoleColor Black = ConsoleColor.Black;
        private ConsoleColor Blue = ConsoleColor.DarkBlue;
        private ConsoleColor Yellow = ConsoleColor.DarkYellow;
        private ConsoleColor Magenta = ConsoleColor.DarkMagenta;

        private static string[] lines = File.ReadAllLines("../../../Resources/map1.txt");
        protected static char[,] arr = new char[lines[0].Length, lines.Length];
      

        public void BuildField()
        {
            for (int i = 0; i < lines[0].Length; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    arr[i, j] = lines[j][i];
                }
            }


            for (int y = 0; y < arr.GetUpperBound(1) + 1; y++)
            {
                for (int x = 0; x < arr.GetUpperBound(0) + 1; x++)
                {

                    if (arr[x, y] == '.') // const
                    {
                        Console.BackgroundColor = Black;
                        Console.Write("."); // const
                        Console.BackgroundColor = Black;
                        Console.Write("  ");
                    }
                    else if (arr[x, y] == '@') // const
                    {
                        Console.BackgroundColor = Yellow;
                        Console.Write("@"); // const
                        Console.BackgroundColor = Black;
                        Console.Write("  ");
                    }
                    else if (arr[x, y] == 'A') // const
                    {
                        Console.BackgroundColor = Magenta;
                        Console.Write("A"); // const
                        Console.BackgroundColor = Black;
                        Console.Write("  ");
                    } else if (arr[x, y] != '#') // const
                    {
                        Console.BackgroundColor = Black;
                        Console.Write(arr[x, y] + "  ");
                    }

                    if (x != arr.GetUpperBound(0))
                    {
                        if (arr[x, y] == '#' && arr[x + 1, y] == '#') // const
                        {
                            Console.BackgroundColor = Blue;
                            Console.Write("#  ");
                        }
                        else if (arr[x, y] == '#') // const
                        {
                            Console.BackgroundColor = Blue;
                            Console.Write("#"); // const
                            Console.BackgroundColor = Black;
                            Console.Write("  ");
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = Blue;
                        Console.Write("#");
                        break;
                    }
                }
                for (int xConsole = 0; xConsole < arr.GetUpperBound(0) + 1; xConsole++)
                {
                    if (y != arr.GetUpperBound(1))
                    {
                        if (arr[xConsole, y] == arr[xConsole, y + 1] && arr[xConsole, y] == '#' && arr[xConsole, y + 1] == '#')
                        {
                            if (y != 0)
                            {
                                Console.SetCursorPosition(xConsole * 3, y * 2 - 1);
                            }
                            else
                            {
                                Console.SetCursorPosition(xConsole * 3, 1);
                            }
                            Console.BackgroundColor = Blue;
                            Console.Write(" ");
                        }
                    }

                }
                Console.WriteLine("");
            }
        }
    }
}
