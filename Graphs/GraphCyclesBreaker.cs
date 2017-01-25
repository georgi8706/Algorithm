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

        public List<KeyValuePair<int, int>> BreakCycles()
        {
            var removedEdges = new List<KeyValuePair<int, int>>();

            return removedEdges;
        }

        public void SetGraph(Graph graph)
        {
            _graph = graph;
        }
    }
}
