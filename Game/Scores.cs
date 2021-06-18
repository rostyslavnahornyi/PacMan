using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PacMan_GUI_WPF
{
    class Scores
    {
        public static int allCoins = 0;
        public static int currentCoins = 0;
        public static int steps = 0;

        public static int secondsTimer;
        public static int minutesTimer;

        Canvas canvas;
        public Scores(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public static void FindAllCoins()
        {
            steps = 0;
            allCoins = 0;
            currentCoins = 0;
            for (int y = 0; y < Field.entitiesArr.GetUpperBound(1) + 1; y++)
            {
                for (int x = 0; x < Field.entitiesArr.GetUpperBound(0) + 1; x++)
                {
                    if (Field.entitiesArr[x, y].ch == Constants.Coin) allCoins++;
                }
            }
        }

        public void UpdateScores()
        {
            
        }
    }
}
