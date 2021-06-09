using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PacMan
{
    class RandomTeleport : Entity
    {
        private int Width = Field.arr.GetUpperBound(0) + 1;
        private int Height = Field.arr.GetUpperBound(1) + 1;

        public bool TeleportRandom = true;
        public static int randomX;
        public static int randomY;
        public static char tempCell;

        public RandomTeleport()
        {
            ch = Constants.RandomTeleport;
            Background = ConsoleColor.DarkGreen;
        }

        public override void Display()
        {
            while (TeleportRandom)
            {
                int x;
                int y;
                for (; ;)
                {
                    x = Util.random.Next(Width);
                    y = Util.random.Next(Height);
                    if (Field.arr[x, y].ch != Constants.RandomTeleport && Field.arr[x, y].ch != Constants.PacMan && Field.arr[x, y].ch != Constants.Ghost && Field.arr[x, y].ch != Constants.Wall)
                    {
                        break;
                    }
                }
                tempCell = Field.arr[x, y].ch;
                Field.arr[x, y].ch = Constants.RandomTeleport;
                Settings.RandomTeleportTimes--;
                Renderer.UpdateCell(x, y, Constants.RandomTeleport, ConsoleColor.DarkGreen);

                
                Thread.Sleep(Settings.RandomTeleportRespawnTime);
                Field.arr[x, y].ch = tempCell;
                Renderer.UpdateCell(x, y, tempCell, ConsoleColor.Black);

                if (Settings.RandomTeleportTimes == 0) TeleportRandom = false;
            }
        }

        public override void Loop()
        {
            for (; ; )
            {
                randomX = Util.random.Next(Width);
                randomY = Util.random.Next(Height);
                if (Field.arr[randomX, randomY].ch != Constants.PacMan && Field.arr[randomX, randomY].ch != Constants.Ghost && Field.arr[randomX, randomY].ch != Constants.Wall)
                {
                    break;
                }
            }
        }

        
    }
}
