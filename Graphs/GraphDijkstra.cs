using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;
using Algorithms.AllKind;

namespace Algorithms
{
    class EdgesComparerByNodeValues : IComparer<Edge>
    {
        int IComparer<Edge>.Compare(Edge edge1, Edge edge2)
        {
            string val1 = edge1.Node1.Value.ToString();
            string val2 = edge2.Node1.Value.ToString();

            int compareRes = String.Compare(val1, val2);
            if (compareRes == 0)
            {
                val1 = edge1.Node2.Value.ToString();
                val2 = edge2.Node2.Value.ToString();

                compareRes = String.Compare(val1, val2);
            }

            return compareRes;
        }
    }

    // Finds shortest distances between one node to all nodes of the graph
    public class GraphDijkstra
    {
        Graph _graph;

        int[] _distances;
        int[] _prev;

        private List<int> _visitedNodes = new List<int>();

        public void SetGraph(Graph graph)
        {
            _distances = Enumerable.Repeat(-1, graph.Count).ToArray();

            _prev = new int[graph.Count];

            _visitedNodes = new List<int>();

            _graph = graph;
        }

        public List<KeyValuePair<Node, int>> FindDistances(int nodeIndex)
        {
            List<KeyValuePair<Node, int>> paths = new List<KeyValuePair<Node, int>>();

            TraverseGraphBFSUsingIteration(nodeIndex);

            return paths;
        }

        public int Compare(Edge edge1, Edge edge2)
        {
            int edge1PrevNode = _prev[edge1.Node1.Index] < _prev[edge1.Node2.Index] ? edge1.Node1.Index : edge1.Node2.Index;
            int edge2PrevNode = _prev[edge2.Node1.Index] < _prev[edge2.Node2.Index] ? edge2.Node1.Index : edge2.Node2.Index;

            int compareRes = -1;
            if (_prev[edge1PrevNode] + edge1.Weight > _prev[edge2PrevNode] + edge2.Weight)
            {
                compareRes = 1;
            }

            return compareRes;
        }

        private void TraverseGraphBFSUsingIteration(int outNode)
        {
            // inNode is the node that it is in the tree
            // outNode is the node which is out of the tree

            var prioritizedEdges = new BinaryHeap<Edge>();

            int inNode = -1;

            while (true)
            {
                if (!(_visitedNodes.Contains(inNode) && _visitedNodes.Contains(outNode)))
                {
                    foreach (var child in _graph[outNode].Children)
                    {
                        if (!_visitedNodes.Contains(child))
                        {
                            prioritizedEdges.Enqueue(_graph[outNode, child][0]);
                        }
                    }

                    _visitedNodes.Add(outNode);
                    inNode = outNode;
                }

                var smallestEdge = prioritizedEdges.ExtractMin();

                if(smallestEdge.Node1.Index != inNode)
                {
                    outNode = smallestEdge.Node1.Index;
                    inNode = smallestEdge.Node2.Index;
                }
                else
                {
                    outNode = smallestEdge.Node2.Index;
                    inNode = smallestEdge.Node1.Index;
                }

                if (_distances[outNode] == -1)
                {
                    int prevDistance = 0;
                    if (_distances[inNode] != -1)
                    {
                        prevDistance = _distances[inNode];
                    }

                    _distances[outNode] = prevDistance + (int)smallestEdge.Weight;
                }
                else if (_distances[outNode] > _distances[inNode] + (int)smallestEdge.Weight)
                {
                    _distances[outNode] = _distances[inNode] + (int)smallestEdge.Weight;
                }

                _prev[outNode] = inNode;

                if (prioritizedEdges.Count == 0)
                {
                    break;
                }
            }
        }

    }
}
