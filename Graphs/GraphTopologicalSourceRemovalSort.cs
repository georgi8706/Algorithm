using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms
{
    public class GraphTopologicalSourceRemovalSort
    {
        private Graph CreateSimpleGraph()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 3, 5 });
            graph.InsertNode(1, new int[] { 2 });
            graph.InsertNode(2, null);
            graph.InsertNode(3, new int[] { 5 });
            graph.InsertNode(4, new int[] { 0, 1 });
            graph.InsertNode(5, new int[] { 1, 2 });

            return graph;
        }

        public void Run()
        {
            var graph = CreateSimpleGraph();

            var nodes = Sort(graph);

            Console.Write("Topological source removal sort result: " + String.Join(", ", nodes) + "\n");
        }

        public List<int> Sort(Graph graph)
        {
            var nodes = new List<int>();

            var childrenCount = new int[graph.Count];

            // Calculate children count of each node
            for (int node = 0; node < graph.Count; node++)
            {
                foreach (var child in graph[node].Children)
                {
                    childrenCount[child]++;
                }
            }

            // Do cycle while there is at least one graph that is not deleted
            var removedGraphs = new bool[graph.Count];

            bool existsGraph = true;
            while (existsGraph)
            {
                existsGraph = false;

                for (int node = 0; node < graph.Count; node++)
                {
                    if (childrenCount[node] == 0 && !removedGraphs[node])
                    {
                        foreach (var child in graph[node].Children)
                        {
                            childrenCount[child]--;
                        }

                        removedGraphs[node] = true;

                        existsGraph = true;

                        nodes.Add(node);

                        break;
                    }
                }
            }

            return nodes;
        }
    }
}
