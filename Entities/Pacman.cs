using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PacMan_GUI_WPF
{
    class Pacman : Entity
    {
        public static int x;
        public static int y;

        public static bool goLeft, goRight, goDown, goUp; 

        public Pacman()
        {
            ch = Constants.PacMan;
        }

        

        
    }
}
