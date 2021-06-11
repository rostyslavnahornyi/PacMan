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
        public static DispatcherTimer pacman = new DispatcherTimer();
        public static DispatcherTimer ghost1 = new DispatcherTimer();
        public static DispatcherTimer ghost2 = new DispatcherTimer();
        public static DispatcherTimer ghost3 = new DispatcherTimer();


        public static void Start()
        {            
            pacman.Interval = new TimeSpan(0, 0, 0, 0, 250);
            ghost1.Interval = new TimeSpan(0, 0, 0, 0, 350);
            ghost2.Interval = new TimeSpan(0, 0, 0, 0, 350);
            ghost3.Interval = new TimeSpan(0, 0, 0, 0, 350);
            pacman.Start();
            ghost1.Start();
            ghost2.Start();
            ghost3.Start();

        }

        public static void Stop()
        {
            pacman.Stop();
            ghost1.Stop();
            ghost2.Stop();
            ghost3.Stop();
        }
    }
}
