using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class GraphMaxFlowTests
    {
        [TestMethod]
        public void GraphBiconnectivityTests1()
        {
            Graph graph = CreateSimpleGraph();

            var maxFlowFinder = new GraphMaxFlow();
            maxFlowFinder.SetGraph(graph);

            List<int> points = maxFlowFinder.Find(0, 9);

            var expectedPoints = new List<int>() { 7, 0, 6, 4 };

            CollectionAssert.AreEquivalent(points, expectedPoints);
        }

        private Graph CreateSimpleGraph()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 6, 8 });
            graph.InsertNode(1, new int[] { 4, 7, 9, 11 });
            graph.InsertNode(2, new int[] { 7, 8, 11 });
            graph.InsertNode(3, new int[] { 10 });
            graph.InsertNode(4, new int[] { 1, 5, 6, 11 });
            graph.InsertNode(5, new int[] { 4, 6, 8, 11 });
            graph.InsertNode(6, new int[] { 0, 4, 5 });
            graph.InsertNode(7, new int[] { 1, 2, 9, 11 });
            graph.InsertNode(8, new int[] { 0, 2, 5 });
            graph.InsertNode(9, new int[] { 1, 7 });
            graph.InsertNode(10, new int[] { 3 });
            graph.InsertNode(11, new int[] { 1, 2, 4, 5, 7 });

            graph.CreateEdges();

            graph[0, 6][0].Weight = 30;
            graph[0, 8][0].Weight = 22;
            graph[6, 5][0].Weight = 6;
            graph[8, 5][0].Weight = 3;
            graph[6, 4][0].Weight = 17;
            graph[8, 2][0].Weight = 14;
            graph[5, 4][0].Weight = 5;
            graph[5, 11][0].Weight = 33;
            graph[4, 11][0].Weight = 11;
            graph[2, 11][0].Weight = 9;
            graph[4, 1][0].Weight = 20;
            graph[2, 7][0].Weight = 15;
            graph[11, 1][0].Weight = 6;
            graph[11, 7][0].Weight = 20;
            graph[1, 7][0].Weight = 26;
            graph[1, 9][0].Weight = 25;
            graph[7, 9][0].Weight = 23;
            graph[3, 10][0].Weight = 7;

            return graph;
        }
    }
}
