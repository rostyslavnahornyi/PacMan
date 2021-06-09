using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Scores
    {
        public static int coins = 0;
        public static int MaxCoins = 0;

        public void FindAllCoins()
        {
            for (int y = 0; y < Field.arr.GetUpperBound(1) + 1; y++)
            {
                for (int x = 0; x < Field.arr.GetUpperBound(0) + 1; x++)
                {
                    if (Field.arr[x, y].ch == Constants.Coin) MaxCoins++;
                    if (Field.arr[x, y].ch == Constants.BigCoin) MaxCoins += 3;
                }
            }
        }
    }
}
