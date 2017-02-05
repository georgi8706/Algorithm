using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms.Graphs
{
    public class GraphShortestDistanceBetweenTwoNodes
    {
        Graph _graph;
        List<int> _visitedNodes = new List<int>();

        int _nodeFromId;
        int _nodeToId;
        int _shortestDistance;

        /// <summary>
        /// Returns shortest distance for a given pair of nodes.
        /// </summary>
        /// <param name="nodeFrom">The name (not the id) of the first node.</param>
        /// <param name="nodeTo">The name (not the id) of the second node.</param>
        public int Find(int nodeFrom, int nodeTo)
        {
            _nodeFromId = _graph.GetNodeIndexFromValue(nodeFrom);
            _nodeToId = _graph.GetNodeIndexFromValue(nodeTo);

            _shortestDistance = -1;

            if (_nodeFromId != -1 && _nodeToId != -1 && _nodeFromId != -1 && _nodeFromId != _nodeToId)
            {
                _visitedNodes.Clear();

                FindShortestDistance(_nodeFromId, 0);
            }

            return _shortestDistance;
        }

        /// <summary>
        /// Finds the shortest distance between two nodes as traverses the graph using DFS recursive algorithm.
        /// </summary>          
        private void FindShortestDistance(int nodeId, int currentDistance)
        {
            if (_shortestDistance != -1 && currentDistance >= _shortestDistance)
            {
                return;
            }

            if (nodeId == _nodeToId)
            {
                _shortestDistance = currentDistance;

                return;
            }
            else if (_visitedNodes.Contains(nodeId))
            {
                return;
            }

            _visitedNodes.Add(nodeId);

            foreach (var child in _graph[nodeId].Children)
            {
                FindShortestDistance(child, currentDistance + 1);
            }

            _visitedNodes.Remove(nodeId);
        }

        public void SetGraph(Graph graph)
        {
            _graph = graph;
        }
    }
}
