using System;
using System.Collections.Generic;

namespace DataStructures.GraphProcessors
{
    public class FindCycleUndirectedGraph
    {
        private bool[] visited;
        public bool HasCycle { get; private set; }
        public FindCycleUndirectedGraph(Graph g)
        {
            this.visited = new bool[g.VertexCount];
            this.HasCycle = false;

            for (int v = 0; v < g.VertexCount; v++)
            {
                if(!visited[v])
                {
                    DFS(g, v, v);
                }
            }
        }

		private void DFS(Graph g, int v, int parent)
		{
			visited[v] = true;
			Console.WriteLine($"{v}");
			foreach (var w in g.GetAdjacencyList(v))
			{
				if (!visited[w])
				{
					DFS(g, w, v);
				}
                else if(w != parent)
                {
                    this.HasCycle = true;
                }
			}
		}
    }

	public class FindCycleDirectedGraph
	{
		private bool[] recursionStack;
		private bool[] visited;
        private int[] edgeTo;
        public Stack<int> Cycle { get; private set; }

		public bool HasCycle 
        {
            get
            {
                return Cycle != null;
            }
        }

		public FindCycleDirectedGraph(Digraph g)
		{
			this.recursionStack = new bool[g.VertexCount];
			this.visited = new bool[g.VertexCount];
            this.edgeTo = new int[g.VertexCount];

			for (int v = 0; v < g.VertexCount; v++)
			{
				if (!visited[v])
				{
					DFS(g, v);
				}
			}
		}

		private void DFS(Digraph g, int v)
		{
            recursionStack[v] = true;
			visited[v] = true;

			foreach (var w in g.GetAdjacencyList(v))
			{
                if(this.HasCycle)
                {
                    return;
                }
				else if (!visited[w])
				{
                    edgeTo[w] = v;
					DFS(g, w);
				}
                else if (recursionStack[w])
				{
                    this.Cycle = new Stack<int>();
					for (int x = v; x != w; x = edgeTo[x])
						Cycle.Push(x);
					Cycle.Push(w);
					Cycle.Push(v);
				}
			}
            recursionStack[v] = false;
		}

        public void PrintCycle()
        {
            Stack<int> cycle = new Stack<int>(new Stack<int>(this.Cycle));

            while(cycle.Count != 0)
            {
                Console.Write(cycle.Pop());
                if(cycle.Count != 0)
                {
                    Console.Write("->");
                }
            }
            Console.WriteLine();
        }

	}

}
