using System;
namespace DataStructures.GraphProcessors
{
    public class GraphTestMethods
    {
        public GraphTestMethods()
        {
        }

        public Graph GenerateUndirectedGraph()
        {
			Graph g = new Graph(4);

			g.AddEdge(0, 1);
			g.AddEdge(0, 2);
			g.AddEdge(1, 2);
			g.AddEdge(2, 0);
			g.AddEdge(2, 3);
			g.AddEdge(3, 3);

            return g;
        }


        public Digraph GenerateDirectedCyclicGraph()
		{
            Digraph g = new Digraph(4);

			g.AddEdge(0, 1);
			g.AddEdge(0, 2);
			g.AddEdge(1, 2);
			g.AddEdge(2, 0);
			g.AddEdge(2, 3);
			g.AddEdge(3, 3);

			return g;
		}

        public Digraph GenerateDirectedCyclicSelfLoopGraph()
		{
			Digraph g = new Digraph(4);

			g.AddEdge(0, 1);
			g.AddEdge(0, 2);
			g.AddEdge(1, 2);
			g.AddEdge(2, 3);
			g.AddEdge(3, 3);

			return g;
		}

		public Digraph GenerateDirectedAcyclicGraph()
		{
			Digraph g = new Digraph(4);

			g.AddEdge(0, 1);
			g.AddEdge(0, 2);
			g.AddEdge(1, 2);
			g.AddEdge(2, 3);

			return g;
		}

		public Digraph GenerateDirectedAcyclicGraphForTopologicalSort()
		{
			Digraph g = new Digraph(6);

			g.AddEdge(5, 2);
			g.AddEdge(5, 0);
			g.AddEdge(4, 0);
			g.AddEdge(4, 1);
			g.AddEdge(2, 3);
			g.AddEdge(3, 1);

			return g;
		}

        public Graph GenerateUndirectedGraphForConnectedComponents()
        {
			// 5 vertices numbered from 0 to 4
			Graph g = new Graph(5); 
			g.AddEdge(1, 0);
			g.AddEdge(2, 3);
			g.AddEdge(3, 4);

            return g;
        }
    }
}
