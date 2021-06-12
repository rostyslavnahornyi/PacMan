using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PacMan
{
    class Field
    {
        private static string[] lines = File.ReadAllLines("../../../Resources/map1.txt");
        public static Entity[,] entities = new Entity[lines[0].Length, lines.Length];



        public void Fill()
        {
            for (int i = 0; i < lines[0].Length; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    if (lines[j][i] == Constants.PacMan)
                    {
                        entities[i, j] = new PacMan(i, j);
                    }
                    if (lines[j][i] == Constants.Ghost)
                    {
                        entities[i, j] = new Ghost(i, j);
                    }
                    if (lines[j][i] == Constants.Wall)
                    {
                        entities[i, j] = new Wall();
                    }
                    if (lines[j][i] == Constants.BigCoin)
                    {
                        entities[i, j] = new BigCoin();
                    }
                    if (lines[j][i] == Constants.Coin)
                    {
                        entities[i, j] = new Coin();
                    }
                    if (lines[j][i] == Constants.RandomTeleport)
                    {
                        entities[i, j] = new RandomTeleport();
                    }
                }
            }
        }

        public void Print()
        {
            Console.ResetColor();
            Console.Clear();

            for (int y = 0; y < entities.GetUpperBound(1) + 1; y++)
            {
                for (int x = 0; x < entities.GetUpperBound(0) + 1; x++)
                {
                    
                    if (entities[x, y].ch == Constants.Wall)
                    {
                        char rightChar = (x < Field.entities.GetUpperBound(0) ? Field.entities[x + 1, y].ch : '\0');
                        ((Wall)entities[x, y]).PrintInField(rightChar);
                    } else
                    {
                        entities[x, y].Print();
                    }
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public static int[] FindPacmanCoordinates()
        {
            int[] arr = new int[2];
            for (int i = 0; i < Field.entities.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < Field.entities.GetUpperBound(0) + 1; j++)
                {
                    if (Field.entities[j, i].ch == Constants.PacMan)
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
            for (int i = 0; i < Field.entities.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < Field.entities.GetUpperBound(0) + 1; j++)
                {
                    if (Field.entities[j, i].ch == Constants.Ghost)
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
            for (int i = 0; i < Field.entities.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < Field.entities.GetUpperBound(0) + 1; j++)
                {
                    if (Field.entities[j, i].ch == Constants.RandomTeleport)
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
