using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PacMan
{
    class RandomTeleport
    {
        private int Width = Field.arr.GetUpperBound(0) + 1;
        private int Height = Field.arr.GetUpperBound(1) + 1;

        public bool TeleportRandom = true;
        public static int randomX;
        public static int randomY;
        public static char tempCell;

        private Random random = new Random();

        public void Create()
        {
            while (TeleportRandom)
            {
                int x;
                int y;
                for (; ;)
                {
                    x = random.Next(Width);
                    y = random.Next(Height);
                    if (Field.arr[x, y] != Constants.RandomTeleport && Field.arr[x, y] != Constants.PacMan && Field.arr[x, y] != Constants.Ghost && Field.arr[x, y] != Constants.Wall)
                    {
                        break;
                    }
                }
                tempCell = Field.arr[x, y];
                Field.arr[x, y] = Constants.RandomTeleport;
                Settings.RandomTeleportTimes--;
                new Cell().UpdateCell(x, y, Constants.RandomTeleport, ConsoleColor.DarkGreen);

                
                Thread.Sleep(Settings.RandomTeleportRespawnTime);
                Field.arr[x, y] = tempCell;
                new Cell().UpdateCell(x, y, tempCell, ConsoleColor.Black);

                if (Settings.RandomTeleportTimes == 0) TeleportRandom = false;
            }
        }

        public void Moving()
        {
            for (; ; )
            {
                randomX = random.Next(Width);
                randomY = random.Next(Height);
                if (Field.arr[randomX, randomY] != Constants.PacMan && Field.arr[randomX, randomY] != Constants.Ghost && Field.arr[randomX, randomY] != Constants.Wall)
                {
                    break;
                }
            }
        }

        
    }
}
