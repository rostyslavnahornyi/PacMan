using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    abstract class FieldBuilder
    {
        public string space = "  ";
        public abstract void Display();
    }
}
