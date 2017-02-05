using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms.Tests.Graphs
{
    public class GraphTestUtils
    {
        public static bool AreEdgesEqual(List<Edge> edges1, List<Edge> edges2)
        {
            IEnumerator<Edge> edges2Enumerator = edges2.GetEnumerator();

            if (edges1.Count == edges2.Count)
            {
                foreach (Edge edge in edges1)
                {
                    edges2Enumerator.MoveNext();

                    if (edge.Node1.Index != edges2Enumerator.Current.Node1.Index ||
                        edge.Node2.Index != edges2Enumerator.Current.Node2.Index ||
                        edge.Weight != edges2Enumerator.Current.Weight)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
