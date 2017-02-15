using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;
using Algorithms.AllKind;

namespace Algorithms
{
    class EdgesComparerByDistanceFromStart : IComparer<Edge>
    {
        public EdgesComparerByDistanceFromStart(int[] distances)
        {
            // USe distance
            _distances = distances;
        }

        int[] _distances;

        int IComparer<Edge>.Compare(Edge edge1, Edge edge2)
        {
            int edge1Distance = 0;
            if (_distances[edge1.Node1.Index] != -1)
            {
                edge1Distance = _distances[edge1.Node1.Index];
            }
            else if(_distances[edge1.Node2.Index] != -1)
            {
                edge1Distance = _distances[edge1.Node2.Index];
            }

            edge1Distance += (int)edge1.Weight;

            int edge2Distance = 0;
            if (_distances[edge2.Node1.Index] != -1)
            {
                edge2Distance = _distances[edge2.Node1.Index];
            }
            else if (_distances[edge2.Node2.Index] != -1)
            {
                edge2Distance = _distances[edge2.Node2.Index];
            }

            edge2Distance += (int)edge2.Weight;

            int compareRes = -1;
            if (edge1Distance > edge2Distance)
            {
                compareRes = 1;
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
            _prev = Enumerable.Repeat(-1, graph.Count).ToArray();

            _visitedNodes = new List<int>();

            _graph = graph;
        }

        public int[] FindDistances(int nodeIndex)
        {
            _distances[nodeIndex] = 0;

            TraverseGraphBFSUsingIteration(nodeIndex);

            return _distances;
        }

        private void TraverseGraphBFSUsingIteration(int outNode)
        {
            // inNode is the node that it is in the tree
            // outNode is the node which is out of the tree

            var prioritizedEdges = new BinaryHeap<Edge>();
            prioritizedEdges.Comparer = new EdgesComparerByDistanceFromStart(_distances);

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

                if (!_visitedNodes.Contains(smallestEdge.Node1.Index))
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

                    _prev[outNode] = inNode;
                }
                else if (_distances[outNode] > _distances[inNode] + (int)smallestEdge.Weight)
                {
                    _distances[outNode] = _distances[inNode] + (int)smallestEdge.Weight;
                }

                if (prioritizedEdges.Count == 0)
                {
                    break;
                }
            }
        }

    }
}
