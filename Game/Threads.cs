using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PacMan
{
    class Threads
    {
        public void ON()
        {
            int[] pacmanCoordinates = Field.FindPacmanCoordinates();
            int[][] ghostsCoordinates = Field.FindGhostsCoordinates();

            new Thread(Field.arr[pacmanCoordinates[1], pacmanCoordinates[0]].Loop).Start();
            new Thread(Field.arr[ghostsCoordinates[0][0], ghostsCoordinates[0][1]].Loop).Start();
            new Thread(Field.arr[ghostsCoordinates[2][0], ghostsCoordinates[2][1]].Loop).Start();
            new Thread(Field.arr[ghostsCoordinates[1][0], ghostsCoordinates[1][1]].Loop).Start();
        }
    }
}
