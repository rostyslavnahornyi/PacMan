using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PacMan_GUI_WPF
{
    class Space : Entity
    {
        public static Brush Background = Brushes.Black;

        public Space()
        {
            ch = Constants.Space;
        }
    }
}
