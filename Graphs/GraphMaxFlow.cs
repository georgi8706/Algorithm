using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;
using Algorithms.Common;

namespace Algorithms
{
    public class GraphMaxFlow
    {
        Graph _graph;

        List<int> _visitedNodes = new List<int>();

        List<int> _articulationPoints;

        public void SetGraph(Graph graph)
        {
            _visitedNodes = new List<int>();

            _graph = graph;
        }

        public List<int> Find(int startNode, int endNode)
        {
    
            foreach (Node node in _graph.Nodes)
            {
                _visitedNodes.Clear();

                DFS(startNode);
            }

            _visitedNodes.Clear();

            return _articulationPoints;
        }

        private void DFS(int node)
        {
            if (!_visitedNodes.Contains(node))
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
