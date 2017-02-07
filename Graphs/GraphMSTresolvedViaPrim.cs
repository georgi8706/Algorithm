using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;
using Algorithms.AllKind;

namespace Algorithms
{

    // Minimum Spanning Tree (or forest, when we have more than one component in the graph)
    public class GraphMSTresolvedViaPrim
    {
        Graph _graph;

        List<int> _visitedNodes = new List<int>();

        // Key: node index, Value: tree that node belongs to
        List<Edge> _mst = new List<Edge>();

        public List<Edge> FindMST()
        {
            _visitedNodes.Clear();

            foreach (Node node in _graph.Nodes)
            {
                Prim(node.Index);
            }

            return _mst;
        }

        private void Prim(int nodeIndex)
        {
            if (_visitedNodes.Contains(nodeIndex))
            {
                return;
            }

            _visitedNodes.Add(nodeIndex);

            var prioritizedEdges = new BinaryHeap<Edge>();

            foreach (var child in _graph[nodeIndex].Children)
            {
                prioritizedEdges.Enqueue(_graph[nodeIndex, child][0]);
            }

            while(prioritizedEdges.Count > 0)
            {
                var smallestEdge = prioritizedEdges.ExtractMin();

                if(_mst.Contains(smallestEdge))
                {

                }
            }
        }

        public void SetGraph(Graph graph)
        {
            _graph = graph;
        }
    }
}
