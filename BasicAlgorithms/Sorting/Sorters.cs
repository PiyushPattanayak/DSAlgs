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
            for (int i = left; i < right; i++)
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
            for (int i = left; i <= right; i++)
			{
                for (int j = left; j < right-i; j++)
				{
					if (a[j] > a[j+1])
					{
                        ArrayHelper.Swap(a, j, j+1);
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
            for (int i = left+1; i <= right; i++)
			{
                temp = a[i];
				for (j = i-1; j >=left && temp < a[j]; j--)
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

            while (tmpIndex < tmp.Length)
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
                QuickSort(a, index+1, right);
			}
		}

        private static int Partition(int[] a, int left, int right)
        {
            int pivot = a[(left + right) / 2];
            while (left < right)
            {
                while (a[left] < pivot)
                {
                    left++;
                }

				while (a[right] > pivot)
				{
                    right--;
				}

                if (left < right)
                {
                    ArrayHelper.Swap(a, left, right);
                }
            }

            return left;
        }


		public static int QuickSelectIterative(int[] a, int k)
		{
            int low = 0;
            int high = a.Length - 1;
            while(high > low)
            {
                int j = Partition(a, low, high);
                if (j < k-1)
                {
                    low = j + 1;
                }
                else if (j > k-1)
                {
                    high = j - 1;
                }
                else
                {
                    return a[k-1];
                }
            }
            return a[k-1];
		}

        public static int QuickSelect(int[] a, int k)
        {
            return QuickSelect(a, 0, a.Length - 1, k);
        }

        private static int QuickSelect(int[] a, int low, int high, int k)
        {
            if(low == high)
            {
                return a[low];
            }

            int index = Partition(a, low, high);
            if(index > k-1)
            {
                return QuickSelect(a, low, index - 1, k);
            }
            else if (index < k-1)
            {
                return QuickSelect(a, index + 1, high, k);
            }
            else 
            {
                return a[index];
            }
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
                int i = left;
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

		private static int GetLeftChildIndex(int parentIndex)
		{
			return ((2 * parentIndex) + 1);
		}

		private static void DownHeap(int[] heap, int index, int maxIndex)
		{
			while (GetLeftChildIndex(index) <= maxIndex)
			{
				int child = GetLeftChildIndex(index);
				if (child < maxIndex && heap[child + 1] > heap[child])
				{
					child = child + 1;
				}

				if (heap[index] < heap[child])
				{
                    ArrayHelper.Swap(heap, index, child);
					index = child;
				}
				else
				{
					break;
				}
			}
		}

        public static void HeapSort(int[] a)
        {
            for (int i = (a.Length - 1) / 2; i >= 0; i--)
            {
                DownHeap(a, i, a.Length - 1);
            }


            for (int i = a.Length-1; i >= 0; i--)
            {
                ArrayHelper.Swap(a,0,i);
                DownHeap(a,0,i-1);
            }
        }
    }
}
