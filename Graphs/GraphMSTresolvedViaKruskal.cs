using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms
{
    // Minimum Spanning Tree (or forest, when we have more than one component in the graph)
    public class GraphMSTresolvedViaKruskal
    {
        Graph _graph;
        List<int> _visitedNodes = new List<int>();

        List<Tuple<int, int>> _edges = new List<Tuple<int, int>>();

        public List<int> FindMST()
        {
            List<int> mstPath = new List<int>();

            return mstPath;
        }

        public void SetGraph(Graph graph)
        {
            _graph = graph;
        }
    }
}
