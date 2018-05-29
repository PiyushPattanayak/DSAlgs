using System;
using System.Collections.Generic;

namespace BasicAlgorithms.Helpers
{
    public class ArrayHelper
    {
		public static int[] GenerateRandomIntegerArray(int size)
		{
			Random rand = new Random();
			HashSet<int> result = new HashSet<int>();
			while (result.Count < size)
			{
				result.Add(rand.Next(1, size * 10));
			}

			return System.Linq.Enumerable.ToArray(result);
		}

        public static void Swap(int [] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

		public static void PrintArray<T>(T[] array)
		{
			Console.Write("{ ");

			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i]);
				if (i != array.Length - 1)
				{
					Console.Write(", ");
				}
			}

			Console.WriteLine(" }\n");
		}
    }
}
