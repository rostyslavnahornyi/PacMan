using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    abstract class Entity
    {
        public char ch;
        public ConsoleColor Background;

        public abstract void Print();
        public virtual void Loop()
        {

        }
    }
}
