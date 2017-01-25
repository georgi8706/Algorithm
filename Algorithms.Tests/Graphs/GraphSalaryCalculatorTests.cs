using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class GraphCycleBreakerTests
    {
        [TestMethod]
        public void GraphBreakCycleTest1()
        {
            Graph graph = CreateSimpleGraph1();

            var graphCycleBreaker = new GraphCyclesBreaker();
            graphCycleBreaker.SetGraph(graph);

            List<KeyValuePair<int, int>> removedEdges = graphCycleBreaker.BreakCycles();

            var expectedRemovedEdges = new List<KeyValuePair<int, int>>();
            expectedRemovedEdges.Add(new KeyValuePair<int, int>(1, 2));
            expectedRemovedEdges.Add(new KeyValuePair<int, int>(6, 7));
        
            CollectionAssert.AreEqual(removedEdges, expectedRemovedEdges);
        }

        [TestMethod]
        public void GraphBreakCycleTest2()
        {
            Graph graph = CreateSimpleGraph2();

            var graphCycleBreaker = new GraphCyclesBreaker();
            graphCycleBreaker.SetGraph(graph);

            List<KeyValuePair<int, int>> removedEdges = graphCycleBreaker.BreakCycles();

            var expectedRemovedEdges = new List<KeyValuePair<int, int>>();

            expectedRemovedEdges.Add(new KeyValuePair<int, int>(8, 9)); // A-Z
            expectedRemovedEdges.Add(new KeyValuePair<int, int>(8, 9)); // A-Z
            expectedRemovedEdges.Add(new KeyValuePair<int, int>(12, 10)); // B-F
            expectedRemovedEdges.Add(new KeyValuePair<int, int>(11, 10)); // E-F
            expectedRemovedEdges.Add(new KeyValuePair<int, int>(7, 5)); // I-L
            expectedRemovedEdges.Add(new KeyValuePair<int, int>(1, 0)); // J-K
            expectedRemovedEdges.Add(new KeyValuePair<int, int>(5, 3)); // L-N

            CollectionAssert.AreEqual(removedEdges, expectedRemovedEdges);
        }

        private Graph CreateSimpleGraph1()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 1, 4, 3 }, 1);
            graph.InsertNode(1, new int[] { 0, 2 }, 2);
            graph.InsertNode(2, new int[] { 1, 4 }, 3);
            graph.InsertNode(3, new int[] { 0 }, 4);
            graph.InsertNode(4, new int[] { 0, 2 }, 5);
            graph.InsertNode(5, new int[] { 6, 7 }, 6);
            graph.InsertNode(6, new int[] { 5, 7 }, 7);
            graph.InsertNode(7, new int[] { 5, 6 }, 8);

            return graph;
        }

        private Graph CreateSimpleGraph2()
        {
            var graph = new Graph();

            // Component 1
            graph.InsertNode(0, new int[] { 1, 2 }, 'K');
            graph.InsertNode(1, new int[] { 0, 3 }, 'J');
            graph.InsertNode(2, new int[] { 0, 3, 4 }, 'X');
            graph.InsertNode(3, new int[] { 1, 2, 5, 6 }, 'N');
            graph.InsertNode(4, new int[] { 2, 5 }, 'Y');
            graph.InsertNode(5, new int[] { 3, 4, 7 }, 'L');
            graph.InsertNode(6, new int[] { 3, 7 }, 'M');
            graph.InsertNode(7, new int[] { 5 }, 'I');

            // Component 2
            graph.InsertNode(8, new int[] { 9 }, 'A');
            graph.InsertNode(9, new int[] { 8 }, 'Z');

            // Component 3
            graph.InsertNode(10, new int[] { 11, 12, 13 }, 'F');
            graph.InsertNode(11, new int[] { 10, 13 }, 'E');
            graph.InsertNode(12, new int[] { 10, 13 }, 'B');
            graph.InsertNode(13, new int[] { 11, 12, 13 }, 'P');

            return graph;
        }
    }
}
