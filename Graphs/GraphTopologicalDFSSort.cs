using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms
{
    public class GraphTopologicalDFSSort
    {
        Graph _graph;
        List<int> _visitedNodes;

        private Graph CreateSimpleGraph()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 3, 5 });
            graph.InsertNode(1, new int[] { 2 });
            graph.InsertNode(2);
            graph.InsertNode(3, new int[] { 5 });
            graph.InsertNode(4, new int[] { 0, 1 });
            graph.InsertNode(5, new int[] { 1, 2 });

            return graph;
        }

        public void Run()
        {
            var graph = CreateSimpleGraph();

            var nodes = Sort(graph);

            Console.Write("Topological DFS sort result: " + String.Join(", ", nodes) + "\n");
        }

        public List<int> Sort(Graph graph)
        {
            _graph = graph;
            _visitedNodes = new List<int>();

            for (int node = 0; node < _graph.Count; node++)
            {
                TraverseGraph(node);
            }

            return _visitedNodes;
        }

        private void TraverseGraph(int nodeIndex)
        {
            if (_visitedNodes.Contains(nodeIndex))
            {
                return;
            }

            foreach (int predecessor in _graph[nodeIndex].Children)
            {
                TraverseGraph(predecessor);
            }

            _visitedNodes.Insert(0, nodeIndex);
        }
    }
}
