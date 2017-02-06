using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class GraphMSTresolvedViaKruskalTests
    {
        [TestMethod]
        public void GraphMSTresolvedViaKruskalTest()
        {
            Graph graph = CreateSimpleGraph();

            var mstFinder = new GraphMSTresolvedViaKruskal();
            mstFinder.SetGraph(graph);

            List<Edge> path = mstFinder.FindMST();

            var expectedEdges = new List<Edge>();

            expectedEdges.Add(graph[1, 3][0]); // B-D
            expectedEdges.Add(graph[0, 1][0]); // A-B
            expectedEdges.Add(graph[0, 2][0]); // A-C
            expectedEdges.Add(graph[7, 8][0]); // H-I
            expectedEdges.Add(graph[2, 4][0]); // C-E
            expectedEdges.Add(graph[6, 7][0]); // G-H
            expectedEdges.Add(graph[4, 5][0]); // E-F

            bool areEqual = GraphTestUtils.AreEdgesEqual(path, expectedEdges);

            Assert.IsTrue(areEqual);
        }

        private Graph CreateSimpleGraph()
        {
            var graph = new Graph();

            // Component 1
            graph.InsertNode(0, new int[] { 1, 2, 3 }, 'A');
            graph.InsertNode(1, new int[] { 0, 3 }, 'B');
            graph.InsertNode(2, new int[] { 0, 4 }, 'C');
            graph.InsertNode(3, new int[] { 0, 1, 2 }, 'D');
            graph.InsertNode(4, new int[] { 2, 3 }, 'E');
            graph.InsertNode(5, new int[] { 4 }, 'F');

            // Component 2
            graph.InsertNode(6, new int[] { 7, 8 }, 'G');
            graph.InsertNode(7, new int[] { 6, 8 }, 'H');
            graph.InsertNode(8, new int[] { 6, 7 }, 'I');

            graph.CreateEdges();

            // Set weights of the edges

            // Component 1
            graph[0, 1][0].Weight = 4;
            graph[0, 2][0].Weight = 5;
            graph[0, 3][0].Weight = 9;
            graph[1, 3][0].Weight = 2;
            graph[2, 3][0].Weight = 20;
            graph[2, 4][0].Weight = 7;
            graph[3, 4][0].Weight = 8;
            graph[4, 5][0].Weight = 12;

            // Component 2
            graph[6, 7][0].Weight = 8;
            graph[6, 8][0].Weight = 10;
            graph[7, 8][0].Weight = 7;

            return graph;
        }
    }
}
