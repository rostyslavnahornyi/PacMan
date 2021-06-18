using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PacMan
{
    class RandomTeleport : Entity
    {
        private int Width = Field.entities.GetUpperBound(0) + 1;
        private int Height = Field.entities.GetUpperBound(1) + 1;

        public bool TeleportRandom = true;
        public static int randomX;
        public static int randomY;
        public static char cellUnderTeleport;

        public RandomTeleport()
        {
            ch = Constants.RandomTeleport;
            Background = ConsoleColor.DarkGreen;
        }

        public override void Print()
        {
            while (TeleportRandom)
            {
                int x;
                int y;
                for (; ;)
                {
                    x = Util.random.Next(Width);
                    y = Util.random.Next(Height);
                    if (Field.entities[x, y].ch != Constants.RandomTeleport && Field.entities[x, y].ch != Constants.PacMan && Field.entities[x, y].ch != Constants.Ghost && Field.entities[x, y].ch != Constants.Wall)
                    {
                        break;
                    }
                }
                cellUnderTeleport = Field.entities[x, y].ch;
                Field.entities[x, y].ch = Constants.RandomTeleport;
                Settings.RandomTeleportTimes--;
                Renderer.UpdateCell(x, y, Constants.RandomTeleport, ConsoleColor.DarkGreen);

                
                Thread.Sleep(Settings.RandomTeleportRespawnTime);
                Field.entities[x, y].ch = cellUnderTeleport;
                Renderer.UpdateCell(x, y, cellUnderTeleport, ConsoleColor.Black);

                if (Settings.RandomTeleportTimes == 0) TeleportRandom = false;
            }
        }

        public override void Loop()
        {
            for (; ; )
            {
                randomX = Util.random.Next(Width);
                randomY = Util.random.Next(Height);
                if (Field.entities[randomX, randomY].ch != Constants.PacMan && Field.entities[randomX, randomY].ch != Constants.Ghost && Field.entities[randomX, randomY].ch != Constants.Wall)
                {
                    break;
                }
            }
        }        
    }
}
