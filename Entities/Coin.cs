using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PacMan_GUI_WPF
{
    class Coin : Entity
    {
        public static int _Width;
        public static int _Height;
        public Coin()
        {
            ch = Constants.Coin;
            Passability = true;

            _Width = Width / 3;
            _Height = Height / 3;            
        }

        public static Brush Background = Brushes.Yellow;
    }
}
