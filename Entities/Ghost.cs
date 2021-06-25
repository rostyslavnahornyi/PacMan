using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_GUI_WPF
{
    enum Direction
    {
        LEFT,
        UP,
        RIGHT,
        DOWN,
    }
    class Ghost : Entity
    {
        public int x;
        public int y;
        public int queue;

        public string direction = "UP";
        public Entity previousCell = new Space();


        public static (int, int) Ghost1;
        public static (int, int) Ghost2;
        public static (int, int) Ghost3;

        public Ghost(int x, int y, int q)
        {
            this.x = x;
            this.y = y;
            queue = q;

            Passability = false;
            ch = Constants.Ghost;
        }

        public override string RandomizeNextDirection()
        {
            string toGo = null;

            Entity[] neighbourCells = { Field.entitiesArr[x - 1, y], Field.entitiesArr[x, y - 1], Field.entitiesArr[x + 1, y], Field.entitiesArr[x, y + 1] };
            List<string> possibleDirections = new List<string>();
            for (int i = 0; i < neighbourCells.Length; i++)
            {
                if (neighbourCells[i].Passability == true) 
                {
                    if (direction != (((Direction)(Math.Abs(i - 2))).ToString()))
                    {
                        possibleDirections.Add(((Direction)i).ToString());
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
            return toGo;
        }
    }
}
