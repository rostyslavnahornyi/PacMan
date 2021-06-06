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
            RandomTeleport RandomTeleport = new RandomTeleport();

            Thread pacman = new Thread(PacMan.Moving);
            pacman.Start();

            Thread enemy1 = new Thread(Ghosts.enemy1);
            Thread enemy2 = new Thread(Ghosts.enemy2);
            Thread enemy3 = new Thread(Ghosts.enemy3);
            enemy1.Start();
            enemy2.Start();
            enemy3.Start();

            Thread randomTeleport = new Thread(RandomTeleport.Create);
            randomTeleport.Start();
        }
    }
}
