using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_GUI_WPF
{
    class Ghost : Entity
    {
        public int x;
        public int y;
        public int queue;

        public  string direction = "UP";
        public  Entity previousCell = new Space();

        public Ghost(int x, int y, int q)
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
                toGo = null;
            } else
            {
                toGo = possibleDirections[Util.random.Next(possibleDirections.Count)];
            }


            //string[] possibleDirections = new string[2];
            //int possibleDirectionsIndex = 0;

            //if (neighbourCells[0] != Constants.Wall && neighbourCells[0] != Constants.Ghost && direction != "RIGHT")
            //{
            //    possibleDirections[possibleDirectionsIndex] = "LEFT";
            //    possibleDirectionsIndex++;
            //}
            //if (neighbourCells[1] != Constants.Wall && neighbourCells[1] != Constants.Ghost && direction != "LEFT")
            //{
            //    possibleDirections[possibleDirectionsIndex] = "RIGHT";
            //    possibleDirectionsIndex++;
            //}
            //if (neighbourCells[2] != Constants.Wall && neighbourCells[2] != Constants.Ghost && direction != "DOWN")
            //{
            //    possibleDirections[possibleDirectionsIndex] = "UP";
            //    possibleDirectionsIndex++;
            //}
            //if (neighbourCells[3] != Constants.Wall && neighbourCells[3] != Constants.Ghost && direction != "UP")
            //{
            //    possibleDirections[possibleDirectionsIndex] = "DOWN";
            //}

            //if (possibleDirections[0] == null && possibleDirections[1] == null)
            //{
            //    if ((neighbourCells[0] != Constants.Wall || neighbourCells[0] == Constants.PacMan) && neighbourCells[0] != Constants.Ghost && direction == "RIGHT")
            //    {
            //        toGo = "LEFT";
            //    }
            //    if ((neighbourCells[1] != Constants.Wall || neighbourCells[1] == Constants.PacMan) && neighbourCells[1] != Constants.Ghost && direction == "LEFT")
            //    {
            //        toGo = "RIGHT";
            //    }
            //    if ((neighbourCells[2] != Constants.Wall || neighbourCells[2] == Constants.PacMan) && neighbourCells[2] != Constants.Ghost && direction == "DOWN")
            //    {
            //        toGo = "UP";
            //    }
            //    if ((neighbourCells[3] != Constants.Wall || neighbourCells[3] == Constants.PacMan) && neighbourCells[3] != Constants.Ghost && direction == "UP")
            //    {
            //        toGo = "DOWN";
            //    }
            //}
            //else if (possibleDirections[0] == null)
            //{
            //    toGo = possibleDirections[1];
            //}
            //else if (possibleDirections[1] == null)
            //{
            //    toGo = possibleDirections[0];
            //}
            //else
            //{
            //    toGo = possibleDirections[Util.random.Next(2)];
            //}

            return toGo;
        }
    }
}
