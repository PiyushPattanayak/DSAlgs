using System;
using System.Collections.Generic;
namespace DataStructures.GraphProcessors
{
	public class DepthFirstSearch
	{
		private bool[] visited;
        public Queue<int> PreOrder { get; private set; }
		public Queue<int> PostOrder { get; private set; }
		public Stack<int> ReversePostOrder { get; private set; }

        public DepthFirstSearch(Digraph g)
		{
			this.visited = new bool[g.VertexCount];
            this.PreOrder = new Queue<int>();
            this.PostOrder = new Queue<int>();
            this.ReversePostOrder = new Stack<int>();

            for (int v = 0; v < g.VertexCount; v++)
            {
                if(!visited[v])
                {
                    DFS(g, v);
                }
            }
		}

		private void DFS(Graph g, int v)
		{
            this.PreOrder.Enqueue(v);
			visited[v] = true;

			foreach (var vertex in g.GetAdjacencyList(v))
			{
				if (!visited[vertex])
				{
					DFS(g, vertex);
				}
			}
            this.PostOrder.Enqueue(v);
            this.ReversePostOrder.Push(v);
		}
	}


	public class TopologicalSort
    {
        public Stack<int> TopSortStack { get; private set; }
        
        public TopologicalSort(Digraph g)
        {
            FindCycleDirectedGraph fcd = new FindCycleDirectedGraph(g);
            if (fcd.HasCycle)
            {
                Console.WriteLine("Cannot perform topological sort as graph has cycle.");
            }
            else
            {
                DepthFirstSearch dfs = new DepthFirstSearch(g);
                this.TopSortStack = dfs.ReversePostOrder;
            }
        }

        public void PrintTopologicalOrder()
        {
            Stack<int> order = new Stack<int>(new Stack<int>(this.TopSortStack));

			while (order.Count != 0)
			{
				Console.Write(order.Pop());
				if (order.Count != 0)
				{
					Console.Write("->");
				}
			}
            Console.WriteLine();
        }
    }
}
