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

        public static int x1 = 9;
        public static int y1 = 7;
        public static string direction1 = "U";
        public static char temp1 = ' ';

        public static int x2 = 10;
        public static int y2 = 7;
        public static string direction2 = "U";
        public static char temp2 = ' ';

        public static int x3 = 11;
        public static int y3 = 7;
        public static string direction3 = "U";
        public static char temp3 = ' ';

        private Random random = new Random();

        public override void Display()
        {
            Console.BackgroundColor = BG;
            Console.Write(ch);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(space);
        }

        public void e1()
        {
            while (Settings.MovingGhosts)
            {
                Moving(x1, y1, 1, direction1, temp1);
                Thread.Sleep(Settings.EnemySpeed);
            }
        }

        public void e2()
        {
            while (Settings.MovingGhosts)
            {
                Moving(x2, y2, 2, direction2, temp2);
                Thread.Sleep(Settings.EnemySpeed);
            }
        }

        public void e3()
        {
            while (Settings.MovingGhosts)
            {
                Moving(x3, y3, 3, direction3, temp3);
                Thread.Sleep(Settings.EnemySpeed);
            }
        }

        public void Moving(int x, int y, int q, string direction, char temp)
        {
            char[] directions = { Field.arr[x - 1, y], Field.arr[x + 1, y], Field.arr[x, y - 1], Field.arr[x, y + 1] };

            string[] ways = new string[2];
            string toGo = null;
            int wayIndex = 0;

            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] != Constants.Wall && directions[i] != Constants.Ghost && directions[i] != Constants.PacMan) // first
                {
                    if (i == 0 && direction != "R")
                    {
                        ways[wayIndex] = "L";
                        wayIndex++;

                    }
                    if (i == 1 && direction != "L")
                    {
                        ways[wayIndex] = "R";
                        wayIndex++;

                    }
                    if (i == 2 && direction != "D")
                    {
                        ways[wayIndex] = "U";
                        wayIndex++;

                    }
                    if (i == 3 && direction != "U")
                    {
                        ways[wayIndex] = "D";
                        wayIndex++;
                    }
                    if (wayIndex == 2)
                    {
                        break;
                    }
                }
            }

            if (ways[0] == null && ways[1] == null)
            {
                if ((directions[0] != Constants.Wall || directions[0] == Constants.PacMan) && direction == "R")
                {
                    if (directions[1] == Constants.PacMan)
                    {
                        Settings.MovingGhosts = false;
                        new End();
                    }
                    else
                    {
                        toGo = "L";
                    }
                }
                if ((directions[1] != Constants.Wall || directions[1] == Constants.PacMan) && direction == "L")
                {
                    if (directions[0] == Constants.PacMan)
                    {
                        Settings.MovingGhosts = false;
                        new End();
                    }
                    else
                    {
                        toGo = "R";
                    }
                }
                if ((directions[2] != Constants.Wall || directions[2] == Constants.PacMan) && direction == "D")
                {
                    if (directions[3] == Constants.PacMan)
                    {
                        Settings.MovingGhosts = false;
                        new End();
                    }
                    else
                    {
                        toGo = "U";
                    }
                }
                if ((directions[3] != Constants.Wall || directions[3] == Constants.PacMan) && direction == "U")
                {
                    if (directions[2] == Constants.PacMan)
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
            else if (ways[0] == null)
            {
                toGo = ways[1];
            }
            else if (ways[1] == null)
            {
                toGo = ways[0];
            }
            else
            {
                int randomValue = random.Next(2);
                toGo = ways[random.Next(2)];
            }



            if (toGo == "L" && Field.arr[x - 1, y] == 'A')
            {
                toGo = "stop";
            }
            if (toGo == "R" && Field.arr[x + 1, y] == 'A')
            {
                toGo = "stop";
            }
            if (toGo == "U" && Field.arr[x, y - 1] == 'A')
            {
                toGo = "stop";
            }
            if (toGo == "D" && Field.arr[x, y + 1] == 'A')
            {
                toGo = "stop";
            }

            direction = toGo;
            if (toGo == "L")
            {
                Field.arr[x, y] = temp;
                if (temp == Constants.RandomTeleport)
                {
                    Runner.Cell.UpdateCell(x, y, temp, ConsoleColor.DarkGreen);
                } else
                {
                    Runner.Cell.UpdateCell(x, y, temp, ConsoleColor.Black);
                }
                x--;
                if (Field.arr[x, y] == Constants.RandomTeleport)
                {
                    new RandomTeleport().Moving();
                    x = RandomTeleport.randomX;
                    y = RandomTeleport.randomY;
                    new Cell().UpdateCell(x, y, Constants.Ghost, ConsoleColor.DarkMagenta);
                } else
                {
                    Runner.Cell.UpdateCell(x, y, Constants.Ghost, ConsoleColor.DarkMagenta);
                }
                Field.arr[x, y] = Constants.Ghost;

                if (q == 1)
                {
                    x1--;
                    temp1 = Field.arr[x, y];
                    direction1 = "L";
                }
                if (q == 2)
                {
                    x2--;
                    temp2 = Field.arr[x, y];
                    direction2 = "L";
                }
                if (q == 3)
                {
                    x3--;
                    temp3 = Field.arr[x, y];
                    direction3 = "L";
                }
            }
            if (toGo == "R")
            {
                Field.arr[x, y] = temp;
                if (temp == Constants.RandomTeleport)
                {
                    Runner.Cell.UpdateCell(x, y, temp, ConsoleColor.DarkGreen);
                }
                else
                {
                    Runner.Cell.UpdateCell(x, y, temp, ConsoleColor.Black);
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
                Field.arr[x, y] = Constants.Ghost;

                if (q == 1)
                {
                    x1++;
                    temp1 = Field.arr[x, y];
                    direction1 = "R";
                }
                if (q == 2)
                {
                    x2++;
                    temp2 = Field.arr[x, y];
                    direction2 = "R";
                }
                if (q == 3)
                {
                    x3++;
                    temp3 = Field.arr[x, y];
                    direction3 = "R";
                }
            }
            if (toGo == "U")
            {
                Field.arr[x, y] = temp;
                if (temp == Constants.RandomTeleport)
                {
                    Runner.Cell.UpdateCell(x, y, temp, ConsoleColor.DarkGreen);
                }
                else
                {
                    Runner.Cell.UpdateCell(x, y, temp, ConsoleColor.Black);
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
                Field.arr[x, y] = Constants.Ghost;

                if (q == 1)
                {
                    y1--;
                    temp1 = Field.arr[x, y];
                    direction1 = "U";
                }
                if (q == 2)
                {
                    y2--;
                    temp2 = Field.arr[x, y];
                    direction2 = "U";
                }
                if (q == 3)
                {
                    y3--;
                    temp3 = Field.arr[x, y];
                    direction3 = "U";
                }
            }
            if (toGo == "D")
            {
                Field.arr[x, y] = temp;
                if (temp == Constants.RandomTeleport)
                {
                    Runner.Cell.UpdateCell(x, y, temp, ConsoleColor.DarkGreen);
                }
                else
                {
                    Runner.Cell.UpdateCell(x, y, temp, ConsoleColor.Black);
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
                Field.arr[x, y] = Constants.Ghost;

                if (q == 1)
                {
                    y1++;
                    temp1 = Field.arr[x, y];
                    direction1 = "D";
                }
                if (q == 2)
                {
                    y2++;
                    temp2 = Field.arr[x, y];
                    direction2 = "D";
                }
                if (q == 3)
                {
                    y3++;
                    temp3 = Field.arr[x, y];
                    direction3 = "D";
                }
            }
        }
    }
}
