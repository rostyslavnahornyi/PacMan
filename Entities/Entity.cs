using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PacMan_GUI_WPF
{
    abstract class Entity
    {
        public static int Width = 15;
        public static int Height = 15;

        public char ch;
        public bool Passability;

        public virtual void Loop() { }
        public virtual string RandomizeNextDirection() { return null; }
    }
}
