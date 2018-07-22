using System;
using System.Linq;
using BasicAlgorithms.Helpers;

namespace DataStructures
{
    public class Heap
    {
        public const int Capacity = 5;
        public bool IsMinHeap { get; private set;}
        private Func<int, int, bool> comparisonFunc;
        int[] heap;
        int size;

        public Heap(bool isMinHeap)
        {
            heap = new int[Capacity];
            size = 0;
            this.IsMinHeap = isMinHeap;
            SetComparisonFunction();
        }

        public Heap (int[] a, bool isMinHeap = true)
        {
            BuildHeap(a, isMinHeap);
        }

        private void BuildHeap(int[] a, bool isMinHeap)
        {
            this.IsMinHeap = isMinHeap;
            SetComparisonFunction();

            heap = new int[a.Length + 1];
            size = a.Length;

            for (int i = 0; i < a.Length; i++)
            {
                heap[i + 1] = a[i];
            }

			for (int i = size / 2; i > 0; i--)
			{
				DownHeap(i, size);
			}
        }

        public void SetComparisonFunction()
        {
            if(IsMinHeap)
            {
                comparisonFunc = Less;
            }
            else
            {
                comparisonFunc = More;
            }
        }

        public bool Less(int a, int b)
        {
            return a < b;
        }

        private bool More(int a, int b)
        {
            return a > b;
        }

        public void UpHeap(int index)
        {
            while(index > 1 && comparisonFunc(heap[index], heap[index/2]))
            {
                ArrayHelper.Swap(heap, index, index / 2);
                index = index / 2;
            }
        }

        public int[] HeapSort()
        {
			for (int i = size; i > 0; i--)
			{
                ArrayHelper.Swap(heap, i , 1);
                DownHeap(1,i-1);
			}

            if(IsMinHeap)
            {
                ArrayHelper.ReverseArray(heap);
                return heap;
            }
            else
            {
                return heap;
            }
        }

        public void DownHeap(int startIndex, int maxIndex)
        {
            int i = startIndex;
            int smallestChildIndex;
            while(2*i <= maxIndex)
            {
                smallestChildIndex = 2 * i;
                if(smallestChildIndex < maxIndex && comparisonFunc(heap[smallestChildIndex+1],heap[smallestChildIndex]))
                {
                    smallestChildIndex = smallestChildIndex + 1;
                }

                if(comparisonFunc(heap[smallestChildIndex], heap[i]))
                {
                    ArrayHelper.Swap(heap, i, smallestChildIndex);
                    i = smallestChildIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public void Insert(int val)
        {
            if(size == heap.Length -1)
            {
                DoubleSize();
            }
            size++;
            heap[size] = val;
            UpHeap(size);
        }

        public int RemoveTop()
        {
            int element = heap[1];
            heap[1] = heap[size];
            heap[size] = 0;
            size--;
            DownHeap(1, size);
            return element;
        }


        private void DoubleSize()
        {
            int[] temp = new int[heap.Length * 2];
            for (int i = 1; i < heap.Length; i++)
            {
                temp[i] = heap[i];
            }
			heap = temp;
        }
    }
}
