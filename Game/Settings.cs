﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_GUI_WPF
{
    class Settings
    {
        public static bool gameIsStarted = false;
        public static bool settingPoppupEnabled = false;
        public static bool FAQPoppupEnabled = false;

        public static bool hotkeysMovingArrows = true;
        public static bool hotkeysMovingWasd = false;

        public static int speedGhosts = 50;
        public static int attempts = 1;
    }
}
