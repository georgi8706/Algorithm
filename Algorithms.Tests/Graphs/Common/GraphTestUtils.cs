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
        public static bool AreEdgesEqualAndInOrder(List<Edge> edges1, List<Edge> edges2)
        {
            IEnumerator<Edge> edges2Enumerator = edges2.GetEnumerator();

            if (edges1.Count == edges2.Count)
            {
                foreach (Edge edge in edges1)
                {
                    edges2Enumerator.MoveNext();

                    if (!edge.IsEqual(edges2Enumerator.Current))
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

        public static bool AreEdgesEqual(List<Edge> edges1, List<Edge> edges2)
        {
            if (edges1.Count == edges2.Count)
            {
                foreach (Edge edge1 in edges1)
                {
                    if (edges2.FirstOrDefault(edge2 => edge2.IsEqual(edge1)) == null)
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
