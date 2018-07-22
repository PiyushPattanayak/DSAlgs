using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming
{
    public class MinimumCoinChange
    {
        public class MinCoinResult
        {
            public int minimumCount;
            public List<int> selectedCoins;

            public MinCoinResult(MinCoinResult b)
            {
                minimumCount = b.minimumCount;
                selectedCoins = b.selectedCoins;
            }

            public MinCoinResult(int count)
            {
                minimumCount = count;
                selectedCoins = new List<int>();
            }

            public void Print()
            {
                Console.WriteLine($"Minimum Count is {minimumCount}");

                Console.WriteLine($"The selected coins are ");
                foreach(var c in selectedCoins)
                {
                    Console.Write($"{c} \t");
                }
                Console.WriteLine();
            }

        }

        public static MinCoinResult Recursive(int[] coins, int amount)
        {
            if(amount == 0)
            {
                return new MinCoinResult(0);
            }

            var minimumCountResult = new MinCoinResult(Int32.MaxValue);

            foreach(var c in coins)
            {
                if(amount >= c)
                {
					var currentMinCountResult = Recursive(coins, amount - c);
                    if(currentMinCountResult.minimumCount < minimumCountResult.minimumCount)
                    {
                        minimumCountResult = currentMinCountResult;
                        minimumCountResult.selectedCoins.Add(c);
                    }
                  
                }
            }

            minimumCountResult.minimumCount++;

            return minimumCountResult;
        }

		// Bottom up dynamic programming solution.
		// Iteratively compute number of coins for
		// larger and larger amounts of change
		//public int makeChange(int c)
		//{
		//	int[] cache = new int[c + 1];
		//	for (int i = 1; i <= c; i++)
		//	{
		//		int minCoins = Int32.MaxValue;
		//		// Try removing each coin from the total
		//		// and see which requires the fewest
		//		// extra coins
		//		for (int coin : coins)
		//		{
		//			if (i - coin >= 0)
		//			{
		//				int currCoins = cache[i - coin] + 1;
		//				if (currCoins < minCoins)
		//				{
		//					minCoins = currCoins;
		//				}
		//			}
		//		}
		//		cache[i] = minCoins;
		//	}
		//	return cache[c];
		//}

    }
}
