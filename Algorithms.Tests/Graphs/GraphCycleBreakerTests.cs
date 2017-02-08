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

            var expectedEdges = new List<Edge>();
            expectedEdges.Add(graph[0, 1][0]); // 1-2
            expectedEdges.Add(graph[5, 6][0]); // 6-7

            List<Edge> deletedEdges = graphCycleBreaker.BreakCycles();

            bool areEqual = GraphTestUtils.AreEdgesEqualAndInOrder(deletedEdges, expectedEdges);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void GraphBreakCycleTest2()
        {
            Graph graph = CreateSimpleGraph2();

            var graphCycleBreaker = new GraphCyclesBreaker();
            graphCycleBreaker.SetGraph(graph);

            var expectedEdges = new List<Edge>();

            expectedEdges.Add(graph[8, 9][0]); // A-Z
            expectedEdges.Add(graph[8, 9][0]); // A-Z
            expectedEdges.Add(graph[12, 10][0]); // B-F
            expectedEdges.Add(graph[11, 10][0]); // E-F
            expectedEdges.Add(graph[7, 5][0]); // I-L
            expectedEdges.Add(graph[1, 0][0]); // J-K
            expectedEdges.Add(graph[5, 3][0]); // L-N

            List<Edge> deletedEdges = graphCycleBreaker.BreakCycles();

            bool areEqual = GraphTestUtils.AreEdgesEqualAndInOrder(deletedEdges, expectedEdges);

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
