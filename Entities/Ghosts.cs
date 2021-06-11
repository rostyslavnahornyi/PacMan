using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_GUI_WPF
{
    class Ghosts : Entity
    {
        public int x;
        public int y;
        public int queue;

        public  string direction = "UP";
        public  Entity tempCell = new Space();

        //public static int x2 = 24;
        //public static int y2 = 17;

        //public static string direction2 = "UP";
        //public static Entity tempCell2 = new Space();

        //public static int x3 = 25;
        //public static int y3 = 17;

        //public static string direction3 = "UP";
        //public static Entity tempCell3 = new Space();


        public Ghosts(int x, int y, int q)
        {
            this.x = x;
            this.y = y;
            queue = q;
            ch = Constants.Ghost;
        }

        public override string RandomizeNextDirection()
        {
            string toGo = null;

            char[] neighbourCells = { Field.entitiesArr[x - 1, y].ch, Field.entitiesArr[x + 1, y].ch, Field.entitiesArr[x, y - 1].ch, Field.entitiesArr[x, y + 1].ch };
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
    }
}
