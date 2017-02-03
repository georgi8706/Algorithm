using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms
{
    class EdgesComparer : IComparer<Tuple<int, int>>
    {
        Graph _graph;

        public EdgesComparer(Graph graph)
        {
            _graph = graph;
        }

        int IComparer<Tuple<int, int>>.Compare(Tuple<int, int> edge1, Tuple<int, int> edge2)
        {
            string val1 = _graph[edge1.Item1].Value.ToString();
            string val2 = _graph[edge2.Item1].Value.ToString();

            int compareRes = String.Compare(val1, val2);
            if (compareRes == 0)
            {
                val1 = _graph[edge1.Item2].Value.ToString();
                val2 = _graph[edge2.Item2].Value.ToString();

                compareRes = String.Compare(val1, val2);
            }

            return compareRes;
        }
    }

    public class GraphCyclesBreaker
    {
        Graph _graph;
        List<int> _visitedNodes = new List<int>();
        List<Tuple<int, int>> _edges = new List<Tuple<int, int>>();

        public List<Tuple<int, int>> BreakCycles()
        {
            var removedEdges = new List<Tuple<int, int>>();

            // Collect all edges in the graph
            GetEdges();

            //GetNodeValues();

            int componentsNumber = CalculateComponentsNumber();

            // Check if the graph has any cycles.
            // In any acyclic graph, the edges number is less or equal to the number of nodes - 1, otherwise the graph has a cycle.
            int edgeIndex = 0;

            while (_edges.Count + componentsNumber > _graph.Nodes.Count)
            {
                _visitedNodes.Clear();

                Tuple<int, int> edge = _edges[edgeIndex];

                if (IsEdgePartOfCycle(
                    edge.Item1,  // start traversing from the first node of the edge
                    edge.Item1,  // first node
                    edge.Item2)) // second node
                {
                    removedEdges.Add(edge);

                    DeleteEdge(edge);
                }
                else
                {
                    edgeIndex++;
                }
            }

            return removedEdges;
        }

        private void GetNodeValues()
        {
            // Code to visualize the node values
            List<Tuple<string, string>> edgeValues = new List<Tuple<string, string>>();
            foreach (var edge in _edges)
            {
                string v1 = _graph[edge.Item1].Value.ToString();
                string v2 = _graph[edge.Item2].Value.ToString();

                edgeValues.Add(new Tuple<string, string>(v1, v2));
            }
        }

        private int CalculateComponentsNumber()
        {
            int componentsNumber = 0;
            int countOfVisitedNodes = 0;

            foreach (var node in _graph.Nodes)
            {
                countOfVisitedNodes = _visitedNodes.Count;

                TraverseNode(node.Index);

                if (_visitedNodes.Count > countOfVisitedNodes)
                {
                    componentsNumber++;
                }
            }

            return componentsNumber;
        }

        private void GetEdges()
        {
            // Duplicate edges is valid only for undirected graphs, because for example edge 0-1, is equal to the edge 1-0.
            // We don't want repetition of the same edge. Of course two nodes may have more than 1 edge and in this case we should save all unique edges.
            var duplicateEdges = new List<Tuple<int, int>>();

            foreach (var node in _graph.Nodes)
            {
                foreach (var child in node.ChildrenIndexes)
                {
                    var edge = duplicateEdges.FirstOrDefault(o => o.Item1 == child && o.Item2 == node.Index || o.Item1 == node.Index && o.Item2 == child);

                    if (edge != null)
                    {
                        duplicateEdges.Remove(edge);
                    }
                    else
                    {
                        int node1 = node.Index;
                        int node2 = child;

                        string node1Value = _graph[node1].Value.ToString();
                        string node2Value = _graph[node2].Value.ToString();

                        // The node with the less value should be to the left
                        if (String.Compare(node1Value, node2Value) > 0)
                        {
                            int temp = node1;
                            node1 = node2;
                            node2 = temp;
                        }

                        edge = new Tuple<int, int>(node1, node2);
                        _edges.Add(edge);

                        duplicateEdges.Add(edge);
                    }
                }
            }

            // Sort alphabetically the list. 
            // Algorithm sorts by the node values, as first it sorts according to the first node value and then according to the second node value.
            _edges.Sort(new EdgesComparer(_graph));
        }

        /// <summary>
        /// Deletes an edge of undirected graph.
        /// </summary>
        private void DeleteEdge(Tuple<int, int> edge)
        {
            _graph[edge.Item1].ChildrenIndexes.Remove(edge.Item2);
            _graph[edge.Item2].ChildrenIndexes.Remove(edge.Item1);

            _edges.Remove(edge);
        }

        /// <summary>
        /// Checks whether an edge is part of a cycle.
        /// <remarks>Traverses a graph by DFS recursively.</remarks>
        /// </summary>
        private bool IsEdgePartOfCycle(int nodeIndex, int edgeNode1, int edgeNode2)
        {
            if (_visitedNodes.Contains(nodeIndex))
            {
                return false;
            }

            if (_visitedNodes.Contains(edgeNode1) && // first node is already visited
                nodeIndex == edgeNode2)
            {
                // Cycle!
                return true;
            }

            _visitedNodes.Add(nodeIndex);

            foreach (var child in _graph[nodeIndex].ChildrenIndexes)
            {
                // Verify not to start traversing from start node of the edge immediately to the end node of the edge.
                if (nodeIndex == edgeNode1 && child == edgeNode2)
                {
                    int numEdgesConnectingTwoNodes = _edges.Count(o => o.Item1 == nodeIndex && o.Item2 == child || o.Item1 == child && o.Item2 == nodeIndex);

                    if (numEdgesConnectingTwoNodes == 1)
                    {
                        continue;
                    }
                }

                if (IsEdgePartOfCycle(child, edgeNode1, edgeNode2))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Traverses a graph by DFS recursively.
        /// </summary>
        private void TraverseNode(int nodeIndex)
        {
            if (_visitedNodes.Contains(nodeIndex))
            {
                return;
            }

            _visitedNodes.Add(nodeIndex);

            foreach (var child in _graph[nodeIndex].ChildrenIndexes)
            {
                TraverseNode(child);
            }
        }

        public void SetGraph(Graph graph)
        {
            _graph = graph;
        }
    }
}
