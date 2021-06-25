using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PacMan_GUI_WPF
{
    class Threading
    {
        public static DispatcherTimer timer = new DispatcherTimer();
        public static DispatcherTimer randomWall = new DispatcherTimer();

        public static DispatcherTimer pacman = new DispatcherTimer();
        public static DispatcherTimer ghost1 = new DispatcherTimer();
        public static DispatcherTimer ghost2 = new DispatcherTimer();
        public static DispatcherTimer ghost3 = new DispatcherTimer();


        public static void Start()
        {            
            pacman.Interval = new TimeSpan(0, 0, 0, 0, 250);
            ghost1.Interval = new TimeSpan(0, 0, 0, 0, Settings.speedGhosts);
            ghost2.Interval = new TimeSpan(0, 0, 0, 0, Settings.speedGhosts);
            ghost3.Interval = new TimeSpan(0, 0, 0, 0, Settings.speedGhosts);
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            randomWall.Interval = new TimeSpan(0, 0, 0, 0, 3000);


            timer.Start();
            pacman.Start();
            ghost1.Start();
            ghost2.Start();
            ghost3.Start();
            randomWall.Start();
        }

        public static void Stop()
        {
            timer.Stop();
            pacman.Stop();
            ghost1.Stop();
            ghost2.Stop();
            ghost3.Stop();
            randomWall.Stop();
        }
    }
}
