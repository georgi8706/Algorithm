using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;
using Algorithms.Common;

namespace Algorithms
{
    public class GraphStronglyConnectedComponents
    {
        Graph _graph;

        Stack<int> _componentPath;

        private List<int> _visitedNodes = new List<int>();

        public void SetGraph(Graph graph)
        {
            _componentPath = new Stack<int>();

            _visitedNodes = new List<int>();

            _graph = graph;
        }

        public List<List<int>> FindStronglyConnectedComponents()
        {
            var components = new List<List<int>>();

            _visitedNodes.Clear();

            //foreach (Node node in _graph.Nodes)
            {
                TraverseGraphUsingRecursion(5);
            }

            return components;
        }

        private bool TraverseGraphUsingRecursion(int nodeIndex)
        {
            if (_visitedNodes.Contains(nodeIndex))
            {
                return false;
            }

            _visitedNodes.Add(nodeIndex);

            bool nonVisitedChildExists = false;

            foreach (var child in _graph[nodeIndex].Children)
            {
                if (TraverseGraphUsingRecursion(child))
                {
                    nonVisitedChildExists = true;
                }
            }

            if (!nonVisitedChildExists)
            {
                _componentPath.Push(nodeIndex);
            }

            return true;
        }
    }
}
