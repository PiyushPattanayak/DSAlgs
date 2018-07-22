using System;
namespace BasicAlgorithms.Helpers
{
    public class MatrixRotation
    {
			public static void rotateMatrixClockwise(int[,] a)
			{
				int n = a.GetUpperBound(0) + 1;
				for (int layer = 0; layer < n / 2; layer++)
				{
					int first = layer;
					int last = n - 1 - layer;
					for (int i = first; i < last; i++)
					{
						int offset = i - first;
						int temp = a[first, i];
						a[first, i] = a[last - offset, first];
						a[last - offset, first] = a[last, last - offset];
						a[last, last - offset] = a[i, last];
						a[i, last] = temp;
					}
				}
			}

			public static void rotateMatrixCounterClockwise(int[,] a)
			{
				int n = a.GetUpperBound(0) + 1;
				for (int layer = 0; layer < n / 2; layer++)
				{
					int first = layer;
					int last = n - 1 - layer;
					for (int i = first; i < last; i++)
					{
						int offset = i - first;
						int temp = a[first, i];
						a[first, i] = a[i, last];
						a[i, last] = a[last, last - offset];
						a[last, last - offset] = a[last - offset, first];
						a[last - offset, first] = temp;
					}
				}
			}

        public static void Print2DArray(int[,] a)
        {
            for (int i = 0; i <= a.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= a.GetUpperBound(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
