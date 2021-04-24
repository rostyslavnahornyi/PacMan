using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PacMan
{
    class Threads
    {
        private static PacMan pacman = new PacMan();
        private static Enemy enemy = new Enemy();

        public Threads()
        {
            Main();
        }

        private void Main()
        {
            Thread first = new Thread(pacman.EntityPacman);
            Thread second = new Thread(enemy.EntityEnemy);
            first.Start();
            second.Start();
        }
    }
}
