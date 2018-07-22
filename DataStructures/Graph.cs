using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Graph
    {
        public int VertexCount { get; private set; }
        protected Dictionary<int, List<int>> adjacencyList;

        public Graph(int vertexCount)
        {
            this.VertexCount = vertexCount;
            adjacencyList = new Dictionary<int, List<int>>();

            for (int i = 0; i < vertexCount; i++)
            {
                adjacencyList.Add(i, new List<int>());
            }
        }

        public virtual void AddEdge(int source, int sink)
        {
            var sourceList = adjacencyList[source];
            if(!sourceList.Contains(sink))
            {
                sourceList.Add(sink);
            }

            var sinkList = adjacencyList[sink];
            if (!sinkList.Contains(source))
			{
                sinkList.Add(source);
			}
        }

        public List<int> GetAdjacencyList(int vertex)
        {
            if(adjacencyList.ContainsKey(vertex))
            {
                return adjacencyList[vertex];
            }

            return new List<int>();
        }

    }
}
