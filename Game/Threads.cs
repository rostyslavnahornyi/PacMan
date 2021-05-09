using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PacMan
{
    class Threads
    {
        public Threads()
        {
            PacMan PacMan = new PacMan();
            Ghosts Ghosts = new Ghosts();

            Thread pacman = new Thread(PacMan.Moving);
            pacman.Start();

            Thread enemy1 = new Thread(Ghosts.e1);
            Thread enemy2 = new Thread(Ghosts.e2);
            Thread enemy3 = new Thread(Ghosts.e3);
            enemy1.Start();
            enemy2.Start();
            enemy3.Start();
        }
    }
}
