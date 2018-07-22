using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.GraphProcessors
{
    public class ConnectedComponents
    {
        bool[] visited;
        int[] id;
        public int Count { get; private set; }
        public ConnectedComponents(Graph g)
        {
            this.visited = new bool[g.VertexCount];
            this.id = new int[g.VertexCount];
            this.Count = 0;

            for (int v = 0; v < g.VertexCount; v++)
            {
                if(!visited[v])
                {
                    DFS(g, v);
                }
                this.Count++;
            }

        }

		private void DFS(Graph g, int v)
		{
			visited[v] = true;
            id[v] = this.Count;
            Console.WriteLine($"{v}:{id[v]}\t");
			foreach (var w in g.GetAdjacencyList(v))
			{
				if (!visited[w])
				{
					DFS(g, w);
				}
			}
		}

        public bool Connected(int v1, int v2)
        {
            return id[v1] == id[v2];
        }

        public int Id(int v)
        {
            return id[v];
        }

        public Dictionary<int, List<int>> GetComponentsAndMembers()
        {
            Dictionary<int, List<int>> connectedComponents = new Dictionary<int, List<int>>();
            for (int v = 0; v < id.Length; v++)
            {
                int idOfVertex = id[v];
                if(!connectedComponents.ContainsKey(idOfVertex))
                {
					connectedComponents.Add(idOfVertex, new List<int>());
                }

                connectedComponents[idOfVertex].Add(v);
            }

            return connectedComponents;
        }

        public void PrintConnectedComponents()
        {
            var connectedComponents = GetComponentsAndMembers();
            foreach(var entry in connectedComponents)
            {
                int id = entry.Key;
                List<int> members = entry.Value;
                Console.WriteLine($"For component {id}, we have the following members");
                foreach(var member in members)
                {
                    Console.Write($"{member}\t");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
