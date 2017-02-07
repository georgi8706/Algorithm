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

        // Key: node index, Value: tree that node belongs to
        Dictionary<int, int> _mst = new Dictionary<int, int>();

        public List<Edge> FindMST()
        {
            foreach (Node node in _graph.Nodes)
            {
                _mst.Add(node.Index, node.Index);
            }

            var path = new List<Edge>();

            SortEdges();

            foreach (Edge edge in _graph.Edges)
            {
                // Check if the two nodes of the edge are part of different trees
                int firstTreeIndex = _mst[edge.Node1.Index];
                int secondTreeIndex = _mst[edge.Node2.Index];

                if (firstTreeIndex != secondTreeIndex)
                {
                    // Combine the two trees. Add the second tree to the first.

                    // Get all nodes of the second tree
                    var secondTree = _mst.Where(nodeVsTree => nodeVsTree.Value == secondTreeIndex).ToList();

                    foreach(KeyValuePair<int, int> node in secondTree)
                    {
                         _mst[node.Key] = firstTreeIndex;
                    }

                    path.Add(edge);
                }
            }

            return path;
        }

        public void SetGraph(Graph graph)
        {
            _graph = graph;
        }

        private void SortEdges()
        {
            foreach (Edge edge in _graph.Edges)
            {
                string val1 = edge.Node1.Value.ToString();
                string val2 = edge.Node2.Value.ToString();

                int compareRes = String.Compare(val1, val2);
                if (compareRes > 0)
                {
                    Node temp = edge.Node1;
                    edge.Node1 = edge.Node2;
                    edge.Node2 = temp;
                }
            }

            _graph.Edges.Sort();
        }
    }
}
