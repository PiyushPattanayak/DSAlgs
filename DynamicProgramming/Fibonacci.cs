using System;
namespace DynamicProgramming
{
    public class Fibonacci
    {
        public static int Recursive(int n)
        {
            if(n < 0)
            {
                Console.WriteLine("Can't find fibonacci for negative numbers.");
                return - 1;
            }

            if(n == 0 || n == 1)
            {
                return n;
            }

            return Recursive(n - 1) + Recursive(n - 2);
        }

        public static int TopDownDP(int n)
        {
			if (n == 0 || n == 1)
			{
				return n;
			}

            int[] cache = new int[n + 1];

            for (int i = 2; i < n + 1; i++)
            {
                cache[i] = -1;
            }

            cache[0] = 0;
            cache[1] = 1;

            return TopDownDPUtil(n, cache);
        }

		private static int TopDownDPUtil(int n, int[] cache)
		{
            if(cache[n] != -1)
            {
                return cache[n];
            }

            cache[n] = TopDownDPUtil(n - 1, cache) + TopDownDPUtil(n - 2, cache);

            return cache[n];
		}

		public static int BottomUpDp(int n)
		{
			if (n == 0 || n == 1)
			{
				return n;
			}

			int[] cache = new int[n + 1];
			cache[0] = 0;
			cache[1] = 1;

			for (int i = 2; i < n + 1; i++)
			{
				cache[i] = cache[i-1]+cache[i-2];
			}

            return cache[n];
		}

    }
}
