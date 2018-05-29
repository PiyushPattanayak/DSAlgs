using System;
using BasicAlgorithms.Helpers;

namespace BasicAlgorithms.Sorting
{
    public class Sorters
    {
        public static void SelectionSort(int[] a)
        {
            SelectionSort(a, 0, a.Length - 1);
        }

        public static void SelectionSort(int[] a, int left, int right)
        {
            for (int i = 0; i < right; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j <= right; j++)
                {
                    if (a[j] < a[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    ArrayHelper.Swap(a, minIndex, i);
                }
            }
        }

		public static void BubbleSort(int[] a)
		{
			BubbleSort(a, 0, a.Length - 1);
		}

		public static void BubbleSort(int[] a, int left, int right)
		{
			for (int i = 0; i <= right; i++)
			{
				for (int j = 1; j <= right-i; j++)
				{
					if (a[j-1] > a[j])
					{
                        ArrayHelper.Swap(a, j-1, j);
					}
				}
			}
		}

		public static void InsertionSort(int[] a)
		{
			InsertionSort(a, 0, a.Length - 1);
		}

		public static void InsertionSort(int[] a, int left, int right)
		{
            int temp, j;
			for (int i = 1; i <= right; i++)
			{
                temp = a[i];
				for (j = i-1; j >=0 && temp < a[j]; j--)
				{
                    a[j + 1] = a[j];
				}

				a[j + 1] = temp;
			}
		}

		public static void MergeSort(int[] a)
		{
            MergeSort(a, 0, a.Length - 1);
		}

		public static void MergeSort(int[] a, int left, int right)
		{

            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(a, left, mid);
                MergeSort(a, mid+1, right);
                Merge(a, left, mid, right);
            }
		}

        private static void Merge(int[] a, int left, int mid, int right)
        {
            int indexLeft = left;
            int indexRight = mid + 1;
            int[] tmp = new int[right - left + 1];
            int tmpIndex = 0;

            while (tmpIndex <= tmp.Length -1)
            {
                if (indexLeft > mid)
                {
                    tmp[tmpIndex++] = a[indexRight++];
                }
                else if (indexRight > right)
                {
                    tmp[tmpIndex++] = a[indexLeft++];
                }
                else if (a[indexLeft] <= a[indexRight])
                {
                    tmp[tmpIndex++] = a[indexLeft++];
                }
                else
                {
                    tmp[tmpIndex++] = a[indexRight++];
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                a[left + i] = tmp[i];
            }
        }

		public static void QuickSort(int[] a)
		{
                QuickSort(a, 0, a.Length - 1);
		}

		public static void QuickSort(int[] a, int left, int right)
		{
			if (left < right)
			{
                int index = Partition(a, left, right);
                QuickSort(a, left, index-1);
                QuickSort(a, index, right);
			}
		}

        private static int Partition(int[] a, int left, int right)
        {
            int pivot = a[(left + right) / 2];
            while (left <= right)
            {
                while (a[left] < pivot)
                {
                    left++;
                }

				while (a[right] > pivot)
				{
                    right--;
				}

                if (left <= right)
                {
                    ArrayHelper.Swap(a, left, right);
                    left++;
                    right--;
                }
            }

            return left;
        }

		public static void QuickSortWithDuplicates(int[] a)
		{
			QuickSort(a, 0, a.Length - 1);
		}

        public static void QuickSortWithDuplicates(int[] a, int left, int right)
		{
			if (left < right)
			{
                int pivot = a[left];
                int i = left+1;
                int lt = left;
                int gt = right;

                while (i <= gt)
                {
                    if(a[i] < pivot)
                    {
                        ArrayHelper.Swap(a, i, lt);
                        i++;
                        lt++;
                    }
                    else if (a[i] > pivot)
                    {
						ArrayHelper.Swap(a, i, gt);
                        gt--;
                    }
                    else
                    {
                        i++;
                    }
                }

				QuickSort(a, left, lt - 1);
				QuickSort(a, gt + 1, right);
			}
		}
    }
}
