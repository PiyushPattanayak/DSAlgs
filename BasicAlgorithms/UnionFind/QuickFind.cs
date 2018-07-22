using System;
using System.Text;

namespace BasicAlgorithms.UnionFind
{
    public abstract class UnionFindBase : IUnionFind
    {
		protected int[] id;
		protected int count;

		public int Count
		{
			get
			{
				return count;
			}
		}

		public void Print()
		{
			StringBuilder result = new StringBuilder();
			result.Append("{ ");
			for (int i = 0; i < id.Length; i++)
			{
				result.Append(id[i]);
				if (i != id.Length - 1)
				{
					result.Append(",");
				}
				result.Append(" ");
			}
            Console.WriteLine(result.ToString());
		}

		protected bool IsIndexWithinBounds(int p)
		{
			return p >= 0 && p < id.Length;
		}

		public bool Connected(int p, int q)
		{
			return Find(p) == Find(q) && Find(p) != -1;
		}

        public abstract int Find(int p);

        public abstract void Union(int p, int q);
    }

    // Introduce ErrorContext later for better error messages.
    public class QuickFind : UnionFindBase
    {
        public QuickFind(int N)
        {
            id = new int[N];
            count = N;
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
            }
        }

        public override int Find (int p)
        {
            if (!IsIndexWithinBounds(p))
            {
                return -1;
            }

            return id[p];
        }



        public override void Union(int p, int q)
        {
            int pId = Find(p);
            int qId = Find(q);

            if (pId == qId)
            {
                return;
            }

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pId)
                {
                    id[i] = qId;
                }
            }

            count--;
        }
    }

    public class QuickUnion : UnionFindBase
    {
        public QuickUnion(int N)
        {
            id = new int[N];
            count = N;
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
            }
        }

		public override int Find(int p)
		{
			if (!IsIndexWithinBounds(p))
			{
				return -1;
			}

			while (p != id[p])
            {
                p = id[p];
            }

            return p;
		}

        public override void Union(int p, int q)
        {
            int pId = Find(p);
            int qId = Find(q);

            // If the elements are already connected, or if they dont exist, then return
            if (pId == qId || pId == -1 || qId == -1)
            {
                if (pId == qId)
                {
                    Console.WriteLine("Elements are already connected");
                    return;
                }
                Console.WriteLine("One of the input elements does not exist in the array");
                return;
            }

            id[pId] = qId;

            count--;
        }
    }

    public class WeightedQUF : QuickUnion
    {
        int[] sz;

        public WeightedQUF(int N) : base(N)
        {
            sz = new int[N];
            for (int i = 0; i < N; i++)
            {
                sz[i] = 1;
            }
        }

        public override void Union(int p, int q)
        {
            int pId = Find(p);
            int qId = Find(q);

			// If the elements are already connected, or if they dont exist, then return
			if (pId == qId || pId == -1 || qId == -1)
			{
				if (pId == qId)
				{
					Console.WriteLine("Elements are already connected");
					return;
				}
				Console.WriteLine("One of the input elements does not exist in the array");
				return;
			}

			if (sz[pId] < sz[qId])
            {
                id[pId] = qId;
                sz[qId] += sz[pId];
            }
            else
            {
				id[qId] = pId;
				sz[pId] += sz[qId];
            }

            count--;
        }
    }

    public class WeightedQUFWithPathCompression : WeightedQUF
    {
        public WeightedQUFWithPathCompression(int N) : base(N)
        {
        }

        // Make p point to its grandparent instead of parent
        public override int Find(int p)
        {
			if (!IsIndexWithinBounds(p))
			{
				return -1;
			}

            while (p != id[p])
            {
                id[p] = id[id[p]];
                p = id[p];
            }

            return p;
        }
    }
}
