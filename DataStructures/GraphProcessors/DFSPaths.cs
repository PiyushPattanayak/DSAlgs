using System;
using System.Collections.Generic;

namespace DataStructures.GraphProcessors
{
    public class DFSPaths
    {
        private bool[] visited;
        private int[] edgeTo;
        private int startVertex;
        private Graph g;
        
        public DFSPaths(Graph g, int startVertex)
        {
            this.g = g;
            visited = new bool[g.VertexCount];
            edgeTo = new int[g.VertexCount];
            this.startVertex = startVertex;
            DFSWithStack();
        }

        private void DFS()
        {
            DFS(g, startVertex);
        }

		private void DFSWithStack()
		{
			Stack<int> stack = new Stack<int>();
            DFS(g, startVertex, stack);
		}

        private void DFS(Graph g, int s)
        {
            visited[s] = true;
            Console.Write($"{s} \t");
            foreach(var vertex in g.GetAdjacencyList(s))
            {
                if(!visited[vertex])
                {
                    DFS(g, vertex);
                    edgeTo[vertex] = s;
                }
            }
        }

		private void DFS(Graph g, int s, Stack<int> stack)
		{
            stack.Push(s);
            visited[s] = true;

            while(stack.Count != 0)
            {
                int v = stack.Pop();
                Console.Write($" {v} \t");
				foreach (var vertex in g.GetAdjacencyList(v))
				{
					if (!visited[vertex])
					{
                        stack.Push(vertex);
                        visited[vertex] = true;
						edgeTo[vertex] = v;
					}
				}
            }
		}

        public bool HasPathTo(int vertex)
        {
            return visited[vertex];
        }

        public void PrintPath(int vertex)
        {
            if(!HasPathTo(vertex))
            {
                Console.WriteLine("No path from {startVertex} to {vertex} exists.");
                return;
            }

            Stack<int> path = new Stack<int>();
            for (int v = vertex; v != startVertex; v = edgeTo[v])
            {
                path.Push(v);
            }
            path.Push(startVertex);

            while(path.Count != 0)
            {
                Console.Write($"{path.Pop()}");
                if(path.Count != 0)
                {
                    Console.Write("->");
                }
            }
            Console.WriteLine();
        }

    }
}
