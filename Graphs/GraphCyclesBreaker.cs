using System;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms
{
    class EdgesComparerByNodeValues : IComparer<Edge>
    {
        int IComparer<Edge>.Compare(Edge edge1, Edge edge2)
        {
            string val1 = edge1.Node1.Value.ToString();
            string val2 = edge2.Node1.Value.ToString();

            int compareRes = String.Compare(val1, val2);
            if (compareRes == 0)
            {
                val1 = edge1.Node2.Value.ToString();
                val2 = edge2.Node2.Value.ToString();

                compareRes = String.Compare(val1, val2);
            }

            return compareRes;
        }
    }

    public class GraphCyclesBreaker
    {
        Graph _graph;
        List<int> _visitedNodes = new List<int>();

        public List<Edge> BreakCycles()
        {
            var removedEdges = new List<Edge>();

            SortEdges();

            var graphUtils = new GraphUtils(_graph);

            int componentsNumber = graphUtils.CalculateComponentsNumber();

            // Check if the graph has any cycles.
            // In any acyclic graph, the edges number is less or equal to the number of nodes - 1, otherwise the graph has a cycle.
            int edgeIndex = 0;

            while (_graph.Edges.Count + componentsNumber > _graph.Nodes.Count)
            {
                _visitedNodes.Clear();

                Edge edge = _graph.Edges[edgeIndex];

                if (graphUtils.IsEdgePartOfCycle(edge))
                {
                    removedEdges.Add(edge);

                    _graph.DeleteEdge(edge);
                }
                else
                {
                    edgeIndex++;
                }
            }

            return removedEdges;
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

            _graph.Edges.Sort(new EdgesComparerByNodeValues());
        }
    }
}
