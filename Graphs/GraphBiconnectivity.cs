using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;
using Algorithms.Common;

namespace Algorithms
{
    public class GraphBiconnectivity
    {
        Graph _graph;

        List<int> _visitedNodes = new List<int>();

        int _blockedNode;

        List<int> _articulationPoints;

        public void SetGraph(Graph graph)
        {
            _visitedNodes = new List<int>();

            _graph = graph;
        }

        /// <summary>
        /// Finds all the articulation points in the graph. 
        /// <remarks>An articulation point is a point which if deleted, at least one node will remain disconnected the rest graph.</remarks>
        /// </summary>
        public List<int> FindArticulationPoints()
        {
            _articulationPoints = new List<int>();

            foreach (Node node in _graph.Nodes)
            {
                _blockedNode = node.Index;

                if (_graph[_blockedNode].Children.Count == 0)
                {
                    // Error invalid graph.
                    return _articulationPoints;
                }

                _visitedNodes.Clear();

                int startIndex = _graph[_blockedNode].Children[0];

                DFS(startIndex);

                if (_visitedNodes.Count < _graph.Count - 1)
                {
                    _articulationPoints.Add(node.Index);
                }
            }

            _visitedNodes.Clear();

            return _articulationPoints;
        }

        private void DFS(int node)
        {
            if (node != _blockedNode && !_visitedNodes.Contains(node))
            {
                _visitedNodes.Add(node);

                foreach (var child in _graph[node].Children)
                {
                    DFS(child);
                }
            }
        }
    }
}
