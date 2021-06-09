using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Util
    {
        public static object locker = new object();
        public static Random random = new Random();
    }
}