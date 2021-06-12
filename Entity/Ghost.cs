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
            string[] possibleDirections = new string[2];
            int possibleDirectionsIndex = 0;

            if (neighbourCells[0] != Constants.Wall && neighbourCells[0] != Constants.Ghost && direction != "RIGHT")
            {
                possibleDirections[possibleDirectionsIndex] = "LEFT";
                possibleDirectionsIndex++;
            }
            if (neighbourCells[1] != Constants.Wall && neighbourCells[1] != Constants.Ghost && direction != "LEFT")
            {
                possibleDirections[possibleDirectionsIndex] = "RIGHT";
                possibleDirectionsIndex++;
            }
            if (neighbourCells[2] != Constants.Wall && neighbourCells[2] != Constants.Ghost && direction != "DOWN")
            {
                possibleDirections[possibleDirectionsIndex] = "UP";
                possibleDirectionsIndex++;
            }
            if (neighbourCells[3] != Constants.Wall && neighbourCells[3] != Constants.Ghost && direction != "UP")
            {
                possibleDirections[possibleDirectionsIndex] = "DOWN";
            }

            if (possibleDirections[0] == null && possibleDirections[1] == null)
            {
                if ((neighbourCells[0] != Constants.Wall || neighbourCells[0] == Constants.PacMan) && neighbourCells[0] != Constants.Ghost && direction == "RIGHT")
                {
                    toGo = "LEFT";
                }
                if ((neighbourCells[1] != Constants.Wall || neighbourCells[1] == Constants.PacMan) && neighbourCells[1] != Constants.Ghost && direction == "LEFT")
                {
                    toGo = "RIGHT";
                }
                if ((neighbourCells[2] != Constants.Wall || neighbourCells[2] == Constants.PacMan) && neighbourCells[2] != Constants.Ghost && direction == "DOWN")
                {
                    toGo = "UP";
                }
                if ((neighbourCells[3] != Constants.Wall || neighbourCells[3] == Constants.PacMan) && neighbourCells[3] != Constants.Ghost && direction == "UP")
                {
                    toGo = "DOWN";
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
                toGo = possibleDirections[Util.random.Next(2)];
            }

            return toGo;
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
