using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PacMan
{
    class Ghosts : FieldBuilder
    {
        private char ch = Constants.Ghost;
        private ConsoleColor BG = ConsoleColor.DarkMagenta;

        private static int x1Pos = 9;
        private static int y1Pos = 7;

        private static int x2Pos = 10;
        private static int y2Pos = 7;

        private static int x3Pos = 11;
        private static int y3Pos = 7;

        private static string direction1 = "U";
        private static string direction2 = "U";
        private static string direction3 = "U";


        private static char tempCell1 = Constants.Space;
        private static char tempCell2 = Constants.Space;
        private static char tempCell3 = Constants.Space;

        private Random random = new Random();

        public override void Display()
        {
            Console.BackgroundColor = BG;
            Console.Write(ch);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(space);
        }

        public void enemy1()
        {
            while (Settings.MovingGhosts)
            {
                Moving(x1Pos, y1Pos, 1, direction1, tempCell1);
                Thread.Sleep(Settings.EnemySpeed);
            }
        }

        public void enemy2()
        {
            while (Settings.MovingGhosts)
            {
                Moving(x2Pos, y2Pos, 2, direction2, tempCell2);
                Thread.Sleep(Settings.EnemySpeed);
            }
        }

        public void enemy3()
        {
            while (Settings.MovingGhosts)
            {
                Moving(x3Pos, y3Pos, 3, direction3, tempCell3);
                Thread.Sleep(Settings.EnemySpeed);
            }
        }

        public void Moving(int x, int y, int queue, string direction, char tempCell)
        {
            string toGo = null;


            char[] allDirections = { Field.arr[x - 1, y], Field.arr[x + 1, y], Field.arr[x, y - 1], Field.arr[x, y + 1] };
            string[] possibleDirections = new string[2];
            int possiblDirectionsIndex = 0;


            for (int i = 0; i < allDirections.Length; i++)
            {
                if (allDirections[i] != Constants.Wall && allDirections[i] != Constants.Ghost)
                {
                    if (i == 0 && direction != "R")
                    {
                        possibleDirections[possiblDirectionsIndex] = "L";
                        possiblDirectionsIndex++;

                    }
                    if (i == 1 && direction != "L")
                    {
                        possibleDirections[possiblDirectionsIndex] = "R";
                        possiblDirectionsIndex++;

                    }
                    if (i == 2 && direction != "D")
                    {
                        possibleDirections[possiblDirectionsIndex] = "U";
                        possiblDirectionsIndex++;

                    }
                    if (i == 3 && direction != "U")
                    {
                        possibleDirections[possiblDirectionsIndex] = "D";
                        possiblDirectionsIndex++;
                    }
                    if (possiblDirectionsIndex == 2)
                    {
                        break;
                    }
                }
            }

            if (possibleDirections[0] == null && possibleDirections[1] == null)
            {
                if ((allDirections[0] != Constants.Wall || allDirections[0] == Constants.PacMan) && direction == "R")
                {
                    if (allDirections[1] == Constants.PacMan)
                    {
                        Settings.MovingGhosts = false;
                        new End();
                    }
                    else
                    {
                        toGo = "L";
                    }
                }
                if ((allDirections[1] != Constants.Wall || allDirections[1] == Constants.PacMan) && direction == "L")
                {
                    if (allDirections[0] == Constants.PacMan)
                    {
                        Settings.MovingGhosts = false;
                        new End();
                    }
                    else
                    {
                        toGo = "R";
                    }
                }
                if ((allDirections[2] != Constants.Wall || allDirections[2] == Constants.PacMan) && direction == "D")
                {
                    if (allDirections[3] == Constants.PacMan)
                    {
                        Settings.MovingGhosts = false;
                        new End();
                    }
                    else
                    {
                        toGo = "U";
                    }
                }
                if ((allDirections[3] != Constants.Wall || allDirections[3] == Constants.PacMan) && direction == "U")
                {
                    if (allDirections[2] == Constants.PacMan)
                    {
                        Settings.MovingGhosts = false;
                        new End();
                    }
                    else
                    {
                        toGo = "D";
                    }
                }
            }
            else if (possibleDirections[0] == null)
            {
                toGo = possibleDirections[1];
            }
            else if (possibleDirections[1] == null)
            {
                toGo = possibleDirections[0];
            }
            else
            {
                toGo = possibleDirections[random.Next(2)];
            }

            direction = toGo;
            if (toGo == "L")
            {
                Field.arr[x, y] = tempCell;
                if (tempCell == Constants.RandomTeleport)
                {
                    Runner.Cell.UpdateCell(x, y, tempCell, ConsoleColor.DarkGreen);
                } else
                {
                    Runner.Cell.UpdateCell(x, y, tempCell, ConsoleColor.Black);
                }

                x--;

                if (Field.arr[x, y] == Constants.PacMan)
                {
                    Settings.MovingGhosts = false;
                    new End();
                }
                else if (Field.arr[x, y] == Constants.RandomTeleport)
                {
                    new RandomTeleport().Moving();
                    x = RandomTeleport.randomX;
                    y = RandomTeleport.randomY;
                    new Cell().UpdateCell(x, y, Constants.Ghost, ConsoleColor.DarkMagenta);
                } else
                {
                    Runner.Cell.UpdateCell(x, y, Constants.Ghost, ConsoleColor.DarkMagenta);
                }

                if (queue == 1)
                {
                    x1Pos--;
                    tempCell1 = Field.arr[x, y];
                    direction1 = "L";
                }
                if (queue == 2)
                {
                    x2Pos--;
                    tempCell2 = Field.arr[x, y];
                    direction2 = "L";
                }
                if (queue == 3)
                {
                    x3Pos--;
                    tempCell3 = Field.arr[x, y];
                    direction3 = "L";
                }
            }
            if (toGo == "R")
            {
                Field.arr[x, y] = tempCell;
                if (Field.arr[x, y] == Constants.PacMan)
                {
                    Settings.MovingGhosts = false;
                    new End();
                }
                else if (tempCell == Constants.RandomTeleport)
                {
                    Runner.Cell.UpdateCell(x, y, tempCell, ConsoleColor.DarkGreen);
                }
                else
                {
                    Runner.Cell.UpdateCell(x, y, tempCell, ConsoleColor.Black);
                }

                x++;

                if (Field.arr[x, y] == Constants.RandomTeleport)
                {
                    new RandomTeleport().Moving();
                    x = RandomTeleport.randomX;
                    y = RandomTeleport.randomY;
                    new Cell().UpdateCell(x, y, Constants.Ghost, ConsoleColor.DarkMagenta);
                }
                else
                {
                    Runner.Cell.UpdateCell(x, y, Constants.Ghost, ConsoleColor.DarkMagenta);
                }

                if (queue == 1)
                {
                    x1Pos++;
                    tempCell1 = Field.arr[x, y];
                    direction1 = "R";
                }
                if (queue == 2)
                {
                    x2Pos++;
                    tempCell2 = Field.arr[x, y];
                    direction2 = "R";
                }
                if (queue == 3)
                {
                    x3Pos++;
                    tempCell3 = Field.arr[x, y];
                    direction3 = "R";
                }
            }
            if (toGo == "U")
            {
                Field.arr[x, y] = tempCell;
                if (Field.arr[x, y] == Constants.PacMan)
                {
                    Settings.MovingGhosts = false;
                    new End();
                }
                else if (tempCell == Constants.RandomTeleport)
                {
                    Runner.Cell.UpdateCell(x, y, tempCell, ConsoleColor.DarkGreen);
                }
                else
                {
                    Runner.Cell.UpdateCell(x, y, tempCell, ConsoleColor.Black);
                }

                y--;

                if (Field.arr[x, y] == Constants.RandomTeleport)
                {
                    new RandomTeleport().Moving();
                    x = RandomTeleport.randomX;
                    y = RandomTeleport.randomY;
                    new Cell().UpdateCell(x, y, Constants.Ghost, ConsoleColor.DarkMagenta);
                }
                else
                {
                    Runner.Cell.UpdateCell(x, y, Constants.Ghost, ConsoleColor.DarkMagenta);
                }

                if (queue == 1)
                {
                    y1Pos--;
                    tempCell1 = Field.arr[x, y];
                    direction1 = "U";
                }
                if (queue == 2)
                {
                    y2Pos--;
                    tempCell2 = Field.arr[x, y];
                    direction2 = "U";
                }
                if (queue == 3)
                {
                    y3Pos--;
                    tempCell3 = Field.arr[x, y];
                    direction3 = "U";
                }
            }
            if (toGo == "D")
            {
                Field.arr[x, y] = tempCell;
                if (Field.arr[x, y] == Constants.PacMan)
                {
                    Settings.MovingGhosts = false;
                    new End();
                }
                else if (tempCell == Constants.RandomTeleport)
                {
                    Runner.Cell.UpdateCell(x, y, tempCell, ConsoleColor.DarkGreen);
                }
                else
                {
                    Runner.Cell.UpdateCell(x, y, tempCell, ConsoleColor.Black);
                }

                y++;

                if (Field.arr[x, y] == Constants.RandomTeleport)
                {
                    new RandomTeleport().Moving();
                    x = RandomTeleport.randomX;
                    y = RandomTeleport.randomY;
                    new Cell().UpdateCell(x, y, Constants.Ghost, ConsoleColor.DarkMagenta);
                }
                else
                {
                    Runner.Cell.UpdateCell(x, y, Constants.Ghost, ConsoleColor.DarkMagenta);
                }

                if (queue == 1)
                {
                    y1Pos++;
                    tempCell1 = Field.arr[x, y];
                    direction1 = "D";
                }
                if (queue == 2)
                {
                    y2Pos++;
                    tempCell2 = Field.arr[x, y];
                    direction2 = "D";
                }
                if (queue == 3)
                {
                    y3Pos++;
                    tempCell3 = Field.arr[x, y];
                    direction3 = "D";
                }
            }
        }
    }
}
