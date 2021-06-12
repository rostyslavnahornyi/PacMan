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
            for (int y = 0; y < Field.entities.GetUpperBound(1) + 1; y++)
            {
                for (int x = 0; x < Field.entities.GetUpperBound(0) + 1; x++)
                {
                    if (Field.entities[x, y].ch == Constants.Coin) MaxCoins++;
                    if (Field.entities[x, y].ch == Constants.BigCoin) MaxCoins += 3;
                }
            }
        }
    }
}
