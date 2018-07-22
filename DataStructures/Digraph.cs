using System;
namespace DataStructures
{
    public class Digraph : Graph
    {
        public Digraph(int vertexCount) : base(vertexCount)
        {
        }

        public override void AddEdge(int source, int sink)
        {
			var sourceList = adjacencyList[source];
			if (!sourceList.Contains(sink))
			{
				sourceList.Add(sink);
			}
        }
    }
}
