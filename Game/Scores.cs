using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Scores : Field
    {
        public static int coins = 0;
        public static int MaxCoins = 0;

        public Scores()
        {
            for (int y = 0; y < arr.GetUpperBound(1) + 1; y++)
            {
                for (int x = 0; x < arr.GetUpperBound(0) + 1; x++)
                {
                    if (arr[x, y] == Constants.Coin) MaxCoins++;
                    if (arr[x, y] == Constants.BigCoin) MaxCoins += 3;
                }
            }
        }
    }
}
