using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PacMan
{
    class Enemy : Field
    {

        private static int x = 10;
        private static int y = 7;

        private Random random = new Random();

        public void MovingMain()
        {
            string direction = "U"; // RIGHT LEFT UP DOWN - R L U D
            char temp = ' ';
            
            while (Settings.Flag)
            {
                char[] directions = { arr[x - 1, y], arr[x + 1, y], arr[x, y - 1], arr[x, y + 1] }; // left right up down

                string[] ways = new string[2];
                string toGo;
                int wayIndex = 0;

                for (int i = 0; i < directions.Length; i++)
                {
                    if (directions[i] == '.' || directions[i] == 'o' || directions[i] == ' ') // first
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
                if (ways[0] == null)
                {
                    toGo = ways[1];
                }
                else if (ways[1] == null)
                {
                    toGo = ways[0];
                }
                else if (ways[0] == null && ways[1] == null)
                {
                    toGo = "stop";
                } 
                else {
                    int randomValue = random.Next(2);
                    toGo = ways[random.Next(2)];
                }

                if (toGo == "L" && arr[x - 1, y] == 'A')
                {
                    toGo = "stop";
                }
                if (toGo == "R" && arr[x + 1, y] == 'A')
                {
                    toGo = "stop";
                }
                if (toGo == "U" && arr[x, y - 1] == 'A')
                {
                    toGo = "stop";
                }
                if (toGo == "D" && arr[x, y + 1] == 'A')
                {
                    toGo = "stop";
                }
                //////
                if (toGo == "L" && arr[x - 1, y] == '@')
                {
                    new End();
                }
                if (toGo == "R" && arr[x + 1, y] == '@')
                {
                    new End();
                }
                if (toGo == "U" && arr[x, y - 1] == '@')
                {
                    new End();
                }
                if (toGo == "D" && arr[x, y + 1] == '@')
                {
                    new End();
                }

                direction = toGo;

                if (toGo == "L")
                {
                    // first
                    arr[x, y] = temp;
                    Console.SetCursorPosition(x * 3, y);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(temp);
                    x--;
                    Console.SetCursorPosition(x * 3, y);
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("A");
                    temp = arr[x, y];
                    arr[x, y] = 'A';
                }
                if (toGo == "R")
                {
                    arr[x, y] = temp;
                    // first
                    Console.SetCursorPosition(x * 3, y);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(temp);
                    x++;
                    Console.SetCursorPosition(x * 3, y);
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("A");
                    temp = arr[x, y];
                    arr[x, y] = 'A';
                }
                if (toGo == "U")
                {
                    arr[x, y] = temp;
                    // first
                    Console.SetCursorPosition(x * 3, y);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(temp);
                    y--;
                    Console.SetCursorPosition(x * 3, y);
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("A");
                    temp = arr[x, y];
                    arr[x, y] = 'A';
                }
                if (toGo == "D")
                {
                    arr[x, y] = temp;
                    // first
                    Console.SetCursorPosition(x * 3, y);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(temp);
                    y++;
                    Console.SetCursorPosition(x * 3, y);
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("A");
                    temp = arr[x, y];
                    arr[x, y] = 'A';
                }


                Thread.Sleep(Settings.EnemySpeed);
            }
        }

    }
}
