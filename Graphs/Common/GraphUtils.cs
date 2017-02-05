using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms
{
    public class GraphUtils
    {
        List<int> _visitedNodes = new List<int>();

        public GraphUtils(Graph graph)
        {
            Graph = graph;
        }

        public Graph Graph { get; set; }

        /// <summary>
        /// Checks if and edge is part of a cycle.
        /// </summary>
        /// <param name="edge">A given edge.</param>
        /// <param name="nodesInUse">A given list with nodes, which are part of the graph and
        /// which the algorithm is allowed to traverse. If it's null, it will traverse all nodes in the graph.</param>
        /// <returns></returns>
        public bool IsEdgePartOfCycle(Edge edge, List<int> nodesInUse = null)
        {
            Reset();

            // Start traversing from the first node of the edge
            bool isCycleFound = IsEdgePartOfCycle(edge.Node1.Index, edge, nodesInUse);

            return isCycleFound;
        }

        public int CalculateComponentsNumber()
        {
            Reset();

            int componentsNumber = 0;
            int countOfVisitedNodes = 0;

            foreach (var node in Graph.Nodes)
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

        private void Reset()
        {
            _visitedNodes.Clear();
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

            foreach (var child in Graph[nodeIndex].Children)
            {
                TraverseNode(child);
            }
        }

        /// <summary>
        /// Checks whether an edge is part of a cycle.
        /// <remarks>Traverses a graph by DFS recursively.</remarks>
        /// </summary>
        private bool IsEdgePartOfCycle(int curNodeIndex, Edge edge, List<int> nodesInUse = null)
        {
            if(nodesInUse != null && !nodesInUse.Contains(curNodeIndex))
            {
                return false;
            }

            if (_visitedNodes.Contains(curNodeIndex))
            {
                return false;
            }

            if (_visitedNodes.Contains(edge.Node1.Index) && // first node is already visited
                curNodeIndex == edge.Node2.Index)
            {
                // Cycle!
                return true;
            }

            _visitedNodes.Add(curNodeIndex);

            foreach (var child in Graph[curNodeIndex].Children)
            {
                // Verify not to start traversing from start node of the edge immediately to the end node of the edge.
                if (curNodeIndex == edge.Node1.Index && child == edge.Node2.Index)
                {
                    if (Graph[curNodeIndex, child].Count == 1)
                    {
                        continue;
                    }
                }

                if (IsEdgePartOfCycle(child, edge, nodesInUse))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
