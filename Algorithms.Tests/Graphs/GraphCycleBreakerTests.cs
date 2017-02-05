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

            List<Edge> deletedEdges = graphCycleBreaker.BreakCycles();

            var expectedEdges = new List<Edge>();
            expectedEdges.Add(new Edge(new Node(0), new Node(1))); // 1-2
            expectedEdges.Add(new Edge(new Node(5), new Node(6))); // 6-7

            bool areEqual = GraphTestUtils.AreEdgesEqual(deletedEdges, expectedEdges);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void GraphBreakCycleTest2()
        {
            Graph graph = CreateSimpleGraph2();

            var graphCycleBreaker = new GraphCyclesBreaker();
            graphCycleBreaker.SetGraph(graph);

            List<Edge> deletedEdges = graphCycleBreaker.BreakCycles();

            var expectedEdges = new List<Edge>();

            expectedEdges.Add(new Edge(new Node(8), new Node(9))); // A-Z
            expectedEdges.Add(new Edge(new Node(8), new Node(9))); // A-Z
            expectedEdges.Add(new Edge(new Node(12), new Node(10))); // B-F
            expectedEdges.Add(new Edge(new Node(11), new Node(10))); // E-F
            expectedEdges.Add(new Edge(new Node(7), new Node(5))); // I-L
            expectedEdges.Add(new Edge(new Node(1), new Node(0))); // J-K
            expectedEdges.Add(new Edge(new Node(5), new Node(3))); // L-N

            bool areEqual = GraphTestUtils.AreEdgesEqual(deletedEdges, expectedEdges);

            Assert.IsTrue(areEqual); 
        }

        private Graph CreateSimpleGraph1()
        {
            var graph = new Graph();

            // Component 1
            graph.InsertNode(0, new int[] { 1, 4, 3 }, '1');
            graph.InsertNode(1, new int[] { 0, 2 }, '2');
            graph.InsertNode(2, new int[] { 1, 4 }, '3');
            graph.InsertNode(3, new int[] { 0 }, '4');
            graph.InsertNode(4, new int[] { 0, 2 }, '5');

            // Component 2
            graph.InsertNode(5, new int[] { 6, 7 }, '6');
            graph.InsertNode(6, new int[] { 5, 7 }, '7');
            graph.InsertNode(7, new int[] { 5, 6 }, '8');

            graph.CreateEdges();

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
            graph.InsertNode(7, new int[] { 5, 6 }, 'I');

            // Component 2
            graph.InsertNode(8, new int[] { 9, 9, 9 }, 'A');
            graph.InsertNode(9, new int[] { 8, 8, 8 }, 'Z');

            // Component 3
            graph.InsertNode(10, new int[] { 11, 12, 13 }, 'F');
            graph.InsertNode(11, new int[] { 10, 13 }, 'E');
            graph.InsertNode(12, new int[] { 10, 13 }, 'B');
            graph.InsertNode(13, new int[] { 10, 11, 12 }, 'P');

            graph.CreateEdges();

            return graph;
        }
    }
}
