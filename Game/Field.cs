using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PacMan
{
    class Field
    {
        private static string[] lines = File.ReadAllLines("../../../Resources/map1.txt");
        public static Entity[,] arr = new Entity[lines[0].Length, lines.Length];



        public void Fill()
        {
            for (int i = 0; i < lines[0].Length; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    if (lines[j][i] == Constants.PacMan)
                    {
                        arr[i, j] = new PacMan(i, j);
                    }
                    if (lines[j][i] == Constants.Ghost)
                    {
                        arr[i, j] = new Ghost(i, j);
                    }
                    if (lines[j][i] == Constants.Wall)
                    {
                        arr[i, j] = new Wall();
                    }
                    if (lines[j][i] == Constants.BigCoin)
                    {
                        arr[i, j] = new BigCoin();
                    }
                    if (lines[j][i] == Constants.Coin)
                    {
                        arr[i, j] = new Coin();
                    }
                    if (lines[j][i] == Constants.RandomTeleport)
                    {
                        arr[i, j] = new RandomTeleport();
                    }
                }
            }
        }

        public void Print()
        {
            Console.ResetColor();
            Console.Clear();

            for (int y = 0; y < arr.GetUpperBound(1) + 1; y++)
            {
                for (int x = 0; x < arr.GetUpperBound(0) + 1; x++)
                {
                    if (arr[x, y].ch == Constants.Coin)
                    {
                        arr[x, y].Display();
                    }
                    else if (arr[x, y].ch == Constants.BigCoin)
                    {
                        arr[x, y].Display();
                    }
                    else if (arr[x, y].ch == Constants.PacMan)
                    {
                        arr[x, y].Display();
                    }
                    else if (arr[x, y].ch == Constants.Ghost)
                    {
                        arr[x, y].Display();
                    }
                    else if (arr[x, y].ch == Constants.Wall)
                    {
                        new Wall().Display(x, y, arr);
                    }
                }

                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public static int[] FindPacmanCoordinates()
        {
            int[] arr = new int[2];
            for (int i = 0; i < Field.arr.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < Field.arr.GetUpperBound(0) + 1; j++)
                {
                    if (Field.arr[j, i].ch == Constants.PacMan)
                    {
                        arr[0] = i;
                        arr[1] = j;
                    }
                }
            }
            return arr;
        }

        public static int[][] FindGhostsCoordinates()
        {
            int[][] arr = new int[3][]; // number of ghosts, coordinates
            arr[0] = new int[2];
            arr[1] = new int[2];
            arr[2] = new int[2];
            int numberGhost = 0;
            for (int i = 0; i < Field.arr.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < Field.arr.GetUpperBound(0) + 1; j++)
                {
                    if (Field.arr[j, i].ch == Constants.Ghost)
                    {
                        arr[numberGhost][0] = j;
                        arr[numberGhost][1] = i;
                        numberGhost++;
                    }
                }
            }
            return arr;
        }

        public static int[] FindRandomTeleportCoordinates()
        {
            int[] arr = new int[2];
            for (int i = 0; i < Field.arr.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < Field.arr.GetUpperBound(0) + 1; j++)
                {
                    if (Field.arr[j, i].ch == Constants.RandomTeleport)
                    {
                        arr[0] = i;
                        arr[1] = j;
                    }
                }
            }
            return arr;
        }
    }
}
