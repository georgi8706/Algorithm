using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms
{
    public class GraphCyclesBreaker
    {
        Graph _graph;
        List<int> _visitedNodes = new List<int>();
        List<Tuple<int, int>> _edges = new List<Tuple<int, int>>();

        public List<Tuple<int, int>> BreakCycles()
        {
            var removedEdges = new List<Tuple<int, int>>();

            foreach(var node in _graph.Nodes)
            {
                TraverseGraph(node.Index);
            }

            return removedEdges;
        }

        /// <summary>
        /// Traverses a graph by DFS recursively.
        /// </summary>
        private void TraverseGraph(int nodeIndex)
        {
            if (_visitedNodes.Contains(nodeIndex))
            {
                return;
            }

            _visitedNodes.Add(nodeIndex);

            foreach (var child in _graph[nodeIndex].ChildrenIndexes)
            {
                bool isEdgeAlreadyAdded =_edges.FirstOrDefault(tuple => (tuple.Item1 == nodeIndex || tuple.Item1 == child) && (tuple.Item2 == nodeIndex || tuple.Item2 == child)) != null;

                if (!isEdgeAlreadyAdded)
                {
                    _edges.Add(new Tuple<int, int>(nodeIndex, child));
                }

                TraverseGraph(child);
            }
        }

        public void SetGraph(Graph graph)
        {
            _graph = graph;
        }
    }
}
