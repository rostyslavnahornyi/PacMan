using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PacMan
{
    class Ghost : Entity
    {
        private int x;
        private int y;

        private string direction = "UP";
        private Entity cellUnderGhost = new Space();

        public Ghost(int x, int y)
        {
            ch = Constants.Ghost;
            Background = ConsoleColor.DarkMagenta;

            this.x = x;
            this.y = y;
        }
        public override void Print()
        {
            Console.BackgroundColor = Background;
            Console.Write(ch);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
        }

        private string RandomizeNextDirection()
        {

            string toGo = null;

            char[] neighbourCells = { Field.entities[x - 1, y].ch, Field.entities[x + 1, y].ch, Field.entities[x, y - 1].ch, Field.entities[x, y + 1].ch };
            List<string> possibleDirections = new List<string>();
            for (int i = 0; i < neighbourCells.Length; i++)
            {
                if (neighbourCells[i] != Constants.Wall && neighbourCells[i] != Constants.Ghost)
                {
                    if (i == 0 && direction != "RIGHT")
                    {
                        possibleDirections.Add("LEFT");
                    }
                    if (i == 1 && direction != "LEFT")
                    {
                        possibleDirections.Add("RIGHT");
                    }
                    if (i == 2 && direction != "DOWN")
                    {
                        possibleDirections.Add("UP");
                    }
                    if (i == 3 && direction != "UP")
                    {
                        possibleDirections.Add("DOWN");
                    }
                }
            }
            if (possibleDirections.Count == 0)
            {
                return toGo;
            }
            else
            {
                toGo = possibleDirections[Util.random.Next(possibleDirections.Count)];
                return toGo;
            }            
        }

        private void MovingTo(int X, int Y, string _direction)
        {
            if (cellUnderGhost.ch == Constants.RandomTeleport)
            {
                Renderer.UpdateCell(x, y, cellUnderGhost.ch, ConsoleColor.DarkGreen);
            }
            else
            {
                Renderer.UpdateCell(x, y, cellUnderGhost.ch, ConsoleColor.Black);
            }
            Field.entities[x, y] = cellUnderGhost;

            x += X;
            y += Y;

            if (Field.entities[x, y].ch == Constants.PacMan)
            {
                Settings.MovingGhosts = false;
                IntroScenes.End();
            }
            else if (Field.entities[x, y].ch == Constants.RandomTeleport)
            {
                new RandomTeleport().Loop();
                x = RandomTeleport.randomX;
                y = RandomTeleport.randomY;
                Renderer.UpdateCell(x, y, Constants.Ghost, ConsoleColor.DarkMagenta);
            }
            else
            {
                Renderer.UpdateCell(x, y, Constants.Ghost, ConsoleColor.DarkMagenta);
            }
            cellUnderGhost = Field.entities[x, y];
            Field.entities[x, y] = this;
            direction = _direction;
        }

        public override void Loop()
        {
            while (Settings.MovingGhosts)
            {
                lock (Util.locker)
                {
                    string toGo = RandomizeNextDirection();
                    direction = toGo;

                    if (toGo == "LEFT")
                    {
                        MovingTo(-1, 0, "LEFT");
                    }
                    if (toGo == "RIGHT")
                    {
                        MovingTo(1, 0, "RIGHT");
                    }
                    if (toGo == "UP")
                    {
                        MovingTo(0, -1, "UP");
                    }
                    if (toGo == "DOWN")
                    {
                        MovingTo(0, 1, "DOWN");
                    }
                }
                Thread.Sleep(Settings.EnemySpeed);
            }
        }
    }
}
