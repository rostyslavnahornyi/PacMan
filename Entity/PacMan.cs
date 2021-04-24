using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PacMan
{
    class PacMan : Field
    {

        private static int x;
        private static int y;

        private static string direction = "STOP";

        public void EntityPacman()
        {
            for (int i = 0; i < arr.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < arr.GetUpperBound(0) + 1; j++)
                {
                    if (arr[j, i] == '@')
                    {
                        x = j;
                        y = i;
                    }
                    if (arr[j, i] == '.') Scores.scoresMax++;
                    if (arr[j, i] == 'o') Scores.scoresMax += 3;
                }
            }

            Thread Changeable = new Thread(ChangeableMoving);
            Thread Constantly = new Thread(ConstantlyMoving);
            Changeable.Start();
            Constantly.Start();
        }

        private static void ChangeableMoving()
        {
            while (Settings.Flag)
            {
                if (Console.KeyAvailable)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow && direction != "LEFT") 
                    {
                        if (arr[x - 1, y] == 'A')
                        {
                            direction = "stop";
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            x--;
                            Console.SetCursorPosition(x * 3, y);

                            for (int i = 0; i < 2; i++)
                            {
                                Console.SetCursorPosition(x * 3, y);
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write('<');
                                Thread.Sleep(500);
                                Console.SetCursorPosition(x * 3, y);
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write('<');
                                Thread.Sleep(500);
                            }
                            arr[x, y] = '@';
                            
                            if (Scores.lifes != 1)
                            {
                                Scores.lifes--;
                            } else
                            {
                                new End();
                            }
                        }
                        else if (arr[x - 1, y] == '.')
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            x--;
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('<');
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = '@';
                            Scores.scores++;
                            new DisplayInfo().displayScore();
                            if (Scores.scores == Scores.scoresMax)
                            {
                                new Win();
                            }
                        }
                        else if (arr[x - 1, y] == 'o')
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            x--;
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('<');
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = '@';
                            Scores.scores += 3;
                            new DisplayInfo().displayScore();
                            if (Scores.scores == Scores.scoresMax)
                            {
                                new Win();
                            }
                        }
                        else if (arr[x - 1, y] == ' ')
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            x--;
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('<');
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = '@';
                        }
                        direction = "LEFT";
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write('<');
                    } else if (key.Key == ConsoleKey.LeftArrow){
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write('<');
                    }
                    if (key.Key == ConsoleKey.RightArrow && direction != "RIGHT")
                    {
                        if (arr[x + 1, y] == 'A')
                        {
                            direction = "stop";
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            x++;
                            Console.SetCursorPosition(x * 3, y);

                            for (int i = 0; i < 2; i++)
                            {
                                Console.SetCursorPosition(x * 3, y);
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write('>');
                                Thread.Sleep(500);
                                Console.SetCursorPosition(x * 3, y);
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write('>');
                                Thread.Sleep(500);
                            }
                            arr[x, y] = '@';

                            if (Scores.lifes != 1)
                            {
                                Scores.lifes--;
                            }
                            else
                            {
                                new End();
                            }
                        }
                        else if (arr[x + 1, y] == '.')
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            x++;
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('>');
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = '@';
                            Scores.scores++;
                            new DisplayInfo().displayScore();
                            if (Scores.scores == Scores.scoresMax)
                            {
                                new Win();
                            }
                        } else if (arr[x + 1, y] == 'o')
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            x++;
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('>');
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = '@';
                            Scores.scores += 3;
                            new DisplayInfo().displayScore();
                            if (Scores.scores == Scores.scoresMax)
                            {
                                new Win();
                            }
                        }
                        if (arr[x + 1, y] == ' ')
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            x++;
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('>');
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = '@';
                        }
                        direction = "RIGHT";
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write('>');
                    }
                    else if (key.Key == ConsoleKey.RightArrow){
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write('>');
                    }
                    if (key.Key == ConsoleKey.UpArrow && direction != "UP")
                    {
                        if (arr[x, y - 1] == 'A')
                        {
                            direction = "stop";
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            y--;
                            Console.SetCursorPosition(x * 3, y);

                            for (int i = 0; i < 2; i++)
                            {
                                Console.SetCursorPosition(x * 3, y);
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write('^');
                                Thread.Sleep(500);
                                Console.SetCursorPosition(x * 3, y);
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write('^');
                                Thread.Sleep(500);
                            }
                            arr[x, y] = '@';

                            if (Scores.lifes != 1)
                            {
                                Scores.lifes--;
                            }
                            else
                            {
                                new End();
                            }
                        } else if (arr[x, y - 1] == '.')
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            y--;
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('^');
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = '@';
                            Scores.scores++;
                            new DisplayInfo().displayScore();
                            if (Scores.scores == Scores.scoresMax)
                            {
                                new Win();
                            }
                        } else if (arr[x, y - 1] == 'o')
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            y--;
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('^');
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = '@';
                            Scores.scores += 3;
                            new DisplayInfo().displayScore();
                            if (Scores.scores == Scores.scoresMax)
                            {
                                new Win();
                            }
                        } else if (arr[x, y - 1] == ' ')
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            y--;
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write('^');
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = '@';
                        }
                        direction = "UP";
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write('^');
                    }
                    else if (key.Key == ConsoleKey.UpArrow){
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write('^');
                    }
                    if (key.Key == ConsoleKey.DownArrow && direction != "DOWN")
                    {
                        if (arr[x, y + 1] == 'A')
                        {
                            direction = "stop";
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            y++;
                            Console.SetCursorPosition(x * 3, y);

                            for (int i = 0; i < 2; i++)
                            {
                                Console.SetCursorPosition(x * 3, y);
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write('↓');
                                Thread.Sleep(500);
                                Console.SetCursorPosition(x * 3, y);
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write('↓');
                                Thread.Sleep(500);
                            }
                            arr[x, y] = '@';

                            if (Scores.lifes != 1)
                            {
                                Scores.lifes--;
                            }
                            else
                            {
                                new End();
                            }
                        }
                        else if (arr[x, y + 1] == '.')
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            y++;
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('↓');
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = '@';
                            Scores.scores++;
                            new DisplayInfo().displayScore();
                            if (Scores.scores == Scores.scoresMax)
                            {
                                new Win();
                            }
                        } else if (arr[x, y + 1] == 'o')
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            y++;
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('↓');
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = '@';
                            Scores.scores += 3;
                            new DisplayInfo().displayScore();
                            if (Scores.scores == Scores.scoresMax)
                            {
                                new Win();
                            }
                        } else if (arr[x, y + 1] == ' ')
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.Write(" ");
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = ' ';
                            y++;
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('↓');
                            Console.SetCursorPosition(x * 3, y);
                            arr[x, y] = '@';
                        }
                        direction = "DOWN";
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write('↓');
                    }
                    else if (key.Key == ConsoleKey.DownArrow){
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write('↓');
                    }
                }
                
            }

        }

        private static void ConstantlyMoving()
        {
            while (Settings.Flag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                if (direction == "LEFT")
                {
                    if (arr[x - 1, y] == 'A')
                    {
                        direction = "stop";
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        x--;
                        Console.SetCursorPosition(x * 3, y);

                        for (int i = 0; i < 2; i++)
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write('<');
                            Thread.Sleep(500);
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('<');
                            Thread.Sleep(500);
                        }
                        arr[x, y] = '@';

                        if (Scores.lifes != 1)
                        {
                            Scores.lifes--;
                        }
                        else
                        {
                            new End();
                        }
                    }
                    else if (arr[x - 1, y] == '.')
                    {
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        x--;
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('<');
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = '@';
                        Scores.scores++;
                        new DisplayInfo().displayScore();
                        if (Scores.scores == Scores.scoresMax)
                        {
                            new Win();
                        }
                    }
                    else if (arr[x - 1, y] == 'o')
                    {
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        x--;
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('<');
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = '@';
                        Scores.scores += 3;
                        new DisplayInfo().displayScore();
                        if (Scores.scores == Scores.scoresMax)
                        {
                            new Win();
                        }
                    }
                    else if (arr[x - 1, y] == ' ')
                    {
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        x--;
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('<');
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = '@';
                    }
                    direction = "LEFT";
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(x * 3, y);
                    Console.Write('<');
                }
                if (direction == "RIGHT")
                {
                    if (arr[x + 1, y] == 'A')
                    {
                        direction = "stop";
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        x++;
                        Console.SetCursorPosition(x * 3, y);

                        for (int i = 0; i < 2; i++)
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write('>');
                            Thread.Sleep(500);
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('>');
                            Thread.Sleep(500);
                        }
                        arr[x, y] = '@';

                        if (Scores.lifes != 1)
                        {
                            Scores.lifes--;
                        }
                        else
                        {
                            new End();
                        }
                    }
                    else if (arr[x + 1, y] == '.')
                    {
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        x++;
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('>');
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = '@';
                        Scores.scores++;
                        new DisplayInfo().displayScore();
                        if (Scores.scores == Scores.scoresMax)
                        {
                            new Win();
                        }
                    }
                    else if (arr[x + 1, y] == 'o')
                    {
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        x++;
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('>');
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = '@';
                        Scores.scores += 3;
                        new DisplayInfo().displayScore();
                        if (Scores.scores == Scores.scoresMax)
                        {
                            new Win();
                        }
                    }
                    if (arr[x + 1, y] == ' ')
                    {
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        x++;
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('>');
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = '@';
                    }
                    direction = "RIGHT";
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(x * 3, y);
                    Console.Write('>');
                }
                if (direction == "UP")
                {
                    if (arr[x, y - 1] == 'A')
                    {
                        direction = "stop";
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        y--;
                        Console.SetCursorPosition(x * 3, y);

                        for (int i = 0; i < 2; i++)
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write('^');
                            Thread.Sleep(500);
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('^');
                            Thread.Sleep(500);
                        }
                        arr[x, y] = '@';

                        if (Scores.lifes != 1)
                        {
                            Scores.lifes--;
                        }
                        else
                        {
                            new End();
                        }
                    }
                    else if (arr[x, y - 1] == '.')
                    {
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        y--;
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('^');
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = '@';
                        Scores.scores++;
                        new DisplayInfo().displayScore();
                        if (Scores.scores == Scores.scoresMax)
                        {
                            new Win();
                        }
                    }
                    else if (arr[x, y - 1] == 'o')
                    {
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        y--;
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('^');
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = '@';
                        Scores.scores += 3;
                        new DisplayInfo().displayScore();
                        if (Scores.scores == Scores.scoresMax)
                        {
                            new Win();
                        }
                    }
                    else if (arr[x, y - 1] == ' ')
                    {
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        y--;
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write('^');
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = '@';
                    }
                    direction = "UP";
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(x * 3, y);
                    Console.Write('^');
                }
                if (direction == "DOWN")
                {
                    if (arr[x, y + 1] == 'A')
                    {
                        direction = "stop";
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        y++;
                        Console.SetCursorPosition(x * 3, y);

                        for (int i = 0; i < 2; i++)
                        {
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write('↓');
                            Thread.Sleep(500);
                            Console.SetCursorPosition(x * 3, y);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('↓');
                            Thread.Sleep(500);
                        }
                        arr[x, y] = '@';

                        if (Scores.lifes != 1)
                        {
                            Scores.lifes--;
                        }
                        else
                        {
                            new End();
                        }
                    }
                    else if (arr[x, y + 1] == '.')
                    {
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        y++;
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('↓');
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = '@';
                        Scores.scores++;
                        new DisplayInfo().displayScore();
                        if (Scores.scores == Scores.scoresMax)
                        {
                            new Win();
                        }
                    }
                    else if (arr[x, y + 1] == 'o')
                    {
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        y++;
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('↓');
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        Scores.scores += 3;
                        new DisplayInfo().displayScore();
                        if (Scores.scores == Scores.scoresMax)
                        {
                            new Win();
                        }
                    }
                    else if (arr[x, y + 1] == ' ')
                    {
                        Console.SetCursorPosition(x * 3, y);
                        Console.Write(" ");
                        Console.SetCursorPosition(x * 3, y);
                        arr[x, y] = ' ';
                        y++;
                        Console.SetCursorPosition(x * 3, y);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('↓');
                        Console.SetCursorPosition(x * 3, y);
                    }
                    direction = "DOWN";
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(x * 3, y);
                    Console.Write('↓');
                }
                Thread.Sleep(Settings.PacManSpeed);
            }
        }
    }
}
