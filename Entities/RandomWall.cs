using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PacMan_GUI_WPF
{
    class RandomWall : Entity
    {
        public static int Stroke = 2;
        public static Brush StrokeBackground = Brushes.Gray;

        public RandomWall()
        {
            Passability = false;
            ch = Constants.RandomWall;
        }
    }
}
