using System;
using System.Collections.Generic;

namespace DataStructures.GraphProcessors
{
	public class BFSPaths
	{
		private bool[] visited;
		private int[] edgeTo;
		private int[] distTo;
		private int startVertex;
		private Graph g;

		public BFSPaths(Graph g, int startVertex)
		{
			this.g = g;
			visited = new bool[g.VertexCount];
			edgeTo = new int[g.VertexCount];
            distTo = new int[g.VertexCount];
			this.startVertex = startVertex;
			BFS();
		}

		private void BFS()
		{
            Queue<int> queue = new Queue<int>();
			BFS(g, startVertex, queue);
		}

        private void BFS(Graph g, int s, Queue<int> queue)
		{
            queue.Enqueue(s);
			visited[s] = true;
            distTo[s] = 0;

			while (queue.Count != 0)
			{
                int v = queue.Dequeue();
				Console.Write($" {v} \t");
				foreach (var vertex in g.GetAdjacencyList(v))
				{
					if (!visited[vertex])
					{
                        queue.Enqueue(vertex);
						visited[vertex] = true;
						edgeTo[vertex] = v;
                        distTo[vertex] = 1 + distTo[v];
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
			if (!HasPathTo(vertex))
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

			while (path.Count != 0)
			{
				Console.Write($"{path.Pop()}");
				if (path.Count != 0)
				{
					Console.Write("->");
				}
			}
			Console.WriteLine();
		}

	}
}
