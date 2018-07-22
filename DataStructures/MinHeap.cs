using System;
namespace DataStructures
{
    public class MinHeap
    {
        private int capacity = 8;
        private int[] heap;
        private int size;

        private int GetLeftChildIndex(int parentIndex)
        {
            return ((2 * parentIndex) + 1);
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        public MinHeap()
        {
            heap = new int[capacity];
            size = 0;
        }

        public MinHeap(int[] a)
        {
            size = a.Length;
            heap = new int[size];
            for (int i = 0; i < a.Length; i++)
            {
                heap[i] = a[i];
            }
            BuildHeap();
        }

        private void BuildHeap()
        {
            for (int i = (size -1)/ 2; i >= 0; i--)
            {
                DownHeap(i, size - 1);
            }
        }

        private void swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        private void DownHeap(int index, int maxIndex)
        {
            while (GetLeftChildIndex(index) <= maxIndex)
            {
                int child = GetLeftChildIndex(index);
                if(child < maxIndex && heap[child+1] < heap[child])
                {
                    child = child + 1;
                }

                if (heap[index] > heap[child])
                {
                    swap(index, child);
                    index = child;
                }
                else
                {
                    break;
                }
            }
        }

        private void UpHeap(int index)
        {
            while(index > 0 && heap[index] < heap[GetParentIndex(index)])
            {
                int parent = GetParentIndex(index);
                swap(index, parent);
                index = parent;
            }
        }

        public void Insert(int element)
        {
            if(size == heap.Length)
            {
                throw new StackOverflowException("Heap is full, can't add");
            }
            heap[size] = element;
            size++;
			// Pass in the index of the last element, so that it works on the element at that location
			UpHeap(size-1); 
        }

		public int RemoveMin()
		{
			if (size == 0)
			{
				throw new StackOverflowException("Heap is empty, can't remove");
			}
            int elementToReturn = heap[0];
            heap[0] = heap[size - 1];
            heap[size - 1] = default(int);
            size--;
            DownHeap(0, size-1);
            return elementToReturn;
	    }

        public void PrintHeap()
        {
            Console.Write("{ ");
            for (int i = 0; i < size; i++)
            {
                Console.Write(heap[i]);
                if(i != size-1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" }");
        }
    }
}
