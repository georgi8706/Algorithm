using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;
using Algorithms.AllKind;

namespace Algorithms
{

    // Minimum Spanning Tree (or forest, when we have more than one component in the graph)
    public class GraphMSTresolvedViaPrim
    {
        Graph _graph;

        // Key: node index, Value: tree that node belongs to
        List<Edge> _mst = new List<Edge>();
        private List<int> _visitedNodes = new List<int>();

        public List<Edge> FindMST()
        {
            _visitedNodes.Clear();

            foreach (Node node in _graph.Nodes)
            {
                Prim(node.Index);
            }

            return _mst;
        }

        private void Prim(int firstNode)
        {
            _visitedNodes.Add(firstNode);

            var prioritizedEdges = new BinaryHeap<Edge>();

            foreach (var child in _graph[firstNode].Children)
            {
                prioritizedEdges.Enqueue(_graph[firstNode, child][0]);
            }

            while (prioritizedEdges.Count > 0)
            {
                var smallestEdge = prioritizedEdges.ExtractMin();

                firstNode = smallestEdge.Node1.Index;
                int secondNode = smallestEdge.Node2.Index;

                if (!(_visitedNodes.Contains(firstNode) && _visitedNodes.Contains(secondNode)))
                {
                    _visitedNodes.Add(secondNode);

                    _mst.Add(smallestEdge);

                    foreach (var child in _graph[secondNode].Children)
                    {
                        if (!_visitedNodes.Contains(child))
                        {
                            prioritizedEdges.Enqueue(_graph[secondNode, child][0]);
                        }
                    }
                }
            }
        }

        public void SetGraph(Graph graph)
        {
            _graph = graph;
        }
    }
}
