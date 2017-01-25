using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms
{
    public class GraphAcyclicChecker
    {
        Graph _graph;
        List<int> _visitedNodes = new List<int>();

        public bool IsAcyclic(Graphs_AdjacencyLists.Graph graph)
        {
            _visitedNodes.Clear();

            return IsAcyclic(0);
        }

        public void SetGraph(Graph graph)
        {
            _graph = graph;
        }

        /// <summary>
        /// Returns true if the graph is acyclic, otherwise false. 
        /// <remarks>Traverses a graph by DFS recursively.</remarks>
        private bool IsAcyclic(int nodeIndex)
        {
            if (_visitedNodes.Contains(nodeIndex))
            {
                return false;
            }

            // Check if we do not return back from where we came
            int lastAdded = -1;
            if(_visitedNodes.Count > 0)
            {
                lastAdded = _visitedNodes.Last();
            }

            _visitedNodes.Add(nodeIndex);

            foreach (var child in _graph[nodeIndex].ChildrenIndexes)
            {
                if (child != lastAdded)
                {
                    if (!IsAcyclic(child))
                    {
                        return false;
                    }
                }
            }

            _visitedNodes.Remove(nodeIndex);

            return true;
        }
    }
}
